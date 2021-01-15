using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private float weight;
    private float flap;
    public static float birdY;
    public static int gameOver;
    public static int score;
    private int flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = 0;
        score = 0;
        gameOver = 0;
        weight = 3f;
        flap = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        birdY = gameObject.transform.localPosition.y;
        if(gameOver == 0){
                // transform.Translate(0, weight * Time.deltaTime * -1, 0);
            if(Input.GetKeyDown(KeyCode.Space)){    
                transform.Translate(0, flap * Time.deltaTime, 0,Camera.main.transform);
            }
            else
                transform.Translate(0, weight * Time.deltaTime * -1, 0);
        }

        if (birdY < -3.41f)
        {
            gameOver = 1;
        }
        if(flag == 0 && gameOver == 1 ){
                flag = 1;
                Debug.Log("Score: " + score);
                Debug.Log("Time: " + Mathf.RoundToInt(Time.realtimeSinceStartup) + "s");
            }
    }
}
