using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    /// <summary>
    /// main function AI evalution
    /// </summary>
    public class AI
    {

        #region Confirmed AI
        /// <summary>
        ///  search depth
        /// </summary>
       
        public static int DEPTH = 3;
        /// <summary>
        /// piece value for AI evaluation
        /// </summary>        
        public static int piecePawnValue = 100, pieceKnightValue = 300, pieceBishopValue = 320, pieceRookValue = 500, pieceQueenValue = 900, pieceKingValue = 20000;
        /// <summary>
        /// isAIRuning:true/false
        /// </summary>
        
        public static bool RUNNING = false;
        /// <summary>
        /// isStop
        /// </summary>        
        public static bool STOP = false;
        private static Player MAX = Player.BLACK;
        //private piece value
        private static int[] pieceWeights = { 100, 500, 300, 320, 900, 20000 };
        private static int nodes = 0;

        private static Dictionary<int, int> history_score;
        
        private static TranspositionTable table;
        /// <summary>
        /// Calculate and return the boards Evaluation value.
        /// </summary>
        /// <param name="board">current ChessBoard state</param>
        /// <param name="turn">"Who's side are we viewing from."></param>
        /// <returns>The board evaluation, what else?</returns>
        private static int Evaluation(ChessBoard board, Player turn)
        {
            int evaluation = 0;
            //int[] blackPieces = { 0, 0, 0, 0, 0, 0 };
            //int[] whitePieces = { 0, 0, 0, 0, 0, 0 };
            //int blackMoves = 0;
            //int whiteMoves = 0;

            //pieceWeights[0] = piecePawnValue;
            //pieceWeights[1] = pieceRookValue;
            //pieceWeights[2] = pieceKnightValue;
            //pieceWeights[3] = pieceBishopValue;
            //pieceWeights[4] = pieceQueenValue;
            //pieceWeights[5] = pieceKingValue;


            //// sum up the number of moves and pieces
            //foreach (position_t pos in board.Pieces[Player.BLACK])
            //{
            //    blackMoves += LegalMoveSet.getLegalMove(board, pos).Count;
            //    blackPieces[(int)board.Grid[pos.number][pos.letter].piece]++;
            //}

            //// sum up the number of moves and pieces
            //foreach (position_t pos in board.Pieces[Player.WHITE])
            //{
            //    whiteMoves += LegalMoveSet.getLegalMove(board, pos).Count;
            //    whitePieces[(int)board.Grid[pos.number][pos.letter].piece]++;
            //}

            //// if viewing from black side
            //if (turn == Player.BLACK)
            //{
            //    // apply weighting to piece counts
            //    for (int i = 0; i < 6; i++)
            //    {
            //        evaluation += pieceWeights[i] * (blackPieces[i] - whitePieces[i]);
            //    }
            //    // apply move value
            //    evaluation += (int)(0.5 * (blackMoves - whiteMoves));
            //}
            //else
            //{
            //    // apply weighting to piece counts
            //    for (int i = 0; i < 6; i++)
            //    {
            //        evaluation += pieceWeights[i] * (whitePieces[i] - blackPieces[i]);
            //    }

            //    // apply move value
            //    evaluation += (int)(0.5 * (whiteMoves - blackMoves));
            //}

            return evaluation;
        }
        

        /// <summary>
        /// Main interface:get best move after evaluated by fuction Minmax Search and Pruning Search(Alpha-Beta-cut)
        /// </summary>
        /// <param name="board">current ChessBoard state</param>
        /// <param name="turn">"Who's side are we viewing from."></param>
        /// <returns>move_t</returns>
        public static move_t GetBestMove(ChessBoard board, Player turn)   //MiniMaxAB
        {
            Console.WriteLine(DateTime .Now .ToString("yyyyMMdd HH:mm:ss.fff"));
            RUNNING = true; // we've started running
            STOP = false; // no interupt command sent
            MAX = turn; // who is maximizing
            table = new TranspositionTable();
            // gather all possible moves
            Dictionary<position_t, List<position_t>> moves = LegalMoveSet.getPlayerMoves(board, turn);
            initHistoryscore(true);
            // because we're threading safely store best result from each thread
            int[] bestresults = new int[moves.Count];
            move_t[] bestmoves = new move_t[moves.Count];
            int round = 0;
            // thread the generation of each move
            Parallel.ForEach(moves, (movelist, state, index) =>
            {
                if (STOP) // interupt
                {
                    state.Stop();
                    return;
                }

                // initialize thread best
                bestresults[index] = int.MinValue;
                bestmoves[index] = new move_t(new position_t(-1, -1), new position_t(-1, -1));

                // for each move for the current piece(thread)
                foreach (position_t move in movelist.Value)
                {
                    if (STOP) // interupt
                    {
                        state.Stop();
                        return;
                    }

                    // make initial move and start recursion
                    ChessBoard b2 = LegalMoveSet.move(board, new move_t(movelist.Key, move));
                    int result = int.MinValue;

                    if (DEPTH < 5)
                        result = MinMaxAB(b2, (turn == Player.WHITE) ? Player.BLACK : Player.WHITE, 1, Int32.MinValue, Int32.MaxValue);
                    else
                        result = -NegaMax(b2, (turn == Player.WHITE) ? Player.BLACK : Player.WHITE, 1, Int32.MinValue, Int32.MaxValue);
                    round++;
                    // if result is better or best hasn't been set yet
                    if (bestresults[index] < result || (bestmoves[index].to.Equals(new position_t(-1, -1)) && bestresults[index] == int.MinValue))
                    {
                        bestresults[index] = result;
                        bestmoves[index].from = movelist.Key;
                        bestmoves[index].to = move;
                    }
                }
                Console.WriteLine("AI result" + round + "=" + bestresults[index] +"   index="+index );
            });

            // interupted
            if (STOP)
                return new move_t(new position_t(-1, -1), new position_t(-1, -1));

            // find the best of the thread results
            int best = int.MinValue;
            move_t m = new move_t(new position_t(-1, -1), new position_t(-1, -1));
            for (int i = 0; i < bestmoves.Length; i++)
            {
                if (best < bestresults[i] || (m.to.Equals(new position_t(-1, -1)) && !bestmoves[i].to.Equals(new position_t(-1, -1))))
                {
                    best = bestresults[i];
                    m = bestmoves[i];
                }
            }            
            Console.WriteLine("historyScore.count=" + table.historyCount );
            Console.WriteLine("Nodes=" + nodes);
            Console.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fff"));
            nodes = 0;
            return m;
        }

        /// <summary>
        /// Minmax Search,include Alpha-Beta-cut(Pruning Search) 
        /// </summary>
        /// <param name="board">ChessBoard state</param>
        /// <param name="turn">who's turn</param>
        /// <param name="depth">search depth</param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <returns></returns>        

        private static int MinMaxAB(ChessBoard board, Player turn, int depth, int alpha, int beta)
        {
            // base case, at maximum depth return board fitness
            
            if (depth >= DEPTH)
                return CalculatePoint(board, MAX);

            else
            {
                List<ChessBoard> boards = new List<ChessBoard>();
                List<int> boardspointlist = new List<int>();
                // get available moves / board states from moves for the current player
                foreach (position_t pos in board.Pieces[turn])
                {
                    if (STOP) return -1; // interupts
                    List<position_t> moves = LegalMoveSet.getLegalMove(board, pos);
                    foreach (position_t move in moves)
                    {
                        if (STOP) return -1; // interupts
                        ChessBoard b2 = LegalMoveSet.move(board, new move_t(pos, move));
                        ////prepare sorting the boards—————————————————
                        int pointbeformove = CalculatePoint(board, turn);
                        int pointaftermove = CalculatePoint(b2, turn);
                        boardspointlist.Add(pointaftermove - pointbeformove);
                        ////——————————————————————————————
                        boards.Add(b2);
                        nodes++;

                    }
                }
                //order the moves
                if (boards.Count > 0) BoardSortedByCalculatePoint(boardspointlist, boards);

                int a = alpha, b = beta;

                if (turn != MAX) // minimize
                {
                    foreach (ChessBoard b2 in boards)
                    {
                        if (STOP) return -1; // interupt
                        b = Math.Min(b, MinMaxAB(b2, (turn == Player.WHITE) ? Player.BLACK : Player.WHITE, depth + 1, a, b));
                        if (a >= b)
                            return a;
                    }
                    return b;
                }
                else // maximize
                {
                    foreach (ChessBoard b2 in boards)
                    {
                        if (STOP) return -1; // interupt
                        a = Math.Max(a, MinMaxAB(b2, (turn == Player.WHITE) ? Player.BLACK : Player.WHITE, depth + 1, a, b));
                        if (a >= b)
                            return b;
                    }
                    return a;
                }
            }
        }
        /// <summary>
        /// sort the moved chessboard
        /// </summary>
        /// <param name="L">moves scorelist</param>
        /// <param name="B">aftermoved chessboard list</param>
        private static void BoardSortedByCalculatePoint(List<int> L,List<ChessBoard> B)
        {            
            ChessBoard tempb = new ChessBoard();
            int temp;
            if (L.Count != B.Count) return;
            var changed = true;

            for (int i = L.Count - 1; i > 0 && changed; i--)
            {
                changed = false;

                for (int j = 0; j < i; j++)
                {
                    if (L[j]< L[j + 1])
                    {
                        temp = L[j];
                        L[j] = L[j + 1];
                        L[j + 1] = temp;
                        tempb = B[j];
                        B[j] = B[j + 1];
                        B[j + 1] = tempb;
                        changed = true;
                    }
                }
            }

        }

        /// <summary>
        /// Search for the next best move based on evaluation with alpha beta pruning.
        /// </summary>
        /// <param name="board">current ChessBoard state</param>
        /// <param name="turn">who's turn</param>
        /// <param name="depth">search depth</param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <returns></returns>
        public static int NegaMax(ChessBoard board, Player turn, int depth, int alpha, int beta)
        {
            
            if (LegalMoveSet.IsTerminal(board))
            {                
                return CalculatePoint(board, turn);
            }

            if (depth >= DEPTH )
            {
                ////SearchAllCaptures:it doesn't work well.
                //return SearchAllCaptures(board, turn, alpha, beta);                
                return CalculatePoint(board, turn);
            }

            if (table.IsCalculatedBefore(board, depth, (turn == Player.WHITE), true))
            {
                int getvalue = table.GetCalculatedValue(board, depth, (turn == Player.WHITE), true);
                if (getvalue != 0) return getvalue;
            }

            List<ChessBoard> boards = new List<ChessBoard>();
            List<int> boardspointlist = new List<int>();
            // get available moves / board states from moves for the current player
            foreach (position_t pos in board.Pieces[turn])
            {
                if (STOP) return -1; // interupts
                List<position_t> moves = LegalMoveSet.getLegalMove(board, pos);
                foreach (position_t move in moves)
                {
                    if (STOP) return -1; // interupts
                    move_t m = new move_t(pos, move);
                    ChessBoard b2 = LegalMoveSet.move(board, m);
                    ////prepare sorting the boards—————————————————
                    int pointbeformove = CalculatePoint(board, turn);
                    int pointaftermove = CalculatePoint(b2, turn);
                    int hh = 0;
                    hh = HistoryMoveScore(m, board, depth);
                    boardspointlist.Add(pointaftermove - pointbeformove+hh);
                    ////——————————————————————————————
                    boards.Add(b2);
                    nodes++;
                }
            }
            
            ////order the moves including "History Heuristic+ killerHeuristic"
            if (boards.Count > 0) BoardSortedByCalculatePoint(boardspointlist, boards);


            bool first = true;
            ChessBoard bestmoveToBoard = new ChessBoard();
            foreach (ChessBoard b2 in boards)
            {
                if (STOP) return -1; // interupt
                int score = int.MinValue;

                if (!first)
                {
                    score = -NegaMax(b2, (turn == Player.WHITE) ? Player.BLACK : Player.WHITE, depth + 1, -(alpha + 1), -alpha);
                    if (alpha < score && score < beta)
                    {
                        score = -NegaMax(b2, (turn == Player.WHITE) ? Player.BLACK : Player.WHITE, depth + 1, -beta, -score);
                    }
                }
                else
                {                    
                    score = -NegaMax(b2, (turn == Player.WHITE) ? Player.BLACK : Player.WHITE, depth+ 1, -beta, -alpha);
                    first = false;
                }
                
                if (score >= beta)
                {
                    return score;
                }
                if (score > alpha)
                {
                    alpha = score;
                    bestmoveToBoard = b2;
                }
            }
            if (bestmoveToBoard != null)
            {
                updateHistoryScore(board, bestmoveToBoard, turn, depth);
            }
            table.InsertCalculatedValue(board, depth, (turn == Player.WHITE), true, alpha);
            return alpha;
        }
        

        /// <summary>
        /// Extension to negamax that searches deeper into the game until there are no more capture moves.
        /// But it doesn't work. :(
        /// </summary>
        /// <param name="board"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <param name="turn"></param>
        /// <returns></returns>
        private static int SearchAllCaptures(ChessBoard board, Player turn, int alpha, int beta)
        {
            if (LegalMoveSet.IsTerminal(board))
            {
                return CalculatePoint(board, turn);
            }
            int val = CalculatePoint(board, turn);
            if (val >= beta)
            {
                return beta;
            }
            alpha = Math.Max(alpha, val);
            List<ChessBoard> hasCaptureBoards = new List<ChessBoard>();
            List<int> boardspointlist = new List<int>();
            // get available moves / board states from moves for the current player
            foreach (position_t pos in board.Pieces[turn])
            {
                if (STOP) return -1; // interupts
                ///get all legal moves
                List<position_t> moves = LegalMoveSet.getLegalMove(board, pos);
                ///get list of capture moves
                foreach (position_t move in moves)
                {
                    if (STOP) return -1; // interupts
                    move_t m = new move_t(pos, move);                    
                    if (board.Grid[m.to.number][m.to.letter].piece != Piece.NONE && board.Grid[m.from.number][m.from.letter].player != board.Grid[m.to.number][m.to.letter].player)
                    {
                        ChessBoard b2 = LegalMoveSet.move(board, m);
                        ////prepare sorting the boards—————————————————
                        int pointaftermove = 10* GetPieceValue(board,move)-GetPieceValue (board,pos);                        
                        boardspointlist.Add(pointaftermove);
                        hasCaptureBoards.Add(b2);
                        nodes++;
                    }                       
                    
                }
            }
            //order the moves
            if (hasCaptureBoards.Count > 0) BoardSortedByCalculatePoint(boardspointlist, hasCaptureBoards);
            foreach (ChessBoard b2 in hasCaptureBoards)
            {
                if (STOP) return -1; // interupt
                int score = int.MinValue;
                score = -SearchAllCaptures(b2, (turn == Player.WHITE) ? Player.BLACK : Player.WHITE,  -beta, -alpha);
                if (score >= beta)
                {
                    return score;
                }
                if (score > alpha)
                {
                    alpha = score;
                }
            }
            return alpha;
            
        }

        //#########History Heuristic################################
        #region History Heuristic
        private static int GetMoveNum(move_t m,ChessBoard fromBoard)
        {
            return m.to.number * 100000 + m.to.letter * 10000 + m.from.number * 1000 + m.from .letter * 100 + (int)fromBoard.Grid[m.from .number ][m.from .letter].player * 10 + (int)fromBoard.Grid[m.from.number][m.from.letter].piece;
        }
        private static void initHistoryscore(bool clear_history)
        {
            if (clear_history)
            {
                history_score = new Dictionary<int, int>();
            }
            else
            {
                if (history_score == null)
                {
                    history_score = new Dictionary<int, int>();
                }
            }
        }
        private static int HistoryMoveScore(move_t m, ChessBoard fromBoard,int dept)
        {
            int val = 0;
                //杀子优先
                switch (fromBoard.Grid[m.to .number][m.to.letter].piece )
                {
                    case Piece.PAWN:
                        val = piecePawnValue * (1 << dept) / 10;
                        break;
                    case Piece.BISHOP:
                        val = pieceBishopValue  * (1 << dept) / 10;
                        break;
                    case Piece.KNIGHT :
                        val = pieceKnightValue  * (1 << dept) / 10;
                        break;
                    case Piece.ROOK:
                        val = pieceRookValue * (1 << dept) / 10;
                        break;
                    case Piece.QUEEN:
                        val = pieceQueenValue  * (1 << dept) / 10;
                        break;
                    case Piece.KING:
                        val = pieceKingValue * (1 << dept) / 10;
                        break;
                default:
                        val = 0;
                        break;
                }

                //History Heuristic
                int from_chess = GetMoveNum(m, fromBoard);
                if (history_score.ContainsKey(from_chess))
                {
                ////考虑杀招优先似乎变笨
                //val += history_score[from_chess];
                val = history_score[from_chess];
            }
            return val;
            
        }
        private static void updateHistoryScore(ChessBoard fromBoard, ChessBoard toChessBoard,Player turn,int dept)
        {
            position_t pFrom = new position_t();
            position_t pTo = toChessBoard .LastMove[turn];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    if (fromBoard.Grid[i][j].piece == toChessBoard.Grid[pTo.number][pTo.letter].piece && fromBoard.Grid[i][j].player == turn)
                    {
                        pFrom.number = i;
                        pFrom.letter = j;
                    }
            }

            move_t current_best_step = new move_t(pFrom ,pTo);
            int from_chess = GetMoveNum(current_best_step,fromBoard);
            if (history_score.ContainsKey(from_chess))
            {
                history_score[from_chess] += (1 << dept);
            }
            else
            {
                history_score.Add(from_chess, (1 << dept));
            }            
        }
        #endregion
        //#########end of History Heuristic#########################

        //##############new evaluation function######################
        #region Evaluate Function
        /// <summary>
        /// Calculate and return the boards Evaluation value.
        /// </summary>
        /// <param name="board">current ChessBoard state</param>
        /// <param name="turn">"Who's side are we viewing from."></param>
        /// <returns>The board evaluation, what else?</returns>

        private static int CalculatePoint(ChessBoard board, Player turn)
        {
            int scoreWhite = 0;
            int scoreBlack = 0;
            scoreWhite += GetScoreFromExistingPieces(Player.WHITE, board);
            scoreBlack += GetScoreFromExistingPieces(Player.BLACK, board);

            int evaluation = scoreBlack - scoreWhite;

            int prespective = (turn == Player.WHITE) ? -1 : 1;
            return evaluation * prespective;
        }

        /// <summary>
        /// Get score from the existing pieces of the faction
        /// </summary>
        /// <param name="player"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        private static int GetScoreFromExistingPieces(Player player, ChessBoard board)
        {
            int material = 0;

            foreach (position_t pos in board.Pieces[player])
            {
                if (board.Grid[pos.number][pos.letter].piece == Piece.PAWN)
                {
                    material += (piecePawnValue + bestPawnPositions[pos.number + pos.letter]); // plus "+ bestPawnPositions[i]" if you want, but it doesn't work well
                }
                if (board.Grid[pos.number][pos.letter].piece == Piece.KNIGHT)
                {
                    material += (pieceKnightValue + bestKnightPositions[pos.number + pos.letter]);
                }
                if (board.Grid[pos.number][pos.letter].piece == Piece.BISHOP)
                {
                    material += (pieceBishopValue + bestBishopPositions[pos.number + pos.letter]);
                }
                if (board.Grid[pos.number][pos.letter].piece == Piece.ROOK)
                {
                    material += (pieceRookValue + bestRookPositions[pos.number + pos.letter]);
                }
                if (board.Grid[pos.number][pos.letter].piece == Piece.QUEEN)
                {
                    material += (pieceQueenValue + bestQueenPositions[pos.number + pos.letter]);
                }
                if (board.Grid[pos.number][pos.letter].piece == Piece.KING)
                {
                    material += (pieceKingValue + bestKingPositions[pos.number + pos.letter]);
                }

            }
            return material;
        }
        /// <summary>
        /// Get the piece value
        /// </summary>
        /// <param name="board"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private static int GetPieceValue(ChessBoard board, position_t pos)
        {
            if (board.Grid[pos.number][pos.letter].piece == Piece.PAWN)
            {
                return piecePawnValue;
            }
            else if (board.Grid[pos.number][pos.letter].piece == Piece.ROOK)
            {
                return pieceRookValue;
            }
            else if (board.Grid[pos.number][pos.letter].piece == Piece.KNIGHT)
            {
                return pieceKingValue;
            }
            else if (board.Grid[pos.number][pos.letter].piece == Piece.BISHOP)
            {
                return pieceBishopValue ;
            }
            else if (board.Grid[pos.number][pos.letter].piece == Piece.QUEEN)
            {
                return pieceQueenValue ;
            }
            else if (board.Grid[pos.number][pos.letter].piece == Piece.KING )
            {
                return pieceKingValue ;
            }

            return 0;
        }
        private static readonly int[] bestPawnPositions = {
              0,  0,  0,  0,  0,  0,  0,  0,
             50, 50, 50, 50, 50, 50, 50, 50,
             10, 10, 20, 30, 30, 20, 10, 10,
              5,  5, 10, 25, 25, 10,  5,  5,
              0,  0,  0, 20, 20,  0,  0,  0,
              5, -5,-10,  0,  0,-10, -5,  5,
              5, 10, 10,-20,-20, 10, 10,  5,
              0,  0,  0,  0,  0,  0,  0,  0
        };

        private static readonly int[] bestKnightPositions = {
            -50,-40,-30,-30,-30,-30,-40,-50,
            -40,-20,  0,  0,  0,  0,-20,-40,
            -30,  0, 10, 15, 15, 10,  0,-30,
            -30,  5, 15, 20, 20, 15,  5,-30,
            -30,  0, 15, 20, 20, 15,  0,-30,
            -30,  5, 10, 15, 15, 10,  5,-30,
            -40,-20,  0,  5,  5,  0,-20,-40,
            -50,-40,-30,-30,-30,-30,-40,-50,
        };

        private static readonly int[] bestBishopPositions = {
            -20,-10,-10,-10,-10,-10,-10,-20,
            -10,  0,  0,  0,  0,  0,  0,-10,
            -10,  0,  5, 10, 10,  5,  0,-10,
            -10,  5,  5, 10, 10,  5,  5,-10,
            -10,  0, 10, 10, 10, 10,  0,-10,
            -10, 10, 10, 10, 10, 10, 10,-10,
            -10,  5,  0,  0,  0,  0,  5,-10,
            -20,-10,-10,-10,-10,-10,-10,-20,
        };

        private static readonly int[] bestRookPositions = {
              0,  0,  0,  0,  0,  0,  0,  0,
              5, 10, 10, 10, 10, 10, 10,  5,
             -5,  0,  0,  0,  0,  0,  0, -5,
             -5,  0,  0,  0,  0,  0,  0, -5,
             -5,  0,  0,  0,  0,  0,  0, -5,
             -5,  0,  0,  0,  0,  0,  0, -5,
             -5,  0,  0,  0,  0,  0,  0, -5,
              0,  0,  0,  5,  5,  0,  0,  0
        };

        private static readonly int[] bestQueenPositions = {
             -20,-10,-10, -5, -5,-10,-10,-20,
             -10,  0,  0,  0,  0,  0,  0,-10,
             -10,  0,  5,  5,  5,  5,  0,-10,
              -5,  0,  5,  5,  5,  5,  0, -5,
               0,  0,  5,  5,  5,  5,  0, -5,
             -10,  5,  5,  5,  5,  5,  0,-10,
             -10,  0,  5,  0,  0,  0,  0,-10,
             -20,-10,-10, -5, -5,-10,-10,-20
        };

        private static readonly int[] bestKingPositions = {
            -30,-40,-40,-50,-50,-40,-40,-30,
            -30,-40,-40,-50,-50,-40,-40,-30,
            -30,-40,-40,-50,-50,-40,-40,-30,
            -30,-40,-40,-50,-50,-40,-40,-30,
            -20,-30,-30,-40,-40,-30,-30,-20,
            -10,-20,-20,-20,-20,-20,-20,-10,
             20, 20,  0,  0,  0,  0, 20, 20,
             20, 30, 10,  0,  0, 10, 30, 20
        };
        #endregion
        //##############end of new evaluation function######################
        #endregion
    }
}
