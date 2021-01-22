using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entitiesScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static GameObject sTelepIn1;
    [SerializeField] private GameObject _telep1;


    void Start()
    {
        sTelepIn1 = _telep1;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}   
