using UnityEngine;
using UnityEngine.UI;

public class NoSaveCheck : MonoBehaviour
{
    private Button _continueButton;
    void Start()
    {
        _continueButton = GetComponent<Button>();
        _continueButton.interactable = GameHandler.Plevel != 0;
    }
}