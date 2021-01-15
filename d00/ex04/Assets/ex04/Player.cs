using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject   player1;
    public GameObject   player2;
    public static float player1PosY;
    public static float player2PosY;
    private float   playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {

        player1PosY = player1.transform.localPosition.y;
        player2PosY = player2.transform.localPosition.y;
       
        if(Input.GetKey("up") && player1PosY < 7.5f){
            player1.transform.Translate(0, Time.deltaTime * playerSpeed, 0);
        }
        else if(Input.GetKey("down") && player1PosY > -7.5f){
            player1.transform.Translate(0, (Time.deltaTime * -1)* playerSpeed, 0);
        }
        if(Input.GetKey("w")&& player2PosY < 7.5f){
         player2.transform.Translate(0, Time.deltaTime * 1* playerSpeed, 0);
        }
        else if(Input.GetKey("s")&& player2PosY > -7.5f){
            player2.transform.Translate(0, (Time.deltaTime * -1)* playerSpeed, 0);
        }
    }
}
