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
        public static int piecePawnValue = 100, pieceKnightValue = 300, pieceBishopValue = 320, pieceRookValue = 500, pieceQueenValue = 900, pieceKingValue = 2000;
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
        private static int[] pieceWeights = { 100, 500, 300, 320, 900, 2000 };
        private static int nodes = 0;

        /// <summary>
        /// Calculate and return the boards Evaluation value.
        /// </summary>
        /// <param name="board">current ChessBoard state</param>
        /// <param name="turn">"Who's side are we viewing from."></param>
        /// <returns>The board evaluation, what else?</returns>
        private static int Evaluation(ChessBoard board, Player turn)
        {
            int evaluation = 0;
            int[] blackPieces = { 0, 0, 0, 0, 0, 0 };
            int[] whitePieces = { 0, 0, 0, 0, 0, 0 };
            int blackMoves = 0;
            int whiteMoves = 0;

            pieceWeights[0] = piecePawnValue;
            pieceWeights[1] = pieceRookValue;
            pieceWeights[2] = pieceKnightValue;
            pieceWeights[3] = pieceBishopValue;
            pieceWeights[4] = pieceQueenValue;
            pieceWeights[5] = pieceKingValue;


            // sum up the number of moves and pieces
            foreach (position_t pos in board.Pieces[Player.BLACK])
            {
                blackMoves += LegalMoveSet.getLegalMove(board, pos).Count;
                blackPieces[(int)board.Grid[pos.number][pos.letter].piece]++;
            }

            // sum up the number of moves and pieces
            foreach (position_t pos in board.Pieces[Player.WHITE])
            {
                whiteMoves += LegalMoveSet.getLegalMove(board, pos).Count;
                whitePieces[(int)board.Grid[pos.number][pos.letter].piece]++;
            }

            // if viewing from black side
            if (turn == Player.BLACK)
            {
                // apply weighting to piece counts
                for (int i = 0; i < 6; i++)
                {
                    evaluation += pieceWeights[i] * (blackPieces[i] - whitePieces[i]);
                }
                // apply move value
                evaluation += (int)(0.5 * (blackMoves - whiteMoves));
            }
            else
            {
                // apply weighting to piece counts
                for (int i = 0; i < 6; i++)
                {
                    evaluation += pieceWeights[i] * (whitePieces[i] - blackPieces[i]);
                }

                // apply move value
                evaluation += (int)(0.5 * (whiteMoves - blackMoves));
            }

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

            // gather all possible moves
            Dictionary<position_t, List<position_t>> moves = LegalMoveSet.getPlayerMoves(board, turn);

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
                    //int result = mimaab(b2, (turn == Player.WHITE) ? Player.BLACK : Player.WHITE, 1, Int32.MinValue, Int32.MaxValue);
                    int result = MinMaxAB(b2, (turn == Player.WHITE) ? Player.BLACK : Player.WHITE, 1, Int32.MinValue, Int32.MaxValue);
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
                return Evaluation(board, MAX);
            else
            {
                List<ChessBoard> boards = new List<ChessBoard>();

                // get available moves / board states from moves for the current player
                foreach (position_t pos in board.Pieces[turn])
                {
                    if (STOP) return -1; // interupts
                    List<position_t> moves = LegalMoveSet.getLegalMove(board, pos);
                    foreach (position_t move in moves)
                    {
                        if (STOP) return -1; // interupts
                        ChessBoard b2 = LegalMoveSet.move(board, new move_t(pos, move));
                        boards.Add(b2);
                        nodes++;
                    }
                }

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
    }
}
