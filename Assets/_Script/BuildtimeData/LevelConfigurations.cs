using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfiguration", menuName = "AppleBox/LevelConfiguration")]
public class LevelConfiguration : ScriptableObject
{
    public int levelId;
    public int appleToSpawn;
    public int appleToCollect;
}