using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private TMP_Text notEnoughStarsText; // "Собери все звёзды!"
    [SerializeField] private TMP_Text exitHintText; // "Пора на выход!"
    [SerializeField] private float messageDisplayTime = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (StarManager.Instance.GetCollectedStars() >= StarManager.Instance.GetTotalStars())
            {
                // Все звёзды собраны — скрываем подсказку и загружаем уровень
                exitHintText.gameObject.SetActive(false);
                SceneManager.LoadScene("NextLevel");
            }
            else
            {
                // Звёзд не хватает — показываем сообщение
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