using UnityEngine;
using TMPro;

public class StarManager : MonoBehaviour
{
    public static StarManager Instance;

    [SerializeField] private int totalStars;
    private int collectedStars = 0;

    [SerializeField] private GameObject exitDoor; // Объект выхода (изначально неактивен)
    [SerializeField] private TMP_Text starsText; // Текст счётчика звёзд
    [SerializeField] private TMP_Text exitHintText; // Новое поле для "Пора на выход!"

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateStarsUI();
        exitHintText.gameObject.SetActive(false); // Скрываем подсказку в начале
    }

    public void CollectStar()
    {
        collectedStars++;
        UpdateStarsUI();
        CheckAllStarsCollected();
    }

    private void CheckAllStarsCollected()
    {
        if (collectedStars >= totalStars)
        {
            exitDoor.SetActive(true); // Активируем выход
            exitHintText.gameObject.SetActive(true); // Показываем подсказку
            Debug.Log("Все звёзды собраны! Выход открыт.");
        }
    }

    private void UpdateStarsUI()
    {
        if (starsText != null)
            starsText.text = $"Stars: {collectedStars}/{totalStars}";
    }

    public int GetTotalStars() => totalStars;
    public int GetCollectedStars() => collectedStars;
}