using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Map of the hexagon grid
[System.Serializable]
public class MappedHexagon
{
    public HexagonTile hexagon;
    public int x;
    public int y;

    public MappedHexagon(HexagonTile hexagon, int x, int y)
    {
        this.hexagon = hexagon;
        this.x = x;
        this.y = y;
    }
}

public class HexgonGenerator : MonoBehaviour
{
    public GameObject HexagonPrefab;
    public int width = 10;
    public int height = 10;

    private float xOffset = 1f;
    private float yOffset = 0.882f;

    public List<MappedHexagon> hexagons = new List<MappedHexagon>();

    public static HexgonGenerator instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        GenerateHexagons();
    }

    void GenerateHexagons()
    {
        int coorX = 0;
        int coorY = 0;
        for (int x = 0; x < width; x++)
        {
            coorX++;
            coorY = 0; // Reset coorY to 0 at the beginning of each iteration

            for (int y = 0; y < height; y++)
            {
                coorY++;
                float xPos = x * xOffset;

                // every other row is offset in x direction
                if (y % 2 == 1)
                {
                    xPos += xOffset / 2f;
                }

                GameObject hex = (GameObject)Instantiate(HexagonPrefab, new Vector3(xPos, 0, y * yOffset), Quaternion.identity);
                hex.transform.parent = this.transform;
                hex.GetComponent<HexagonTile>().coordinate = new Coordinate(coorX, coorY);
                hexagons.Add(new MappedHexagon(hex.GetComponent<HexagonTile>(), coorX, coorY));
                hex.GetComponent<HexagonTile>().index = hexagons.IndexOf(hexagons[hexagons.Count - 1]);
            }
            
        }
    }
}
