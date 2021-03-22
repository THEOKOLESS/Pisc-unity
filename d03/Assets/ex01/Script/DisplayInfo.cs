using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DisplayInfo : MonoBehaviour
{
    //[SerializeField] private GameObject textHP;
    [SerializeField] TextMeshProUGUI textHP;
    [SerializeField] TextMeshProUGUI textEnergy;

    //[SerializeField] private GameObject textEnergy; // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        textHP.SetText(gameManager.gm.playerHp + "");
        textEnergy.SetText(gameManager.gm.playerEnergy + "");
    }
}
