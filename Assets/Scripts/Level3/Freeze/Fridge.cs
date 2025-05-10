using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Добавляем для работы с UI

public class FridgeTrigger : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public GameObject hintText; // Ссылка на UI-текст подсказки
    public float hintDisplayDistance = 2f; // Дистанция для показа подсказки

    private bool canInteract = false;
    private Transform playerTransform;

    private void Start()
    {
        // Находим игрока по тегу
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Скрываем подсказку при старте
        if (hintText != null)
            hintText.SetActive(false);
    }

    private void Update()
    {
        if (canInteract)
        {
            // Показываем подсказку, если игрок достаточно близко
            float distance = Vector2.Distance(transform.position, playerTransform.position);
            if (hintText != null)
                hintText.SetActive(distance <= hintDisplayDistance);

            if (Input.GetKeyDown(interactKey))
            {
                SceneManager.LoadScene("Fredge");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            // Скрываем подсказку при выходе из триггера
            if (hintText != null)
                hintText.SetActive(false);
        }
    }
}