using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool gameOver = false;


    public static int playerHP = 5;


    public static int Score = 0;



    private void Awake()
    {
        instance = this;
        Score = 0;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
