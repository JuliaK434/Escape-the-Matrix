using UnityEngine;
using UnityEngine.UI;

public class AchievementEntry : MonoBehaviour
{
    [Header("References")]
    public Image icon;
    public Text lockedLabel;
    public GameObject secretOverlay;

    public void Initialize(AchievementData data)
    {
        bool isUnlocked = AchievementManager.Instance.IsAchievementUnlocked(data.id);

        // Для секретных достижений
        if (data.isSecret && !isUnlocked)
        {
            gameObject.SetActive(false);
            return;
        }

        // Для обычных
        icon.sprite = isUnlocked ?
            data.unlockedIcon :
            AchievementManager.Instance.commonLockedIcon;

        lockedLabel.gameObject.SetActive(!isUnlocked);
        secretOverlay.SetActive(false);
    }
}