using UnityEngine;
using UnityEngine.UI;

public class AchievementPanelManager : MonoBehaviour
{
    [Header("References")]
    public GameObject achievementTemplate;
    public Transform contentParent;

    void Start()
    {
        GenerateAchievementEntries();
    }

    void GenerateAchievementEntries()
    {
        foreach (var achievement in AchievementManager.Instance.achievements)
        {
            // ѕропускаем секретные незаблокированные
            if (achievement.isSecret &&
              !AchievementManager.Instance.IsAchievementUnlocked(achievement.id))
            {
                continue;
            }

            var entry = Instantiate(achievementTemplate, contentParent);
            entry.GetComponent<AchievementEntry>().Initialize(achievement);
            entry.SetActive(true);
        }
    }
}