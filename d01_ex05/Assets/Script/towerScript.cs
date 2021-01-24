using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{
    [SerializeField] private GameObject shoot;
    [SerializeField] private float timer;
    // Start is called before the first frame update
    void Start()
    {
   
       
    }

    // Update is called once per frame
    void Update()
    {
         if (gameObject.CompareTag("yellowTower")){
            Debug.Log("yellow");
             shoot.GetComponent<SpriteRenderer>().color = new Color(0.7058824f, 0.6117647f, 0.2196079f);
             shoot.layer = 10;
        }
        else if (gameObject.CompareTag("blueTower")){
            Debug.Log("blue");
             shoot.GetComponent<SpriteRenderer>().color = new Color(0.145098f, 0.2392157f, 372549f);
             shoot.layer = 8;
        }
        else if (gameObject.CompareTag("redTower")){
            Debug.Log("red");
            shoot.GetComponent<SpriteRenderer>().color = new Color(0.8392158f, 0.2705882f, 0.2588235f);
            shoot.layer = 9;
        }
        if(timer >=3){
            timer = 0;
            GameObject.Instantiate(shoot, gameObject.transform.localPosition, Quaternion.identity);
        }
        timer += Time.deltaTime;
    }
}
