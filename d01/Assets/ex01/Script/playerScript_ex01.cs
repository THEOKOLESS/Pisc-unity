using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex01 : MonoBehaviour
{
    [SerializeField] private int id;
    public static int flag_red;
    public static int flag_yellow;
    public static int flag_blue;
    private int currentPlayer;
    private Vector3 right;
    private Vector3 left;
    private Vector3 up;
    [SerializeField] private float speed;
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        flag_red = 0;
        flag_yellow = 0;
        flag_blue = 0;
        currentPlayer = 1;
        right = new Vector3(1, 0, 0);
        left = new Vector3(-1, 0, 0);
        up = new Vector3(0, 1, 0);
        Physics2D.gravity = new Vector2(0, -2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.parent.name == "red")
            currentPlayer = 1;
        else if (Camera.main.transform.parent.name == "yellow")
            currentPlayer = 2;
        else if (Camera.main.transform.parent.name == "blue")
            currentPlayer = 3;

        if (id != currentPlayer)
            gameObject.transform.GetComponent<Rigidbody2D>().mass = 1000;
        else
        {
            gameObject.transform.GetComponent<Rigidbody2D>().mass = 5;
            if (Input.GetKey("right"))
                gameObject.transform.Translate(right * Time.deltaTime * speed);
            if (Input.GetKey("left"))
                gameObject.transform.Translate(left * Time.deltaTime * speed);
            rigidbody2d = gameObject.transform.GetComponent<Rigidbody2D>();
            if (rigidbody2d.velocity == new Vector2(0f, 0f) && Input.GetKeyDown("space"))
                rigidbody2d.velocity = up * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (currentPlayer == 2 && other.name == "yellow_exit")
            flag_yellow += 1;
        if (currentPlayer == 1 && other.name == "red_exit")
            flag_red += 1;
        if (currentPlayer == 3 && other.name == "blue_exit")
            flag_blue += 1;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (currentPlayer == 1 && other.name == "red_exit")
            flag_red -= 1;
        if (currentPlayer == 2 && other.name == "yellow_exit")
            flag_yellow -= 1;
        if (currentPlayer == 3 && other.name == "blue_exit")
            flag_blue -= 1;
    }
}
