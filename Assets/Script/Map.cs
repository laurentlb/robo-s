using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject floor;
    public GameObject hWall;
    public GameObject vWall;
    public GameObject interWall;
    public GameObject start;
    public GameObject rotator;
    public GameObject robot;

    // Start is called before the first frame update
    void Start()
    {
        string[] mapData =
        {
            "#######     #######",
            "#. . .#o . o#. . .#",
            "#     #     #     #",
            "#. . r . . . r . .#",
            "###             ###",
            " o . . . . . . . o ",
            "                   ",
            " . . .#. 1 . . . 1 ",
            "                   ",
            " o . . . . . . . o ",
            "###             ###",
            "#. . r . . . r . .#",
            "#     #     #     #",
            "#. . .#o 1 o#. . .#",
            "#######     #######",
        };

        // Objects
        for (int y = 1; y < mapData.Length; y += 2)
        {
            for (int x = 1; x < mapData[y].Length; x += 2)
            {
                if (mapData[y][x] != 'o')
                {
                    Instantiate(floor, new Vector3(x / 2, -0.5f, y / 2), Quaternion.identity);
                }
                if (mapData[y][x] == '1')
                {
                    Instantiate(start, new Vector3(x / 2, 0f, y / 2), Quaternion.identity);
                    Instantiate(robot, new Vector3(x / 2, 3f, y / 2), Quaternion.identity);
                }
                if (mapData[y][x] == 'r')
                {
                    Instantiate(rotator, new Vector3(x / 2, 0f, y / 2), Quaternion.identity);
                }
            }
        }

        // HWalls
        for (int y = 1; y < mapData.Length; y += 2)
        {
            for (int x = 0; x < mapData[y].Length; x += 2)
            {
                if (mapData[y][x] == '#')
                {
                    Instantiate(hWall, new Vector3(x / 2 - 0.5f, 0f, y / 2), Quaternion.identity);
                }
            }
        }

        // VWalls
        for (int y = 0; y < mapData.Length; y += 2)
        {
            for (int x = 1; x < mapData[y].Length; x += 2)
            {
                if (mapData[y][x] == '#')
                {
                    Instantiate(vWall, new Vector3(x / 2, 0f, y / 2 - 0.5f), Quaternion.identity);
                }
            }
        }

        // InterWalls
        for (int y = 0; y < mapData.Length; y += 2)
        {
            for (int x = 0; x < mapData[y].Length; x += 2)
            {
                if (mapData[y][x] == '#')
                {
                    Instantiate(interWall, new Vector3(x / 2 - 0.5f, 0f, y / 2 - 0.5f), Quaternion.identity);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
