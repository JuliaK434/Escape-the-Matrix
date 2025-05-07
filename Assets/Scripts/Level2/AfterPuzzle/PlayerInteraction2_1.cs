using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction2_1 : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    private BookPuzzleTrigger currentBookTrigger;

    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            if (currentBookTrigger != null && currentBookTrigger.CanInteractWithBook())
            {
                SceneManager.LoadScene("Computer_level2");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Computer"))
        {
            currentBookTrigger = other.GetComponent<BookPuzzleTrigger>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Computer"))
        {
            currentBookTrigger = null;
        }
    }
}

