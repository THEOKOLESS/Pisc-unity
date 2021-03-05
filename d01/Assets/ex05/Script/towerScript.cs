using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex05
{
    public class towerScript : MonoBehaviour
    {
        [SerializeField] private GameObject shoot;
        [SerializeField] private float timer;

        void Update()
        {
            if (gameObject.CompareTag("yellowTower")){
                shoot.GetComponent<SpriteRenderer>().color = new Color(0.7058824f, 0.6117647f, 0.2196079f);
                shoot.layer = 10;
            }
            else if (gameObject.CompareTag("blueTower")){
                shoot.GetComponent<SpriteRenderer>().color = new Color(0.145098f, 0.2392157f, 372549f);
                shoot.layer = 8;
            }
            else if (gameObject.CompareTag("redTower")){
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
}
