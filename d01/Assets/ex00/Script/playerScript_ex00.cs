using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour    
{
    [SerializeField] private    int id;
    private int currentPlayer;
    private Vector3 right;
    private Vector3 left;
    private Vector3 up;
    private float speed;
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = 1;
        right = new Vector3(1, 0, 0);
        left = new Vector3(-1, 0, 0);
        up = new Vector3(0, 1, 0);
        speed = 3f;
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
}
