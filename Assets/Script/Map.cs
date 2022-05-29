using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject goFloor;
    public GameObject goHWall;
    public GameObject goVWall;
    public GameObject goLaser1;
    public GameObject goInterWall;
    public GameObject goStart;
    public GameObject goRotator;
    public GameObject goRobot;
    public GameObject goController;
    public Controller controller;
    readonly Color[] colors = new Color[] { Color.red, Color.green, Color.blue };

    readonly string[] mapData =
        {
            "#v#####     #####v#",
            "#. . .<o . o#. . .<",
            "#     #     #     #",
            "#. . r 1 . . r . .#",
            "###             ###",
            " o . . . . . . . o ",
            "                   ",
            " . . .#. 1 . . . . ",
            "                   ",
            " o . . . . . . . o ",
            "#v#             #v#",
            "#. . r . . . r 1 .#",
            "#     #     #     #",
            "#. . .<o . o#. . .<",
            "#######     #######",
        };

    int nbRobots = 0;

    void InitRobot(GameObject obj)
    {
        var robot = obj.GetComponent<MonoBehaviour>() as Robot;
        robot.SetColor(colors[nbRobots]);
        if (nbRobots == 0)
        {
            controller = goController.GetComponent<MonoBehaviour>() as Controller;
            controller.Init(robot);
        }
        nbRobots++;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Objects
        for (int y = 1; y < mapData.Length; y += 2)
        {
            for (int x = 1; x < mapData[y].Length; x += 2)
            {
                if (mapData[y][x] != 'o')
                {
                    Instantiate(goFloor, new Vector3(x / 2, -0.5f, y / 2), Quaternion.identity, this.transform);
                }
                if (mapData[y][x] == '1')
                {
                    Instantiate(goStart, new Vector3(x / 2, 0f, y / 2), Quaternion.identity, this.transform);
                    var rb = Instantiate(goRobot, new Vector3(x / 2, 3f, y / 2), Quaternion.identity, this.transform);
                    InitRobot(rb);
                }
                if (mapData[y][x] == 'r')
                {
                    Instantiate(goRotator, new Vector3(x / 2, 0f, y / 2), Quaternion.identity, this.transform);
                }
            }
        }

        // HWalls
        for (int y = 1; y < mapData.Length; y += 2)
        {
            for (int x = 0; x < mapData[y].Length; x += 2)
            {
                if (mapData[y][x] != ' ')
                {
                    Instantiate(goHWall, new Vector3(x / 2 - 0.5f, 0f, y / 2), Quaternion.identity, this.transform);
                }
                if (mapData[y][x] == '<')
                {
                    var laser = Instantiate(goLaser1, new Vector3(x / 2 - 0.5f, 0f, y / 2), Quaternion.identity, this.transform);
                    var tr = laser.GetComponent<Transform>();
                    var v = tr.rotation.eulerAngles;
                    v.y = 90f;
                    tr.rotation = Quaternion.Euler(v);
                    tr.localScale = new Vector3(tr.localScale.x, tr.localScale.y, 3f);
                }
            }
        }

        // VWalls
        for (int y = 0; y < mapData.Length; y += 2)
        {
            for (int x = 1; x < mapData[y].Length; x += 2)
            {
                if (mapData[y][x] != ' ')
                {
                    Instantiate(goVWall, new Vector3(x / 2, 0f, y / 2 - 0.5f), Quaternion.identity, this.transform);
                }
                if (mapData[y][x] == 'v')
                {
                    var laser = Instantiate(goLaser1, new Vector3(x / 2, 0f, y / 2 - 0.5f), Quaternion.identity, this.transform);
                    var tr = laser.GetComponent<Transform>();
                    var v = tr.rotation.eulerAngles;
                    v.y = 180f;
                    tr.rotation = Quaternion.Euler(v);
                    tr.localScale = new Vector3(tr.localScale.x, tr.localScale.y, 2f);
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
                    Instantiate(goInterWall, new Vector3(x / 2 - 0.5f, 0f, y / 2 - 0.5f), Quaternion.identity, this.transform);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
