using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportLocater : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float velocity;
    public static GameObject sTelepIn1;
    [SerializeField] private GameObject _telep1;

    private GameObject movingPlataform1;
    [SerializeField] private GameObject movePlat1;

    private float timming;
    private int direction; 
    void Start()
    {
        direction = 1;
        sTelepIn1 = _telep1;
        movingPlataform1 = movePlat1;
    }

    // Update is called once per frame
    void Update()
    {
        bool shallLaunchFunc = true;
        timming = Time.timeSinceLevelLoad - Time.deltaTime;
        movingPlataform1.transform.Translate((Time.deltaTime * direction) * velocity, 0, 0);
        if (Mathf.RoundToInt(Time.timeSinceLevelLoad) % 3 == 0 && shallLaunchFunc) {
           direction *= -1;
           // shallLaunchFunc = !shallLaunchFunc;
            //Debug.Log(Time.timeSinceLevelLoad);
            ///Time.deltaTime = 0;
        }
        if (Mathf.RoundToInt(Time.timeSinceLevelLoad) % 3 == 1 && !shallLaunchFunc)
        {
            shallLaunchFunc = !shallLaunchFunc;
        }






    }
}   
