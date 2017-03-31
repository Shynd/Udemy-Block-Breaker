using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private GameObject paddle;
    private Vector3 paddleToBallVector;
    private bool started;

    // Use this for initialization
    void Start()
    {
        paddle = GameObject.Find("Paddle");
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                started = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (started)
        {
            Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            if (collider.collider.tag == "Breakable" || collider.collider.tag == "Unbreakable")
            {
                GetComponent<AudioSource>().Play();
            }
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
