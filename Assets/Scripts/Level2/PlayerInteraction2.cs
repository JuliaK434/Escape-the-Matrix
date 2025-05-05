using UnityEngine;

public class PlayerInteraction2 : MonoBehaviour
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
                // Проверяем, что Instance существует
                if (PuzzleManager2.Instance == null)
                {
                    Debug.LogError("PuzzleManager2.Instance is NULL! Проверьте:");
                    Debug.LogError("- Добавлен ли PuzzleManager2 на сцену?");
                    Debug.LogError("- Активен ли он?");
                    return;
                }
                PuzzleManager2.Instance.OpenPuzzle();
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