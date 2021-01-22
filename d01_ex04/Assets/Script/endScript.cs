using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScript : MonoBehaviour
{
    private int flag;
    private Scene currentScene;
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        flag = 0;
    }

    // Update is called once per frame      
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (playerScript_ex04.flag_blue == 1 && playerScript_ex04.flag_red == 1 && playerScript_ex04.flag_yellow == 1 && flag == 0)
        {
            flag = 1;
            if (sceneName == "ex01")
                SceneManager.LoadScene("ex02");
            else if (sceneName == "ex02")
                SceneManager.LoadScene("ex03");
            else if (sceneName == "ex03")
                SceneManager.LoadScene("ex04");
            else
                Debug.Log("gg wp");
        }
        else if (flag == 1 && (playerScript_ex04.flag_blue != 1 || playerScript_ex04.flag_red != 1 || playerScript_ex04.flag_yellow != 1))
            flag = 0;
    }


}
