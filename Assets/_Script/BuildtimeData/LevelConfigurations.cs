using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfiguration", menuName = "AppleBox/LevelConfiguration")]
public class LevelConfiguration : ScriptableObject
{
    [Space(20)]
    public int levelId;
    
    [Header("Apples")]
    public int appleToSpawn;
    public int appleToCollect;
    public Vector2 appleSpawnRange;
}