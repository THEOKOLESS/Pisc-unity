using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
        public static float speed;
        public static float ballX;
        public static float ballY;
        public int direction;
        public static int gameOver;
        private int flag;
        private int flag2;
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        speed = Club.strength;
        gameOver = 0;
        flag = 1;
        flag2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
       ballY = gameObject.transform.localPosition.y;
       ballX = gameObject.transform.localPosition.x;
        if (speed > 0){
          
             speed -= 0.05f;
            if(ballY > 4.66f)
            {
                direction = -1;
            }
            else if (ballY< -4.66f)
                direction = 1;

            transform.Translate(0, speed * (Time.deltaTime * direction), 0);
            flag2 = 1;
        }
        else
        {
            if (Mathf.Clamp(ballY, -4.66f, 3.65f) == ballY)
                direction = 1;
            else
            {
                direction = -1;
            }
           
            speed = Club.strength;

             if (flag2 == 1){
                 flag = 0;
                 flag2 = 0;
             }
        }
        if(Mathf.Clamp(ballY, 3.65f, 4.35f) == ballY && 
        Mathf.Clamp(speed, 0f, 4f) == speed){
            gameObject.transform.localPosition = new Vector3(ballX, ballY, 10);
            gameOver = 1;
        }
        if (flag == 0){
                 Debug.Log("Score: " + Club.score);
                 flag = 1;
             }
    }
}
