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
    private float delaySpawn = 2;

    private Coroutine fruitSpawnRoutine;


    public Cannon activeGun1 ;
    public Cannon activeGun2 ;
    public Cannon activeGun3 ;
    public Cannon activeGun4 ;



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

                if (currentTime >= 40)
                {
                    delaySpawn = 0.5f;
                    activeGun4.sendActive = true;
                }
                else if (currentTime >= 30)
                {
                    delaySpawn = 1;
                    activeGun3.sendActive = true;
                }
                else if (currentTime >= 20)
                {
                    delaySpawn = 2;
                    activeGun2.sendActive = true;
                }
                else if (currentTime >= 10)
                {
                    delaySpawn = 2.5f;
                    activeGun1.sendActive = true;
                }
            }
            yield return null;
        }
       
    }

}
