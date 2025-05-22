using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationSimple : MonoBehaviour
{
    public GameObject notificationPrefab;
    public AchievementData[] achievements;
    public Transform notificationParent;

    void Start()
    {
        AchievementManager.Instance.OnAchievementUnlocked += ShowNotification;
    }

    void ShowNotification(string achievementId)
    {
        var data = System.Array.Find(achievements, a => a.id == achievementId);
        if (data == null) return;

        var notification = Instantiate(notificationPrefab, notificationParent);
        SetupNotification(notification, data);
        Destroy(notification, 3f); // Автоудаление через 3 секунды
    }

    void SetupNotification(GameObject notification, AchievementData data)
    {
        notification.GetComponentInChildren<TextMeshProUGUI>().text = data.title;
        notification.GetComponentsInChildren<Image>()[1].sprite = data.unlockedIcon;
    }
}