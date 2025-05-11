using UnityEngine;

public class ClutteredSofa : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public GameObject cleanSofa;
    public GameObject[] clutterItems;
    public GameObject sitPrompt;
    public GameObject playPhonePrompt;

    private bool canInteract = false;
    private bool isCleaned = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            if (!isCleaned) sitPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            sitPrompt.SetActive(false);
            playPhonePrompt.SetActive(false);
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(interactKey))
        {
            if (!isCleaned)
            {
                CleanUp();
            }
            else if (FindAnyObjectByType<PlayerInteraction3>().hasPhone)
            {
                SitAndPlay();
            }
        }
    }

    private void CleanUp()
    {
        foreach (var item in clutterItems)
        {
            if (item != null)
            {
                item.SetActive(false);
            }
        }
        cleanSofa.SetActive(true);
        isCleaned = true;
        sitPrompt.SetActive(false);
    }

    private void SitAndPlay()
    {
        Debug.Log("Игрок играет в телефон!");
    }
}