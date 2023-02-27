using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField] private int tileCountx = 8;
    [SerializeField] private int tileCounty = 8;
    public GameObject tiles;
    [SerializeField] private Transform[,] tilesArray;
    //Chess controller
    [SerializeField] private Transform startTile;
    [SerializeField] private double tileX;
    [SerializeField] private double tileY;
    [SerializeField] private float tilePosMultiplier = 4.25f;
    void Start()//could be awake
    {
        CreateChessTiles(1, tileCountx, tileCounty);
        FillTileArray();
    }

    //creates the grid
    private void CreateChessTiles(int v, int tileCountx, int tileCounty)
    {
        tilesArray = new Transform[tileCountx, tileCounty];
    }

    //CalculateCoordsFromPosion(in inputPosition: Vector3)

    // SelectPiece(In piece: Piece)

    //DeselectPiece()

    //OnSelectedPieceMove(in newCoords: Vector2int, in oldCoords: Vector2Int, in newPiece: Piece, in oldPiece: Piece)
    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillTileArray()
    {
        float posX = startTile.position.x;
        float posY = startTile.position.y;
        for (int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                tilesArray[i,j] = Instantiate(startTile, new Vector3(posX + j * tilePosMultiplier, posY + i * tilePosMultiplier, -1), Quaternion.identity);
            }
        }
    }
}
