using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject goSelection;
    public float speed;

    Robot robot;
    Rigidbody body;
    Vector3 targetPosition;

    public void Init(Robot robot)
    {
        this.robot = robot;
        targetPosition = robot.transform.position;
        body = robot.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPosition += new Vector3(0, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetPosition += new Vector3(0, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetPosition += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetPosition += new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var pos = new Vector3(2, 0, 2);
            robot.gameObject.transform.position = pos;
            targetPosition = pos;
        }
        goSelection.transform.position = targetPosition;
    }

    private void FixedUpdate()
    {
        var tr = robot.gameObject.transform;
        targetPosition.y = tr.position.y;
        //if (Vector3.Distance(tr.position, targetPosition) < 0.2f)
        //{
        //    return;
        //}
        targetPosition.y += 0.05f;
        // var moved = Vector2.MoveTowards(new Vector2(tr.position.x, tr.position.z), new Vector2(targetPosition.x, targetPosition.z), speed);
        // tr.position = Vector3.MoveTowards(tr.position, targetPosition, speed);
        // robot.gameObject

        var dir = Vector3.ClampMagnitude(targetPosition - tr.position, speed);

        body.MovePosition(tr.position + speed * Time.deltaTime * dir);

        // Vector3.
        // body.MovePosition(Vector3.MoveTowards(tr.position, targetPosition, speed));
        // body.MovePosition(Vector3.SmoothDamp(body.position, targetPosition, , smoothTime);


        // body.MovePosition(targetPosition)
    }
}
