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

    }

    



    // Update is called once per frame
    void Update()
    {
        if (ESC.WasPressedThisFrame())
        {
            PauseGame();
        }

        if (gameOver && !completeGameOver) 
        {
            completeGameOver = true;
            GameOver();
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }


    public void GameOver() 
    {
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
