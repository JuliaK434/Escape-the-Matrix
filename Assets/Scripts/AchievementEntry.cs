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

        // ��� ��������� ����������
        if (data.isSecret && !isUnlocked)
        {
            gameObject.SetActive(false);
            return;
        }

        // ��� �������
        icon.sprite = isUnlocked ?
            data.unlockedIcon :
            AchievementManager.Instance.commonLockedIcon;

        lockedLabel.gameObject.SetActive(!isUnlocked);
        secretOverlay.SetActive(false);
    }
}