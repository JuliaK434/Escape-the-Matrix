using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public GameObject puzzleMenu;
    private WardrobeTrigger currentWardrobe;

    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            if (currentWardrobe != null && currentWardrobe.CanInteract())
            {
                if (PuzzleManager.Instance != null)
                {
                    PuzzleManager.Instance.OpenPuzzle();
                }
                else
                {
                    Debug.LogError("PuzzleManager.Instance is NULL!");
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wardrobe"))
        {
            currentWardrobe = other.GetComponent<WardrobeTrigger>();
            Debug.Log("Вошел в зону шкафа");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wardrobe"))
        {
            currentWardrobe = null;
            Debug.Log("Вышел из зоны шкафа");
        }
    }

    
}