using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMoves : MonoBehaviour
{
    [SerializeField]    private float velocity;
    [SerializeField]    Vector3 direciton;
    [SerializeField]    float timing;

    private int changeDir;
    private float timingCheck;
    // Start is called before the first frame update
    void Start()
    {
        timingCheck = 0;
        changeDir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name != "DoorBlueSprite" || playerScript_ex04.blueDoor1 == true)
        {
            transform.Translate((direciton * Time.deltaTime * changeDir) * velocity);

            if (timingCheck >= timing)
            {
                changeDir *= -1;
                timingCheck = 0;
            }
            timingCheck += Time.deltaTime;
        }
    }
   
}
