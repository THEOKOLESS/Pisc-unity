using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject red;
    public GameObject yellow;
    public GameObject blue;
    [SerializeField]Camera mycam;
    // Start is called before the first frame update

    void Start()
    {
        mycam.transform.SetParent(red.transform);
        //Camera.main.transform.parent = blue.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Camera.Camera.main.transform.SetParent(red.transform);main.transform.SetParent(player.transform);
    }
}
