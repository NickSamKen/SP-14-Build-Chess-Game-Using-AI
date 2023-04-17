using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    class HashObject
    {
        public int depth;
        public Int64 hashKey;
        public int value;
        public bool isPlayerAMax;
        public bool turnPlayerA;
        /// <summary>
        /// Hash Item/object
        /// </summary>
        /// <param name="depth">record the depth</param>
        /// <param name="hashKey">hashkey for the move</param>
        /// <param name="value">score value</param>
        /// <param name="isPlayerAMax">who's turn, white turn;true, black turn:false</param>
        /// <param name="turnPlayerA">reserve</param>
        public HashObject(int depth, Int64 hashKey, int value, bool isPlayerAMax, bool turnPlayerA)
        {
            this.depth = depth;
            this.hashKey = hashKey;
            this.value = value;
            this.isPlayerAMax = isPlayerAMax;
            this.turnPlayerA = turnPlayerA;
        }
    }
}
