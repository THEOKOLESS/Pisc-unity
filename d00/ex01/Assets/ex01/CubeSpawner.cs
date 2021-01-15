using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject   a;
    public GameObject   d;
    public GameObject   s;

    private float   timerA;
    private float   timerS;
    private float   timerD;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (timerA >= 3){
            timerA = 0;
            GameObject.Instantiate(a,  new Vector2(-4.056483f, 4.37f), Quaternion.identity);
        }


        if (timerD >= 4){
            timerD = 0;
            GameObject.Instantiate(d,  new Vector2(0, 4.45f), Quaternion.identity);
        }


        if (timerS >= 3.5){
            timerS = 0;
            GameObject.Instantiate(s,  new Vector2(4.12f, 4.49f), Quaternion.identity);
        }

        timerA += Time.deltaTime;
        timerS += Time.deltaTime;
        timerD += Time.deltaTime;
    }
}
