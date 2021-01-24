using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entitiesScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static GameObject sTelepIn1;
    [SerializeField] private GameObject _telep1;


    [SerializeField] private GameObject whiteDoor1;
    [SerializeField] private GameObject redDoor1;
    [SerializeField] private GameObject yellowDoor1;
    [SerializeField] private GameObject pushYellow1;
    [SerializeField] private SpriteRenderer facelessSwitch;

    [SerializeField] private GameObject redDoor2;
    [SerializeField] private GameObject blueDoor2;
    [SerializeField] private GameObject yellowDoor2;

     [SerializeField] private GameObject ChangePlatformColor;



    private Vector3 openDoor;

    private Vector3 openWhiteDoor1;
    private Vector3 openRedDoor1;
    private Vector3 openYellowDoor1;
    private Vector3 pushYellow;

    void Start()
    {
        openDoor = new Vector3(0f, -11.95f, 0f);
        sTelepIn1 = _telep1;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (playerScript_ex04.whiteDoor > 0)
        {
            openWhiteDoor1 = new Vector3(-10.65f, -3.77f, 0f);
            if (whiteDoor1.transform.position.y < openWhiteDoor1.y) {
                whiteDoor1.transform.Translate(1 * Time.deltaTime * 1.1f, 0, 0);
            }
        }
        if (playerScript_ex04.whiteDoor == 0)
        {
            openWhiteDoor1 = new Vector3(-10.65f, -5.44f, 0f);
            if (whiteDoor1.transform.position.y > openWhiteDoor1.y)
            {
                whiteDoor1.transform.Translate(-1 * Time.deltaTime * 1.1f, 0, 0);
            }
        }

        if (playerScript_ex04.redDoor1 == true)
        {   
            openRedDoor1 = new Vector3(-21.04f, -5.44f, 0f);
            if (redDoor1.transform.position.x > openRedDoor1.x)
            {
                redDoor1.transform.Translate(-1 * Time.deltaTime * 0.1f,  0, 0);
            }
        }

        if (playerScript_ex04.yellowDoor1 == true)
        {
            openYellowDoor1 = new Vector3(-8.21f, -5.44f, 0f);
            if (yellowDoor1.transform.position.x < openYellowDoor1.x)
            {
                yellowDoor1.transform.Translate(0, -1 * Time.deltaTime * 50f, 0);
                pushYellow1.transform.Translate(1 * Time.deltaTime * 100f, 0, 0);
            }
         }
        else
        {
            openYellowDoor1 = new Vector3(-10.41f, -5.44f, 0f);
            if (yellowDoor1.transform.position.x > openYellowDoor1.x)
            {
                yellowDoor1.transform.Translate(0, 1 * Time.deltaTime * 10f, 0);
                pushYellow1.transform.Translate(-1 * Time.deltaTime * 20f, 0, 0);
            }
        }

 
        if (playerScript_ex04.currentPlayerOnSwitch == 1)
        {
            facelessSwitch.GetComponent<SpriteRenderer>().color = new Color(0.8392158f, 0.2705882f, 0.2588235f);
        
            if(redDoor2.transform.position.y < openDoor.y)
            {
                redDoor2.transform.Translate(1 * Time.deltaTime * 1.1f, 0, 0);
            }
        }
        if (playerScript_ex04.currentPlayerOnSwitch == 2)
        {
            facelessSwitch.GetComponent<SpriteRenderer>().color = new Color(0.7058824f, 0.6117647f, 0.2196079f);
            if (yellowDoor2.transform.position.y < openDoor.y)
            {
               yellowDoor2.transform.Translate(1 * Time.deltaTime * 1.1f, 0, 0);
            }
        }
        if (playerScript_ex04.currentPlayerOnSwitch == 3)
        {
            facelessSwitch.GetComponent<SpriteRenderer>().color = new Color(0.145098f, 0.2392157f, 372549f);
            if (blueDoor2.transform.position.y < openDoor.y)
            {
                blueDoor2.transform.Translate(1 * Time.deltaTime * 1.1f, 0, 0);
            }
        }

        if (playerScript_ex04.switchChangePlatformColorRedYellow == true && playerScript_ex04.playerOnSwitchRedYellow > 1)
        {
            ChangePlatformColor.GetComponent<SpriteRenderer>().color = new Color(0.7058824f, 0.6117647f, 0.2196079f);
             ChangePlatformColor.GetComponent<SpriteRenderer>().sortingOrder = 2;
            ChangePlatformColor.layer = 10;
        }
        else if (playerScript_ex04.switchChangePlatformColorRedYellow == true && playerScript_ex04.playerOnSwitchRedYellow < 2)
        {
            ChangePlatformColor.GetComponent<SpriteRenderer>().color = new Color(0.8392158f, 0.2705882f, 0.2588235f);
             ChangePlatformColor.GetComponent<SpriteRenderer>().sortingOrder = 2;
            ChangePlatformColor.layer = 9;
        }
       else if(playerScript_ex04.playerOnSwitch > 0){
            ChangePlatformColor.GetComponent<SpriteRenderer>().color = new Color(0.145098f, 0.2392157f, 372549f);
             ChangePlatformColor.GetComponent<SpriteRenderer>().sortingOrder = 2;
            ChangePlatformColor.layer = 8;
        }
        else{
            ChangePlatformColor.GetComponent<SpriteRenderer>().sortingOrder = 0;
            ChangePlatformColor.layer = 14;
        }
    }


}   
