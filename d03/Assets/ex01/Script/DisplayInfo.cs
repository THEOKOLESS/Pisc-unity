using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DisplayInfo : MonoBehaviour
{
   
    [SerializeField] TextMeshProUGUI textHP;
    [SerializeField] TextMeshProUGUI textEnergy;

  
    void Update()
    {
        textHP.SetText(gameManager.gm.playerHp + "");
        textEnergy.SetText(gameManager.gm.playerEnergy + "");
    }
}
