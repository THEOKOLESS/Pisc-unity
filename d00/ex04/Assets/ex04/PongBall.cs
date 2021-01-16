using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    // Start is called before the first frame update
    private float   ballSpeed;
    private float   dirX;
    private float   dirY;
    public static float ballX;
    public static float ballY;
    private int scorePlayer1;
    private int scorePlayer2;
    private Vector3 direction;
   

    
    void Start()
    {   scorePlayer1 = 0;
        scorePlayer2 = 0;
        ballSpeed = 12f;
        setup();
    }
    void    setup(){ 
        dirX = (Random.Range(0,2)) > 0 ? 1 : -1;
        dirY = (Random.Range(0,2)) > 0 ? 1 : -1;
    }

    // Update is called once per frame
    void Update()
    {
        ballY = gameObject.transform.localPosition.y;
        ballX = gameObject.transform.localPosition.x;
        if(ballY > 9.6f || ballY < -9.6f){
           dirY *= -1;
        }
        if((ballX < - 13 && ballX > -15))
        {
           if (ballY <= Player.player2PosY + 2 && ballY >= Player.player2PosY -2)
            {
                dirX *= -1;
            }    
        }

        if((ballX > 13 && ballX < 15))
        {
            if (ballY <= Player.player1PosY + 2 && ballY >= Player.player1PosY -2)
            {
                dirX *= -1;
            }    
        }
        direction = new Vector3(dirX,dirY);
        if (ballX > 17f || ballX < -17){
             setup();
            if(ballX > 17f){
                scorePlayer2 += 1;
            }
            else if (ballX < -17){
                scorePlayer1 += 1;
            }
            Debug.Log("Player 1: " +  scorePlayer1 + " | Player 2: " + scorePlayer2);
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
        transform.Translate(direction * ballSpeed * Time.deltaTime);
    }
}
