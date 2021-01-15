using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float speed;
     private int flag;
    public static float pipeX;
    // Start is called before the first frame update
    void Start()
    {
        flag = 0;
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
         pipeX = gameObject.transform.localPosition.x;
         if(Bird.gameOver == 0){
            transform.Translate(speed * Time.deltaTime * -1, 0, 0);
            if (pipeX < -15f){
                gameObject.transform.localPosition = new Vector3(15f, 1.45f, 0);
            }
            if (Mathf.RoundToInt(pipeX) < 1 && Mathf.RoundToInt(pipeX) > -1 ){
                if (Bird.birdY < 0f || Bird.birdY > 2.7f){
                    Bird.gameOver = 1;
                }
                else if (flag == 0){
                    Bird.score +=5;
                    speed +=0.5f;
                    flag = 1;
                }
            }
            else
                flag = 0;
         }
    }
}
