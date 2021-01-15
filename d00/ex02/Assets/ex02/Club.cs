using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
     public  static float strength;
     public  float speed;
     public  float clubSpeed;
     public  float tempStrength;
     private int flag;
     public  static int score;
    // Start is called before the first frame update
    void Start()
    {
        strength = 0f;
        flag = 0;
        tempStrength = strength;
        clubSpeed = 3f;
        score = -20;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Ball.speed;
        if(Input.GetKey(KeyCode.Space) && Ball.gameOver == 0){ 
            clubSpeed += 0.1f;
             if(Ball.ballY > 4.35f){
                 gameObject.transform.Translate(0, Time.deltaTime * clubSpeed, 0);
             }
             else
             {
                 gameObject.transform.Translate(0, (Time.deltaTime *-1) * clubSpeed, 0);
             }
            tempStrength += 0.3f;
            if (flag == 0){
                score += 5;
                flag = 1;
            }
        }
        else if(Ball.gameOver == 0)
        {
            if (tempStrength > 50f){
                tempStrength = 50f;
            }
            strength = tempStrength;
            tempStrength = 0f;
            clubSpeed = 3f;
            flag = 0;
        }
       
        if(speed == 0f && Input.GetKey(KeyCode.Space) == false){
         gameObject.transform.localPosition = new Vector3(Ball.ballX -0.3f, Ball.ballY + 0.3f, -2);
         if(Ball.ballY > 4.35f){
             gameObject.transform.localPosition = new Vector3(Ball.ballX -0.3f, Ball.ballY + 1f, -2);
         }
        }

        
    }
}
