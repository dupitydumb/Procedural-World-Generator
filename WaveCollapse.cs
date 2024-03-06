using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileRules
{
    [Range(0, 1)]
    public float probability;
    public GameObject tile;
    public List<GameObject> allowedTiles;
}

[System.Serializable]
public class Rules
{
    
    public List<TileRules> rules;
    public Rules()
    {
        
        rules = new List<TileRules>();
    }
    
}

public class WaveCollapse : MonoBehaviour
{
    public Rules rules;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collapse();
        }
    }

    // Update is called once per frame
    void Collapse()
    {
        //Neigbor Offset
        Vector3[] neighborOffsetOdd = new Vector3[]
        {
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(-1, 1, 0),
            new Vector3(-1, 0, 0),
            new Vector3(-1, -1, 0),
            new Vector3(0, -1, 0)
        };

        Vector3[] neighborOffsetEven = new Vector3[]
        {
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
            new Vector3(0, 1, 0),
            new Vector3(-1, 0, 0),
            new Vector3(0, -1, 0),
            new Vector3(1, -1, 0)
        };

        //GetNeigbors

        // List<HexagonTile> Neighbors = new List<HexagonTile>();

        // foreach (MappedHexagon hexagon in HexgonGenerator.instance.hexagons)
        // {
        //     //Get mapped hexagon index in the list
        //     int index = HexgonGenerator.instance.hexagons.IndexOf(hexagon);
        //     if (index % 2 == 0)
        //     {
        //         foreach (Vector3 offset in neighborOffsetEven)
        //         {
        //             Vector3 neighborPosition = hexagon.hexagon.transform.position + offset;
        //             foreach (MappedHexagon neighbor in HexgonGenerator.instance.hexagons)
        //             {
        //                 if (neighbor.hexagon.transform.position == neighborPosition)
        //                 {
        //                     Neighbors.Add(neighbor.hexagon);
        //                 }
        //             }
        //         }
        //     }
        //     else
        //     {
        //         foreach (Vector3 offset in neighborOffsetOdd)
        //         {
        //             Vector3 neighborPosition = hexagon.hexagon.transform.position + offset;
        //             foreach (MappedHexagon neighbor in HexgonGenerator.instance.hexagons)
        //             {
        //                 if (neighbor.hexagon.transform.position == neighborPosition)
        //                 {
        //                     Neighbors.Add(neighbor.hexagon);
        //                 }
        //             }
        //         }
        //     }
        // }

        //Check for matches and replace neighbors

        // foreach (HexagonTile hexagon in Neighbors)
        // {
        //     //Get mapped hexagon index in the list
        //     int index = hexagon.index;
        //     foreach (TileRules rule in rules.rules)
        //     {
        //         Debug.Log("Checking match for " + hexagon.gameObject.name + " with " + rule.tile.name);
        //         if (hexagon.gameObject.tag == rule.tile.tag)
        //         {
        //             Debug.Log("Found a match");
        //             float randomValue = Random.value;
        //             float cumulativeProbability = 0f;
        //             foreach (GameObject allowedTile in rule.allowedTiles)
        //             {
        //                 cumulativeProbability += rule.probability;
        //                 if (randomValue <= cumulativeProbability)
        //                 {
        //                     var randomTile = rule.allowedTiles[Random.Range(0, rule.allowedTiles.Count)];
        //                     GameObject newTile = Instantiate(randomTile, hexagon.transform.position, Quaternion.identity);
        //                     Destroy(hexagon.gameObject);
        //                     newTile.GetComponent<HexagonTile>().index = index;
        //                     HexgonGenerator.instance.hexagons[index].hexagon = newTile.GetComponent<HexagonTile>();
        //                     //replace the old tile with the new tile
        //                     break;
        //                 }
        //             }
        //         }
        //     }
        // }
        

        foreach (MappedHexagon hexagon in HexgonGenerator.instance.hexagons)
        {
            //Get mapped hexagon index in the list
            int index = HexgonGenerator.instance.hexagons.IndexOf(hexagon);
            foreach (TileRules rule in rules.rules)
            {
                Debug.Log("Checking match for " + hexagon.hexagon.gameObject.name + " with " + rule.tile.name);
                if (hexagon.hexagon.gameObject.tag == rule.tile.tag)
                {
                    Debug.Log("Found a match");
                    float randomValue = Random.value;
                    float cumulativeProbability = 0f;
                    foreach (GameObject allowedTile in rule.allowedTiles)
                    {
                        cumulativeProbability += rule.probability;
                        if (randomValue <= cumulativeProbability)
                        {
                            GameObject newTile = Instantiate(allowedTile, hexagon.hexagon.transform.position, Quaternion.identity);
                            Destroy(hexagon.hexagon.gameObject);
                            HexgonGenerator.instance.hexagons[index].hexagon = newTile.GetComponent<HexagonTile>();
                            break;
                        }
                    }
                }
            }
        }
    }

}
