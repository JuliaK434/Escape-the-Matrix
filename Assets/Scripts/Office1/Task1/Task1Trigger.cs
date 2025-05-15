using UnityEngine;
using UnityEngine.SceneManagement;

public class Task1Trigger : MonoBehaviour
{
    public string SceneName = "Task1";

    void Update()
    {
        if (_nearTrigger && Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.SetString("ReturnScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(SceneName);
        }
    }

    private bool _nearTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _nearTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _nearTrigger = false;
        }
    }
}