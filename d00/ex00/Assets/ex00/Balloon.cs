using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private Vector3 scaleChange; /* maybe use vector2 in 2d*/ 
    private Vector3 startScaleChange;
    private Vector3 spaceScaleChange;
    private float lastButtonPress;
    private float timeDiff;
    private int buttonCount;
    private int flag;
    // Start is called before the first frame update
    void Start()
    {
        startScaleChange = new Vector3(7f, 7f);
        scaleChange = new Vector3(-0.01f, -0.01f);
        spaceScaleChange = new Vector3(-0.5f, -0.5f);
        buttonCount = 0;
        lastButtonPress = Time.time;
        timeDiff = lastButtonPress;
        flag = 0;
        gameObject.transform.localScale += startScaleChange;
    }

    void timing(){
         if (buttonCount > 20)
        {
            if (timeDiff < 2f){
                flag = 1;
                Debug.Log("You need to recover your breath for 2 sec");
            }
            else
            {
                flag = 0;
                gameObject.transform.localScale -= spaceScaleChange;
            }   
        }
        else
        {
              gameObject.transform.localScale -= spaceScaleChange;
        }
        if(timeDiff > 1f && flag == 0){ 
            buttonCount = 0;
        }
        else{
            buttonCount++;
        }

    }


    // Update is called once per frame
    void Update()
    {   
        gameObject.transform.localScale += scaleChange;
        timeDiff = Time.time - lastButtonPress;
        if(Input.GetKeyDown(KeyCode.Space)){    
            lastButtonPress = Time.time; 
        }


        if(gameObject.transform.localScale.x > 12){
            Destroy(gameObject);
            Debug.Log("Balloon life time: " +  Mathf.RoundToInt(Time.realtimeSinceStartup) + "s");
        }

        if(gameObject.transform.localScale.x < 0){
            Destroy(gameObject);
            Debug.Log("Balloon life time: " +  Mathf.RoundToInt(Time.realtimeSinceStartup) + "s");
        }
    }
}
