using UnityEngine;
using UnityEngine.SceneManagement;

public class Sofa : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E; // Клавиша для взаимодействия
    public GameObject sitPrompt; // Подсказка "Нажми E"

    private bool canInteract = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerInteraction3>().hasPhone)
        {
            canInteract = true;
            sitPrompt.SetActive(true); // Показываем подсказку
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            sitPrompt.SetActive(false); // Скрываем подсказку
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(interactKey))
        {

            SceneManager.LoadScene("Maze");
        }
    }
}