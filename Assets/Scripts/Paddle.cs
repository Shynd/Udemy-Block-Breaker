using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    private GameObject ball;
    private GameObject paddle;
    private float mousePosInBlocks;

    public bool autoPlay = true;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.Find("Ball");
        paddle = GameObject.Find("Paddle");
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    void MoveWithMouse()
    {
        mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        var paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y, this.transform.position.z);
        paddle.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        var ballPos = ball.transform.position;
        var paddlePos = new Vector3(Mathf.Clamp(ballPos.x, 0.5f, 15.5f), this.transform.position.y, this.transform.position.z);
        paddle.transform.position = paddlePos;
    }
}
