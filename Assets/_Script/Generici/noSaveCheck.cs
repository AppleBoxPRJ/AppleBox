using UnityEngine;
using UnityEngine.UI;

public class NoSaveCheck : MonoBehaviour
{
    public GameObject continueButton;

    private void Update()
    {
        continueButton.GetComponent<Button>().interactable = GameHandler.Plevel != 0;
    }
}
