using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction2 : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    private BookPuzzleTrigger currentBookTrigger;

    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            if (currentBookTrigger != null && currentBookTrigger.CanInteractWithBook())
            {
                SceneManager.LoadScene("Puzzle_level2");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Book"))
        {
            currentBookTrigger = other.GetComponent<BookPuzzleTrigger>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Book"))
        {
            currentBookTrigger = null;
        }
    }
}