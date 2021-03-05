using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class cameraScript : MonoBehaviour
{
    public GameObject red;
    public GameObject yellow;
    public GameObject blue;
    // Start is called before the first frame update

    void Start()
    {
        Camera.main.transform.SetParent(red.transform);
        Camera.main.transform.localPosition = new Vector3(0,0,-10);
    }

    // Update is called once per frame
    void Update()
    {
        if(red.transform.localPosition.y < -20 || blue.transform.localPosition.y < -20 || yellow.transform.localPosition.y < -20 ){
            Camera.main.transform.SetParent(null);
        }
        else{
            if (Input.GetKeyDown("1"))
            {
                Camera.main.transform.SetParent(red.transform);
                Camera.main.transform.localPosition = new Vector3(0, 0, -10);
            }
            if (Input.GetKeyDown("2"))
            {
                Camera.main.transform.SetParent(yellow.transform);
                Camera.main.transform.localPosition = new Vector3(0, 0, -10);
            }
            if (Input.GetKeyDown("3"))
            {
                Camera.main.transform.SetParent(blue.transform);
                Camera.main.transform.localPosition = new Vector3(0, 0, -10);
            }
        
        }
    }   
}

