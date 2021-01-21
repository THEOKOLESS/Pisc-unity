using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScript : MonoBehaviour
{
    private Scene currentScene;
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (Input.GetKeyDown("r"))
        { //If you press R
            SceneManager.LoadScene(sceneName); //Load scene called Game
        }
    }
}
