using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction2_1 : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    private bool isNearComputer = false;
    
    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            if (isNearComputer)
            {
                SceneManager.LoadScene("Computer_level2");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Computer"))
        {
            isNearComputer = true;
            Debug.Log("Вошел в зону компьютера"); // Для отладки
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Computer"))
        {
            isNearComputer = false;
            Debug.Log("Вышел из зоны компьютера"); // Для отладки
        }
    }
}