using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{

    public GameObject CreditUI;


    private void Awake()
    {
        CreditUI.SetActive(false);
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void CreditOpen()
    {
        CreditUI.SetActive(true);
    }

    public void CreditClose()
    {
        CreditUI.SetActive(false);
    }



}
