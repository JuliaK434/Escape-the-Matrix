using UnityEngine;
using UnityEngine.UI;

public class NotificationHandler : MonoBehaviour
{
    public Image achievementIcon;
    public Text notificationText;

    public void ShowNotification(AchievementData data)
    {
        achievementIcon.sprite = data.unlockedIcon;
        notificationText.text = $"<b>{data.title}</b>\n{data.description}";
        GetComponent<Animator>().Play("NotificationAnim");
    }
}