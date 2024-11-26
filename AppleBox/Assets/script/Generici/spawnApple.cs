using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnApple : MonoBehaviour
{
    public GameObject melaPrefab;
    public float asseY = 0.3f;
    public int lvlCount;
    // Start is called before the first frame update
    void Start()
    {
        lvlCount = gameHandler.Plevel;
        Debug.Log("lvlcount: " + lvlCount);
        playerLevelStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playerLevelStart()
    {
        switch (lvlCount)
        {
            case 1: 
                for (int i = 0; i <= 4; i++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(-110, -160), 0.30f, Random.Range(-5, 32));
                    Instantiate(melaPrefab, randomSpawnPosition, Quaternion.identity);
                }
                break;
            case 2 :
                for (int i = 0; i <= 9; i++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(-110, -160), 0.30f, Random.Range(-37, 67));
                    Instantiate(melaPrefab, randomSpawnPosition, Quaternion.identity);
                }
                break;
            default:
                for (int i = 0; i <= 7; i++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(-110, -160), 0.30f, Random.Range(-5, 32));
                    Instantiate(melaPrefab, randomSpawnPosition, Quaternion.identity);
                }

                break;
                
        }
    }
}
