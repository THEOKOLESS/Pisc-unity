using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScript : MonoBehaviour
{
    private Scene currentScene;
    private string sceneName;

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (Input.GetKeyDown("r"))
        { 
            SceneManager.LoadScene(sceneName); 
        }
        else if(playerScript_ex05.gameOver == true){
            SceneManager.LoadScene(sceneName);
        } 
    }
}
