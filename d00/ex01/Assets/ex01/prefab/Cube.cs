using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float i;
    // Start is called before the first frame update
    void Start()
    {
         i = Random.Range(-0.035f, -0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "a(Clone)"){
            if(Input.GetKeyDown("a")){
                Debug.Log("Precision: " + (gameObject.transform.localPosition.y - (-4.563629)));
                Destroy(gameObject);
            }
        }
         if(gameObject.name == "d(Clone)"){
            if(Input.GetKeyDown("d")){
                Debug.Log("Precision: " + (gameObject.transform.localPosition.y - (-4.563629)));
                Destroy(gameObject);
            }
        }
         if(gameObject.name == "s(Clone)"){
            if(Input.GetKeyDown("s")){
                Debug.Log("Precision: " + (gameObject.transform.localPosition.y - (-4.563629)));
                Destroy(gameObject);
            }
        }
        if(gameObject.transform.localPosition.y < -5.5){
            Destroy(gameObject);
        }
        transform.Translate(0, i, 0);
    }
}
