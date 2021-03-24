using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    private bool pause = false;
    public GameObject pauseMenuUI;
    public GameObject exitMenuUI;
    public GameObject pausedMenuUI;

    private bool resumeButton = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || resumeButton == true)
        {
            pause = !pause;
            resume();
            resumeButton = false;
            gameManager.gm.pause(pause);
            pauseMenuUI.SetActive(pause);
        }
    }

    public void resume()
    {
        resumeButton = true;

        pausedMenuUI.GetComponent<CanvasGroup>().alpha = 1f;
        pausedMenuUI.GetComponent<CanvasGroup>().interactable = true;
        pausedMenuUI.GetComponent<CanvasGroup>().blocksRaycasts = true;

        exitMenuUI.GetComponent<CanvasGroup>().alpha = 0f;
        exitMenuUI.GetComponent<CanvasGroup>().interactable = false;
        exitMenuUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void ExitGame() 
    {
        pausedMenuUI.GetComponent<CanvasGroup>().alpha = 0;
        pausedMenuUI.GetComponent<CanvasGroup>().interactable = false;
        pausedMenuUI.GetComponent<CanvasGroup>().blocksRaycasts = false;

        exitMenuUI.GetComponent<CanvasGroup>().alpha = 1f;
        exitMenuUI.GetComponent<CanvasGroup>().interactable = true;
        exitMenuUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void YesIam()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    
}
