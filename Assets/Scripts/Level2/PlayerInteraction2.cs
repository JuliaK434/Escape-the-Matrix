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
                // ���������, ��� Instance ����������
                if (PuzzleManager2.Instance == null)
                {
                    Debug.LogError("PuzzleManager2.Instance is NULL! ���������:");
                    Debug.LogError("- �������� �� PuzzleManager2 �� �����?");
                    Debug.LogError("- ������� �� ��?");
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
            Debug.Log("����� � ���� �����");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wardrobe"))
        {
            currentWardrobe = null;
            Debug.Log("����� �� ���� �����");
        }
    }


}