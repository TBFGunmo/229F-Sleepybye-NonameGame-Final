using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool gameOver = false;



    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
