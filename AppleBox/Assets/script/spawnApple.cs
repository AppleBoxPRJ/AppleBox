using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class spawnApple : MonoBehaviour
{
    public GameObject melaPrefab;
    public float asseY = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 15; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-110, -160), 0.30f, Random.Range(-5, 32));
            Instantiate(melaPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
