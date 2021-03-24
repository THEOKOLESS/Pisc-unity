using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuPause : MonoBehaviour
{
    private bool pause = false;
    public GameObject pauseMenuUI;
    public GameObject exitMenuUI;
    public GameObject pausedMenuUI;
    public GameObject GameOverUI;
    public GameObject GameOverWinUI;
    public GameObject GameOverLostUI;

    private bool resumeButton = false;
    [SerializeField] private TextMeshProUGUI scoreLostText;
    [SerializeField] private TextMeshProUGUI scoreWinText;
    [SerializeField] private TextMeshProUGUI rankText;
    private int hpPerCent;
    private string rank;
    private int finalScore;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if ((!GameOverUI.activeSelf && (Input.GetKeyDown(KeyCode.Escape) || resumeButton == true)))
        {
            pause = !pause;
            resume();
            resumeButton = false;
            gameManager.gm.pause(pause);
            pauseMenuUI.SetActive(pause);
        }

        if (gameManager.gm.playerHp <= 0)
        {
            GameOverUI.SetActive(true);
            GameOverLostUI.GetComponent<CanvasGroup>().alpha = 1f;
            GameOverLostUI.GetComponent<CanvasGroup>().interactable = true;
            GameOverLostUI.GetComponent<CanvasGroup>().blocksRaycasts = true;


            GameOverWinUI.GetComponent<CanvasGroup>().alpha = 0f;
            GameOverWinUI.GetComponent<CanvasGroup>().interactable = false;
            GameOverWinUI.GetComponent<CanvasGroup>().blocksRaycasts = false;

            scoreLostText.SetText("Score : "  + gameManager.gm.score + "");
        }

        if (checkLastEnemy())
        {
            GameOverUI.SetActive(true);


            GameOverWinUI.GetComponent<CanvasGroup>().alpha = 1f;
            GameOverWinUI.GetComponent<CanvasGroup>().interactable = true;
            GameOverWinUI.GetComponent<CanvasGroup>().blocksRaycasts = true;


            GameOverLostUI.GetComponent<CanvasGroup>().alpha = 0f;
            GameOverLostUI.GetComponent<CanvasGroup>().interactable = false;
            GameOverLostUI.GetComponent<CanvasGroup>().blocksRaycasts = false;

            scoreWinText.SetText("Score : " + gameManager.gm.score + "");
            rankText.SetText("Rank : " + rank);
            //Debug.Log(finalScore);

        }

    }

    bool checkLastEnemy()
    {
        if (gameManager.gm.lastWave == true)
        {
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("spawner");
            foreach (GameObject spawner in spawners)
            {
                if (spawner.GetComponent<ennemySpawner>().isEmpty == false || spawner.transform.childCount > 0)
                {
                    return false;
                }
            }
            hpPerCent = (gameManager.gm.playerHp * 100) / gameManager.gm.playerMaxHp;
            finalScore = ((gameManager.gm.playerEnergy / 100) * 5) + hpPerCent;
            switch (finalScore)
            {
                case int n when n >= 150:
                    rank = "Dark Mage";
                    break;
                case int n when n >= 100:
                    rank = "Daughter of death";
                    break;
                case int n when n >= 75:
                    rank = "Slayer of lies";
                    break;
                case int n when n >= 50:
                    rank = "Breaker of chains";
                    break;
                default:
                    rank = "Protector of the protecting shield";
                    break;
            }
            return true;
        }
        return false;
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
        if (!pauseMenuUI.activeSelf)
        {
            pauseMenuUI.SetActive(true);
        }
        pausedMenuUI.GetComponent<CanvasGroup>().alpha = 0;
        pausedMenuUI.GetComponent<CanvasGroup>().interactable = false;
        pausedMenuUI.GetComponent<CanvasGroup>().blocksRaycasts = false;

        GameOverUI.GetComponent<CanvasGroup>().alpha = 0;
        GameOverUI.GetComponent<CanvasGroup>().interactable = false;
        GameOverUI.GetComponent<CanvasGroup>().blocksRaycasts = false;

        exitMenuUI.GetComponent<CanvasGroup>().alpha = 1f;
        exitMenuUI.GetComponent<CanvasGroup>().interactable = true;
        exitMenuUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void YesIam()
    {
        SceneManager.LoadScene("ex00");
    }

    public void ILost()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
