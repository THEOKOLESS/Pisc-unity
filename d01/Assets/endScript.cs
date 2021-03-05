using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScript : MonoBehaviour
{

    private Scene currentScene;
    private string sceneName;
 
  
  
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

             
       if(playerScript_ex01.flag_blue == 1 && playerScript_ex01.flag_red == 1 && playerScript_ex01.flag_yellow == 1 && sceneName == "ex01"){
            SceneManager.LoadScene("ex02");
        }
        else if(playerScript_ex02.flag_blue == 1 && playerScript_ex02.flag_red == 1 && playerScript_ex02.flag_yellow == 1 && sceneName == "ex02"){
            SceneManager.LoadScene("ex03");
        }
        else if(playerScript_ex03.flag_blue == 1 && playerScript_ex03.flag_red == 1 && playerScript_ex03.flag_yellow == 1 && sceneName == "ex03"){
            SceneManager.LoadScene("ex04");
        }
        else if(playerScript_ex04.flag_blue == 1 && playerScript_ex04.flag_red == 1 && playerScript_ex04.flag_yellow == 1 && sceneName == "ex04"){
            SceneManager.LoadScene("ex05");
        }
        else if (playerScript_ex05.flag_blue == 1 && playerScript_ex05.flag_red == 1 && playerScript_ex05.flag_yellow == 1)
        {
            Debug.Log("gg wp!");
        }
    }


}

