using UnityEngine;

public class SpawnApple : MonoBehaviour
{
    [SerializeField] private GameObject melaPrefab;

    private LevelConfiguration _levelConfiguration;
    
    private void Start()
    {
        _levelConfiguration = BuildtimeData.Instance.LevelConfiguration;
        PlayerLevelStart();
    }

    private void PlayerLevelStart()
    {
        for (int i = 0; i < _levelConfiguration.appleToSpawn; i++)
        {
            var x = Random.Range(-110, -160);
            var y = 0.30f;
            var z = Random.Range(_levelConfiguration.appleSpawnRange.x, _levelConfiguration.appleSpawnRange.y);
            var randomSpawnPosition = new Vector3(x, y, z);
            
            Instantiate(melaPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}
