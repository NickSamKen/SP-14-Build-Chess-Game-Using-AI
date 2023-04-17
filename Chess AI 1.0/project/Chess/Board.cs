using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    /// <summary>
    /// Chess Board state
    /// </summary>
    public class ChessBoard
    {
        
        /// <summary>
        /// square grid include rows(number:0-8) and columns(letter:a-h)
        /// </summary>
        
        public piece_t[][] Grid { get; private set; }
        /// <summary>
        /// Kings's position dictionary
        /// </summary>
        public Dictionary<Player, position_t> Kings { get; private set; }
        /// <summary>
        /// Pieces's position list dictionary
        /// </summary>
        public Dictionary<Player, List<position_t>> Pieces { get; private set; }
        /// <summary>
        /// Last move postion dictionary
        /// </summary>
        public Dictionary<Player, position_t> LastMove { get; private set; }
        /// <summary>
        /// init Chess Board
        /// </summary>
        public ChessBoard()
        {
            // init blank board grid
            Grid = new piece_t[8][];
            for (int i = 0; i < 8; i++)
            {
                Grid[i] = new piece_t[8];
                for (int j = 0; j < 8; j++)
                    Grid[i][j] = new piece_t(Piece.NONE, Player.WHITE);
            }

            // init last moves
            LastMove = new Dictionary<Player, position_t>();
            LastMove[Player.BLACK] = new position_t();
            LastMove[Player.WHITE] = new position_t();

            // init king positions
            Kings = new Dictionary<Player, position_t>();

            // init piece position lists
            Pieces = new Dictionary<Player, List<position_t>>();
            Pieces.Add(Player.BLACK, new List<position_t>());
            Pieces.Add(Player.WHITE, new List<position_t>());
        }
        /// <summary>
        /// a clone ChessBoard
        /// </summary>
        /// <param name="copy"></param>
        public ChessBoard(ChessBoard copy)
        {
            // init piece position lists
            Pieces = new Dictionary<Player, List<position_t>>();
            Pieces.Add(Player.BLACK, new List<position_t>());
            Pieces.Add(Player.WHITE, new List<position_t>());

            // init board grid to copy locations
            Grid = new piece_t[8][];
            for (int i = 0; i < 8; i++)
            {
                Grid[i] = new piece_t[8];
                for (int j = 0; j < 8; j++)
                {
                    Grid[i][j] = new piece_t(copy.Grid[i][j]);

                    // add piece location to list
                    if (Grid[i][j].piece != Piece.NONE)
                        Pieces[Grid[i][j].player].Add(new position_t(j, i));
                }
            }

            // copy last known move
            LastMove = new Dictionary<Player, position_t>();
            LastMove[Player.BLACK] = new position_t(copy.LastMove[Player.BLACK]);
            LastMove[Player.WHITE] = new position_t(copy.LastMove[Player.WHITE]);

            // copy king locations
            Kings = new Dictionary<Player, position_t>();
            Kings[Player.BLACK] = new position_t(copy.Kings[Player.BLACK]);
            Kings[Player.WHITE] = new position_t(copy.Kings[Player.WHITE]);
        }

        /// <summary>
        /// SetInitialPlacement
        /// </summary>
        public void SetInitialPlacement()
        {
            for (int i = 0; i < 8; i++)
            {
                SetPiece(Piece.PAWN, Player.WHITE, i, 1);
                SetPiece(Piece.PAWN, Player.BLACK, i, 6);
            }

            SetPiece(Piece.ROOK, Player.WHITE, 0, 0);
            SetPiece(Piece.ROOK, Player.WHITE, 7, 0);
            SetPiece(Piece.ROOK, Player.BLACK, 0, 7);
            SetPiece(Piece.ROOK, Player.BLACK, 7, 7);

            SetPiece(Piece.KNIGHT, Player.WHITE, 1, 0);
            SetPiece(Piece.KNIGHT, Player.WHITE, 6, 0);
            SetPiece(Piece.KNIGHT, Player.BLACK, 1, 7);
            SetPiece(Piece.KNIGHT, Player.BLACK, 6, 7);

            SetPiece(Piece.BISHOP, Player.WHITE, 2, 0);
            SetPiece(Piece.BISHOP, Player.WHITE, 5, 0);
            SetPiece(Piece.BISHOP, Player.BLACK, 2, 7);
            SetPiece(Piece.BISHOP, Player.BLACK, 5, 7);

            SetPiece(Piece.KING, Player.WHITE, 4, 0);
            SetPiece(Piece.KING, Player.BLACK, 4, 7);
            Kings[Player.WHITE] = new position_t(4, 0);
            Kings[Player.BLACK] = new position_t(4, 7);
            SetPiece(Piece.QUEEN, Player.WHITE, 3, 0);
            SetPiece(Piece.QUEEN, Player.BLACK, 3, 7);
        }
        /// <summary>
        /// SetPiece
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="player"></param>
        /// <param name="letter"></param>
        /// <param name="number"></param>
        public void SetPiece(Piece piece, Player player, int letter, int number)
        {
            // set grid values
            Grid[number][letter].piece = piece;
            Grid[number][letter].player = player;

            // add piece to list
            Pieces[player].Add(new position_t(letter, number));

            // update king position
            if (piece == Piece.KING)
            {
                Kings[player] = new position_t(letter, number);
            }
        }
    }
}
