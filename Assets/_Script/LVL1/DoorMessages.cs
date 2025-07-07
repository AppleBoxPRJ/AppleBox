using System.Collections;
using TMPro;
using UnityEngine;

public class DoorMessages : MonoBehaviour, IInteractable
{
    [Header("Components")]
    [SerializeField] private OpenDoor door;
    [Header("Messages")]
    [SerializeField] private TextMeshProUGUI warningText;
    [SerializeField] private TextMeshProUGUI tomorrowText;
    [Header("Values")]
    [SerializeField] private float messageScreenTime = 1.5f;
    
    private int _openingTriesCount;
    private bool _canForceDoor =  true;

    public void Interact()
    {
        if (!_canForceDoor) return;
        
        _canForceDoor = false;
        _openingTriesCount++;
            
        switch (_openingTriesCount)
        {
            case < 3:
                StartCoroutine(ShowMessage(warningText));
                break;
            case 3:
                StartCoroutine(ShowMessage(tomorrowText));
                door.SetDoorMesh(true);
                enabled = false;
                break;
        }
    }

    private IEnumerator ShowMessage(TextMeshProUGUI message)
    {
        message.enabled = true;
        yield return new WaitForSeconds(messageScreenTime);
        message.enabled = false;
        _canForceDoor = true;
    }
}
