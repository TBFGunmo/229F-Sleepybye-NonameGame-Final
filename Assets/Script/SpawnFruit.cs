using System.Collections;
using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    public GameObject[] fruitPrefabs;

    public Transform spawnLevel;
    public Transform spawnXStart;
    public Transform spawnXEnd;

    public bool startSpawn = true;
    //public bool endGame = false;
    
    private float currentTime = 0;
    private float delaySpawn = 4;

    private Coroutine fruitSpawnRoutine;


    public bool activeGun1 = false;
    public bool activeGun2 = false;
    public bool activeGun3 = false;
    public bool activeGun4 = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fruitSpawnRoutine = StartCoroutine("SpawnFruitsSystem");
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void SpawnFruits() 
    {
        int fruitType = Random.Range(0, 5);

        var go = fruitPrefabs[fruitType];

        if (go) 
        {
            var randomX = Random.Range(spawnXStart.position.x, spawnXEnd.position.x);
            var spawnPos = new Vector2(randomX, spawnLevel.position.y);
            Instantiate(go, spawnPos, Quaternion.identity);
        }

    }

    private IEnumerator SpawnFruitsSystem() 
    {
        while (!GameManager.gameOver)
        {
            if (startSpawn)
            {
                SpawnFruits();
                yield return new WaitForSeconds(delaySpawn);
                currentTime += delaySpawn;

                if (currentTime >= 30)
                {
                    delaySpawn = 1;
                    activeGun4 = true;
                }
                else if (currentTime >= 25)
                {
                    delaySpawn = 2;
                    activeGun3 = true;
                }
                else if (currentTime >= 20)
                {
                    delaySpawn = 2;
                    activeGun2 = true;
                }
                else if (currentTime >= 10)
                {
                    delaySpawn = 3;
                    activeGun1 = true;
                }
            }
            yield return null;
        }
       
    }

}
