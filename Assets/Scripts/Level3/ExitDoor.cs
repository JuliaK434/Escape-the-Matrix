using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private TMP_Text notEnoughStarsText; 
    [SerializeField] private TMP_Text exitHintText; 
    [SerializeField] private float messageDisplayTime = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (StarManager.Instance.GetCollectedStars() >= StarManager.Instance.GetTotalStars())
            {
                exitHintText.gameObject.SetActive(false);
                SceneManager.LoadScene("Level3_Fredge");
                AchievementManager.Instance.UnlockAchievement("Achievement3");
            }
            else
            {
                ShowNotEnoughStarsMessage();
            }
        }
    }

    private void ShowNotEnoughStarsMessage()
    {
        notEnoughStarsText.gameObject.SetActive(true);
        Invoke("HideNotEnoughStarsMessage", messageDisplayTime);
    }

    private void HideNotEnoughStarsMessage()
    {
        notEnoughStarsText.gameObject.SetActive(false);
    }
}