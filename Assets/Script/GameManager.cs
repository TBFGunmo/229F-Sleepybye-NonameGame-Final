using TMPro;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool gameOver = false;


    public static int playerHP = 3;


    public static int Score = 0;
    private bool completeGameOver = false;

    private InputAction ESC;
    public GameObject pauseUI;

    public GameObject GameOverUI;
    public TMP_Text ScoreEnd;

    public GameObject CreditUI;

    public GameObject StatusBar;
    public TMP_Text ScoreShow;
    public GameObject HP5;
    public GameObject HP4;
    public GameObject HP3;
    public GameObject HP2;
    public GameObject HP1;

    public GameObject tutorialUI;







    private void Awake()
    {
        instance = this;
        Score = 0;
        gameOver = false;
        playerHP = 3;

        ESC = InputSystem.actions.FindAction("Cancel");

        pauseUI.SetActive(false);
        GameOverUI.SetActive(false);
        CreditUI.SetActive(false);
        StatusBar.SetActive(false);

        Time.timeScale = 0f;
        tutorialUI.SetActive(true);

    }

    



    // Update is called once per frame
    void Update()
    {
        if (ESC.WasPressedThisFrame())
        {
            PauseGame();
        }

        if (playerHP <= 0 && HP1.activeSelf) 
        {
            HP1.SetActive(false);
        }
        else if (playerHP <= 1 && HP2.activeSelf)
        {
            HP2.SetActive(false);
        }
        else if (playerHP <= 2 && HP3.activeSelf)
        {
            HP3.SetActive(false);
        }
        else if (playerHP <= 3 && HP4.activeSelf)
        {
            HP4.SetActive(false);
        }
        else if (playerHP <= 4 && HP5.activeSelf)
        {
            HP5.SetActive(false);
        }

        if (ScoreShow.IsActive())
        {
            ScoreShow.text = $"Score : {Score}";
        }


        if (gameOver && !completeGameOver) 
        {
            completeGameOver = true;
            GameOver();
        }

    }


    public void StartGame()
    {
        StatusBar.SetActive(true);
        Time.timeScale = 1f;
        tutorialUI.SetActive(false);
    }

    public void PauseGame()
    {
        StatusBar.SetActive(false);
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void ResumeGame()
    {
        StatusBar.SetActive(true);
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }


    public void GameOver() 
    {
        StatusBar.SetActive(false);
        ScoreEnd.text = $"Your Score : {Score} ";

        Time.timeScale = 0f;
        GameOverUI.SetActive(true);

    }

    public void ReStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CreditOpen() 
    {
        CreditUI.SetActive(true);
    }

    public void CreditClose()
    {
        CreditUI.SetActive(false);
    }

    public void BackToMenu() 
    {
        //SceneManager.LoadScene("MainMenu");
    }

}
