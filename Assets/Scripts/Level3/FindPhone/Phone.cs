using UnityEngine;

public class Phone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteraction3>().hasPhone = true; // Игрок подобрал телефон
            Destroy(gameObject); // Удаляем телефон со сцены
            Debug.Log("Телефон найден! Подойди к дивану и нажми E.");
        }
    }
}