using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TowerInfo : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    //private towerScript towerScript;
    [SerializeField] TextMeshProUGUI textDmg;
    [SerializeField] TextMeshProUGUI textRange;
    [SerializeField] TextMeshProUGUI textPrice;
    [SerializeField] TextMeshProUGUI textFireRate;
    // Start is called before the first frame update
    void Start()
    {
        textDmg.SetText(tower.GetComponent<towerScript>().damage + "");
        textRange.SetText(tower.GetComponent<towerScript>().range + "");
        textPrice.SetText(tower.GetComponent<towerScript>().energy + "");
        textFireRate.SetText(tower.GetComponent<towerScript>().fireRate + "");
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(towerScript.damage);
    }
}
