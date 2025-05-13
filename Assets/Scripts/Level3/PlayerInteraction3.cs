using UnityEngine;

public class PlayerInteraction3 : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public GameObject puzzleMenu;
    private WardrobeTrigger currentWardrobe;
    public bool hasPhone = false;
    public bool isNearSofa = false;
    public static bool hasBone = false;
    public static string selectedFood = "";
    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            if (currentWardrobe != null && currentWardrobe.CanInteract())
            {
                if (PuzzleManager3.Instance == null)
                {
                    return;
                }
                PuzzleManager3.Instance.OpenPuzzle();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wardrobe"))
        {
            currentWardrobe = other.GetComponent<WardrobeTrigger>();;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wardrobe"))
        {
            currentWardrobe = null;
            
        }
    }


}