namespace Chess
{
    /// <summary>
    /// Piece:Pawn,Rook,Knight,Bishop,Queen,King
    /// </summary>
    public enum Piece
    {
        NONE = -1,
        PAWN,
        ROOK,
        KNIGHT,
        BISHOP,
        QUEEN,
        KING
    }
    /// <summary>
    /// Player:BLACK,WHITE
    /// </summary>
    public enum Player
    {
        BLACK,
        WHITE
    }

    /// <summary>
    /// GameMode：NotStart，BothManual，WhiteAuto，BlackAuto,BothAuto。
    /// </summary>
    public enum GameMode
    {
        BothAuto=0,
        BlackAuto,
        WhiteAuto,
        Manual,
        NotStarted
    }

    /// <summary>
    /// position struct
    /// </summary>
    public struct position_t
    {
        /// <summary>
        /// chess board file or column of grid
        /// </summary>
        public int letter;
        /// <summary>
        /// chess board rank or row of grid
        /// </summary>
        public int number;   //file or row

        public position_t(int letter, int number)
        {
            this.letter = letter;
            this.number = number;
        }
        public position_t(position_t copy)
        {
            this.letter = copy.letter;
            this.number = copy.number;
        }

        public override bool Equals(object obj)
        {
            return letter == ((position_t)obj).letter && number == ((position_t)obj).number;
        }
    }

    
    /// <summary>
    /// copy piece struct for last postion
    /// </summary>
    public struct piece_t
    {
        public Piece piece;
        public Player player;
        public position_t lastPosition;

        public piece_t(Piece piece, Player player)
        {
            this.piece = piece;
            this.player = player;
            this.lastPosition = new position_t(-1, -1);
        }

        public piece_t(piece_t copy)
        {
            this.piece = copy.piece;
            this.player = copy.player;
            this.lastPosition = copy.lastPosition;
        }
    }
    /// <summary>
    /// move struct
    /// </summary>
    public struct move_t
    {
        public position_t from;
        public position_t to;

        public move_t(position_t from, position_t to)
        {
            this.from = from;
            this.to = to;
        }
    }
}