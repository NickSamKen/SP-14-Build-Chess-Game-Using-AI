using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isOccupy = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        //make the position equal to the position of the tile in the tileArray[,]
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setTile(bool occupation)
    {
        isOccupy = occupation;
    }

    public void MakeTileGreen()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    public void MakeTileRed()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

}