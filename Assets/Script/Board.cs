using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public class Orientation {
        readonly int idx = 0;
        readonly Vector2Int vec;

        private Orientation(int idx, int x, int y)
        {
            this.idx = idx; this.vec = new Vector2Int(x, y);
        }

        private readonly Orientation[] orientations = new Orientation[4] { Up, Left, Down, Right };
        static readonly Orientation Up = new Orientation(0, 0, 1);
        static readonly Orientation Left = new Orientation(1, 1, 0);
        static readonly Orientation Down = new Orientation(2, 0, -1);
        static readonly Orientation Right = new Orientation(3, 0, 1);

        Orientation rotateLeft()
        {
            int index = (idx + 1) % 4;
            return orientations[index];
        }

        Orientation rotateRight()
        {
            int index = (idx + 3) % 4;
            return orientations[index];
        }

        Vector2Int Vector() { return vec; }

        float Angle() { return idx * 90; }
    };

    public class Robot
    {
        int id;
        Orientation orientation;
        public Vector2Int pos { get; set; }

        public Robot(int id)
        {
            this.id = id;
        }
    }

    private class Cell
    {
        public Robot robot; // Pushable object
        public bool isHole;

        // public bool wallUp;
        // walls: 4 bools
        // Orientation hasPusher
        // Orientation CBelt
        // CBeltSpeed
        // 
    }

    private Cell[,] cells; // = new Cell[10, 10];
    private readonly List<Robot> robots = new List<Robot> ();
    private int nextRobotId = 0;

    readonly string[] mapData =
        {
            "#v#####     #####v#",
            "#1 1 .<o . o#. . .<",
            "#     #     #     #",
            "#1 . r 1 . . r . .#",
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

    public void Init(string[] strData)
    {
        data = new Cell[strData.Length, strData[0].Length];

        for (int y = 1; y < mapData.Length; y += 2)
        {
            for (int x = 1; x < mapData[y].Length; x += 2)
            {
                if (mapData[y][x] == '1')
                {
                    Robot robot = new Robot(nextRobotId);
                    robot.pos = new Vector2Int(x / 2, y / 2);
                    nextRobotId++;
                    robots.Add(robot);
                    cells[x, y].robot = robot;
                }
                if (mapData[y][x] == 'o')
                {
                    cells[y, x].isHole = true;
                }
            }
        }
    }

    public void Init()
    {
        Init(mapData);
    }

    public List<Robot> GetRobots()
    {
        return robots;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
