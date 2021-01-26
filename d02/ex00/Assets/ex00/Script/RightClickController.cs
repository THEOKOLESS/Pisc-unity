using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetMouseButtonDown(1))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0f;
          //  Debug.Log(GetComponent<PlayerController>());
           // Debug.Log(worldPosition);
            GetComponent<PlayerController>().SetMovePosition(worldPosition);
        
        }   
    }
}
