using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static int Plevel;
    
    void Start()
    {
        Debug.Log("PlayerPrefs.HasKey('PlayerLevel'): " + PlayerPrefs.HasKey("PlayerLevel"));
        Debug.Log("plevel: " + Plevel);

        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            Plevel = PlayerPrefs.GetInt("PlayerLevel");
        }
        else
        {
            PlayerPrefs.SetInt("PlayerLevel", 0);
            Plevel = 0;
        }
    }
}
