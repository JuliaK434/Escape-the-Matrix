using UnityEngine;

public class Sofa : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E; // ������� ��� ��������������
    public GameObject sitPrompt; // ��������� "����� E"

    private bool canInteract = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerInteraction3>().hasPhone)
        {
            canInteract = true;
            sitPrompt.SetActive(true); // ���������� ���������
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            sitPrompt.SetActive(false); // �������� ���������
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(interactKey))
        {
            
            Debug.Log("����� ��� �� ����� � ������ � �������! ����� ��������.");
            // ����� ����� �������� ���������� ������
        }
    }
}