using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApple : MonoBehaviour
{
    public GameObject melaPrefab;
    public float asseY = 0.3f;
    public int lvlCount;

    private void Start()
    {
        lvlCount = GameHandler.Plevel;
        PlayerLevelStart();
        
    }

    private void PlayerLevelStart()
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
                break;
        }
    }
}
