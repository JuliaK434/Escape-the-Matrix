using UnityEngine;
using TMPro;

public class StarManager : MonoBehaviour
{
    public static StarManager Instance;

    [SerializeField] private int totalStars;
    private int collectedStars = 0;

    [SerializeField] private GameObject exitDoor; // ������ ������ (���������� ���������)
    [SerializeField] private TMP_Text starsText; // ����� �������� ����
    [SerializeField] private TMP_Text exitHintText; // ����� ���� ��� "���� �� �����!"

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
        exitHintText.gameObject.SetActive(false); // �������� ��������� � ������
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
            exitDoor.SetActive(true); // ���������� �����
            exitHintText.gameObject.SetActive(true); // ���������� ���������
            Debug.Log("��� ����� �������! ����� ������.");
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