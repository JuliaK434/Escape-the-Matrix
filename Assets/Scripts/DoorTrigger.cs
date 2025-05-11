using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Collider2D))]
public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private TextMeshProUGUI hintText;
    [SerializeField] private float hintDuration = 2f;
    
    private bool isLocked = true;
    private float hintTimer = 0f;

    public void UnlockDoor()
    {
        isLocked = false;
    }
    private void Update()
    {
        if (hintTimer > 0)
        {
            hintTimer -= Time.deltaTime;
            if (hintTimer <= 0)
            {
                hintText.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isLocked)
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                ShowHint();
            }
        }
    }
    private void ShowHint()
    {
        if (hintText != null)
        {
            hintText.text = "Закончи все задания на этой локации";
            hintText.gameObject.SetActive(true);
            hintTimer = hintDuration;
        }
    }


}