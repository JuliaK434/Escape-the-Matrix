using UnityEngine;
using TMPro;

public class WardrobeTrigger : MonoBehaviour
{
    private bool isPlayerNear = false;
    public TextMeshProUGUI pressEText; 

    private void Start()
    {
        if (pressEText != null)
        {
            pressEText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (pressEText != null)
            {
                pressEText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (pressEText != null)
            {
                pressEText.gameObject.SetActive(false);
            }
        }
    }

    public bool CanInteract()
    {
        return isPlayerNear;
    }
}