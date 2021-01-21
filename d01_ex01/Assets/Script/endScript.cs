using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScript : MonoBehaviour
{
    private int flag;   
    // Start is called before the first frame update
    void Start()
    {
        flag = 0;
    }

    // Update is called once per frame      
    void Update()
    {
        if (playerScript_ex01.flag_blue == 1 && playerScript_ex01.flag_red == 1 && playerScript_ex01.flag_yellow == 1 && flag == 0)
        {
            flag = 1;
            Debug.Log("GG wp");
        }
        else if (flag == 1 && (playerScript_ex01.flag_blue != 1 || playerScript_ex01.flag_red != 1 || playerScript_ex01.flag_yellow != 1))
            flag = 0;
    }




}
