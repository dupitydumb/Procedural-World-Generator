using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Coordinate
{
    public int X;
    public int Y;

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class HexagonTile : MonoBehaviour
{
    public int index;
    public Coordinate coordinate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
