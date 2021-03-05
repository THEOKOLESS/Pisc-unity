using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex05   : MonoBehaviour
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

    public static int whiteDoor;
    public static bool redDoor1;
    public static bool blueDoor1;
    public static bool yellowDoor1;
    public static int currentPlayerOnSwitch;
    public static int playerOnSwitchRedYellow;
    public static int playerOnSwitch;

    public  static  bool    switchChangePlatformColorRedYellow;
    public  static  bool    gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        playerOnSwitch = 0;
        playerOnSwitchRedYellow = 0;
        switchChangePlatformColorRedYellow = false;
        currentPlayerOnSwitch = 0;
        yellowDoor1 = false;
        blueDoor1 = false;
        whiteDoor = 0;
        redDoor1 = false;
        flag_red = 0;
        flag_yellow = 0;
        flag_blue = 0;
        currentPlayer = 1;
        right = new Vector3(1, 0, 0);
        left = new Vector3(-1, 0, 0);
        up = new Vector3(0, 1, 0);
        Physics2D.gravity = new Vector2(0, -3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
            currentPlayer = 1;
        else if (Input.GetKeyDown("2"))
            currentPlayer = 2;
        else if (Input.GetKeyDown("3"))
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
        if(gameObject.transform.localPosition.y < -23){
            gameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
          if (currentPlayer == 2 && other.name == "yellow_exit")
                flag_yellow = 1;
            if (currentPlayer == 1 && other.name == "red_exit")
                flag_red = 1;
            if (currentPlayer == 3 && other.name == "blue_exit")
                flag_blue = 1;
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("trap")){
            gameOver = true;
        }
        else if(collision.gameObject.CompareTag("ammo")){
            gameOver = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (currentPlayer == 1 && other.name == "red_exit")
                flag_red=0;
            if (currentPlayer == 2 && other.name == "yellow_exit")
                flag_yellow = 0;
            if (currentPlayer == 3 && other.name == "blue_exit")
                flag_blue = 0;
    }
}

