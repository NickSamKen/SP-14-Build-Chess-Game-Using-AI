using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    /// <summary>
    /// class responsible for creation of transposition table and hashtable
    /// </summary>
    /// 
    static class RandomExtension
    {
        public static Int64 NextInt64(this System.Random rnd)
        {
            var buffer = new byte[sizeof(Int64)];
            rnd.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }
    }
    /// <summary>
    /// class HashTable:TranspositonTable
    /// </summary>
   public class TranspositionTable
    {
        private Int64[,] emptySpacesKeys = new Int64[8, 8];        
        private Int64[,] whitePawnKeys = new Int64[8,8];
        private Int64[,] whiteBishopKeys = new Int64[8, 8];
        private Int64[,] whiteKnightKeys = new Int64[8, 8];
        private Int64[,] whiteRookKeys = new Int64[8, 8];
        private Int64[,] whiteQueenKeys = new Int64[8, 8];
        private Int64[,] whiteKingKeys = new Int64[8, 8];
        private Int64[,] blackPawnKeys = new Int64[8, 8];
        private Int64[,] blackBishopKeys = new Int64[8, 8];
        private Int64[,] blackKnightKeys = new Int64[8, 8];
        private Int64[,] blackRookKeys = new Int64[8, 8];
        private Int64[,] blackQueenKeys = new Int64[8, 8];
        private Int64[,] blackKingKeys = new Int64[8, 8];
        
        private Int64 playerAMax;
        private Int64 playerBMax;
        private HashObject[] tableContent;
        private int tableSize = 64*12;
        public int historyCount = 0;

        private Dictionary<Int64, HashObject> historyEvaluted = new Dictionary<Int64, HashObject>();
        /// <summary>
        /// TranspositonTable
        /// </summary>
        public TranspositionTable()
        {
            tableContent = new HashObject[tableSize];
            System.Random random = new System.Random(DateTime.Now.Millisecond);
            List<Int64> generatedBefore = new List<Int64>();
            playerAMax = random.NextInt64();
            playerBMax = random.NextInt64();            
            generatedBefore.Add(playerAMax);

            while (generatedBefore.Contains(playerBMax)) playerBMax = random.NextInt64();
            generatedBefore.Add(playerBMax);

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int n = -1; n < 14; n++)
                    {
                        Int64 randomValue = random.NextInt64();
                        while (generatedBefore.Contains(randomValue)) randomValue = random.NextInt64();
                        generatedBefore.Add(randomValue);

                        switch (n)
                        {
                            case -1:
                                emptySpacesKeys[x,y] = randomValue;
                                break;
                            case 0:
                                whitePawnKeys[x,y] = randomValue;
                                break;
                            case 1:
                                whiteRookKeys[x,y] = randomValue;
                                break;
                            case 2:
                                whiteKnightKeys[x,y] = randomValue;
                                break;
                            case 3:
                                whiteBishopKeys[x,y] = randomValue;
                                break;
                            case 4:
                                whiteQueenKeys[x, y] = randomValue;
                                break;
                            case 5:
                                whiteKingKeys[x, y] = randomValue;
                                break;
                            case 8:
                                blackPawnKeys[x, y] = randomValue;
                                break;
                            case 9:
                                blackRookKeys[x, y] = randomValue;
                                break;
                            case 10:
                                blackKnightKeys[x, y] = randomValue;
                                break;
                            case 11:
                                blackBishopKeys[x, y] = randomValue;
                                break;
                            case 12:
                                blackQueenKeys[x, y] = randomValue;
                                break;
                            case 13:
                                blackKingKeys[x, y] = randomValue;
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Has the state been evaluated before
        /// </summary>
        /// <param name="board">state</param>
        /// <param name="depth">current depth</param>
        /// <param name="isPlayerAMax">who's turn, white turn;true, black turn:false</param>
        /// <param name="turnPlayerA">no used</param>
        /// <returns></returns>
        public bool IsCalculatedBefore(ChessBoard board, int depth, bool isPlayerAMax, bool turnPlayerA)
        {
            Int64 hashKey = CreateHashKey(board, depth, isPlayerAMax, turnPlayerA);
            //int position = (int)Math.Abs((hashKey % tableSize));
            //HashObject hashObject = tableContent[position];
            //if (hashObject == null)
            //    return false;
            //if (hashObject.depth >= depth && hashObject.hashKey == hashKey && hashObject.isPlayerAMax == isPlayerAMax && hashObject.turnPlayerA == turnPlayerA)
            //    return true;
            //return false;
            
            if (historyEvaluted == null)
                return false;
            if (historyEvaluted.ContainsKey(hashKey))
            {
                HashObject hashObject = historyEvaluted[hashKey];
                if (hashObject != null && hashObject.depth >= depth && hashObject.hashKey == hashKey && hashObject.isPlayerAMax == isPlayerAMax)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Get evaluated score in history table for same move in same state.
        /// </summary>
        /// <param name="board">state</param>
        /// <param name="depth">current depth</param>
        /// <param name="isPlayerAMax">who's turn, white turn;true, black turn:false</param>
        /// <param name="turnPlayerA"></param>
        /// <returns></returns>
        public int GetCalculatedValue(ChessBoard board, int depth, bool isPlayerAMax, bool turnPlayerA)
        {
            try
            {
                Int64 hashKey = CreateHashKey(board, depth, isPlayerAMax, turnPlayerA);
                //int position = (int)Math.Abs((hashKey % tableSize));
                //HashObject hashObject = tableContent[position];
                //if (hashObject == null)
                //    throw new Exception("Board has not been calculated before and inserted into the transposition table");
                //if (hashObject.depth >= depth && hashObject.hashKey == hashKey && hashObject.isPlayerAMax == isPlayerAMax && hashObject.turnPlayerA == turnPlayerA)
                //    return hashObject.value;
                //else
                //    throw new Exception("Board has not been calculated before and inserted into the transposition table");
                
                HashObject hashObject = historyEvaluted[hashKey];
                if (hashObject == null)
                    throw new Exception("Board has not been calculated before and inserted into the transposition table");
                if (hashObject.depth >= depth && hashObject.hashKey == hashKey && hashObject.isPlayerAMax == isPlayerAMax && hashObject.turnPlayerA == turnPlayerA)
                    return hashObject.value;
                else
                    throw new Exception("Board has not been calculated before and inserted into the transposition table");
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetCalculatedValue error:"+ ex.Message);
                return 0;
            }
            
        }

        //public void InsertCalculatedValue(ChessBoard board, int depth, bool isPlayerAMax, bool turnPlayerA, int value)
        //{
        //    try
        //    {
        //        Int64 hashKey = CreateHashKey(board, depth, isPlayerAMax, turnPlayerA);
        //        int position = (int)Math.Abs((hashKey % tableSize));
        //        if (position >= tableSize) Console.WriteLine("______________错误_________________________");
        //        Console.WriteLine("哈希表位置="+position+"  tablesize="+tableSize);
        //        HashObject hashObject = tableContent[position];
        //        if (hashObject == null)
        //            tableContent[position] = new HashObject(depth, hashKey, value, isPlayerAMax, turnPlayerA);
        //        else
        //        {
        //            bool collision = true;
        //            while (collision)
        //            {
        //                position = (int)Math.Abs((hashKey % tableSize));
        //                hashObject = tableContent[position];
        //                if (hashObject == null)
        //                    collision = false;
        //                else if (hashObject.hashKey != hashKey || hashObject.isPlayerAMax != isPlayerAMax)
        //                    TableResize();
        //                else
        //                    collision = false;
        //            }
        //            tableContent[position] = new HashObject(depth, hashKey, value, isPlayerAMax, turnPlayerA);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("insert calculateValue error:"+ex);
        //        throw new Exception(ex.Message);
                
        //    }

        //}
        /// <summary>
        /// Insert the EvaluatedMoveScore in history table.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="depth"></param>
        /// <param name="isPlayerAMax"></param>
        /// <param name="turnPlayerA"></param>
        /// <param name="value"></param>
        public void InsertCalculatedValue(ChessBoard board, int depth, bool isPlayerAMax, bool turnPlayerA, int value)
        {
            try
            {
                Int64 hashKey = CreateHashKey(board, depth, isPlayerAMax, turnPlayerA);
                HashObject hashObject = new HashObject(depth, hashKey, value, isPlayerAMax, turnPlayerA);
                if (!historyEvaluted.ContainsKey(hashKey))
                    historyEvaluted.Add(hashKey, hashObject);
                else
                {
                    if(hashObject .value <value ) historyEvaluted[hashKey] = hashObject;
                }
                    
                historyCount = historyEvaluted.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("insert calculateValue error:" + ex);
                throw new Exception(ex.Message);

            }

        }

        private Int64 CreateHashKey(ChessBoard board, int depth, bool isPlayerAMax, bool turnPlayerA)
        {
            Int64 result = 0;

            if (isPlayerAMax)
                result = result ^ playerAMax;
            else
                result = result ^ playerBMax;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (board.Grid[x][y].player == Player.WHITE)
                    {
                        switch (board.Grid[x][y].piece)
                        {
                            case Piece.NONE:
                                result = result ^ emptySpacesKeys[x, y];
                                break;
                            case Piece.PAWN:
                                result = result ^ whitePawnKeys[x, y];
                                break;
                            case Piece.ROOK:
                                result = result ^ whiteRookKeys[x, y];
                                break;
                            case Piece.KNIGHT:
                                result = result ^ whiteKnightKeys[x, y];
                                break;
                            case Piece.BISHOP:
                                result = result ^ whiteBishopKeys[x, y];
                                break;
                            case Piece.QUEEN:
                                result = result ^ whiteQueenKeys[x, y];
                                break;
                            case Piece.KING:
                                result = result ^ whiteKingKeys[x, y];
                                break;
                        }
                    }
                    else if (board.Grid[x][y].player == Player.BLACK)
                    {
                        switch (board.Grid[x][y].piece)
                        {
                            case Piece.NONE:
                                result = result ^ emptySpacesKeys[x, y];
                                break;
                            case Piece.PAWN:
                                result = result ^ blackPawnKeys[x, y];
                                break;
                            case Piece.ROOK:
                                result = result ^ blackRookKeys[x, y];
                                break;
                            case Piece.KNIGHT:
                                result = result ^ blackKnightKeys[x, y];
                                break;
                            case Piece.BISHOP:
                                result = result ^ blackBishopKeys[x, y];
                                break;
                            case Piece.QUEEN:
                                result = result ^ blackQueenKeys[x, y];
                                break;
                            case Piece.KING:
                                result = result ^ blackKingKeys[x, y];
                                break;
                        }
                    }
                }
            }

            return result;

        }

        private void TableResize()
        {
            try
            {
                tableSize = NextPrime(this.tableSize);
                HashObject[] transTable = new HashObject[tableSize];
                foreach (HashObject obj in this.tableContent)
                {
                    if (obj != null)
                        transTable[(int)Math.Abs((obj.hashKey % tableSize))] = obj;
                }
                tableContent = transTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("TableResize error:" + ex);
                throw new Exception(ex.Message);
            }
            
        }

        private int NextPrime(int previousPrime)
        {
            while (!IsPrime(++previousPrime)) ;
            return previousPrime;
        }

        private bool IsPrime(int possiblePrime)
        {
            int a = 1;
            for (int m = 2; m <= Math.Sqrt(possiblePrime); m += a)
            {
                if (m == 3)
                    a = 2;
                if (possiblePrime % m == 0)
                    return false;
            }
            return true;
        }


        

    }
}