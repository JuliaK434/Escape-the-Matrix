using UnityEngine;

public class Phone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteraction3>().hasPhone = true; // ����� �������� �������
            Destroy(gameObject); // ������� ������� �� �����
            Debug.Log("������� ������! ������� � ������ � ����� E.");
        }
    }
}