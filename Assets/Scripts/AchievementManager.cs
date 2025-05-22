using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public List<AchievementData> achievements = new List<AchievementData>();
    private Dictionary<string, AchievementData> achievementsDict = new Dictionary<string, AchievementData>();
    public static AchievementManager Instance;
    public event Action<string> OnAchievementUnlocked;
    public Sprite commonLockedIcon; // Серая базовая иконка
    public GameObject notificationPrefab;

    void Start()
    {
        if (notificationPrefab == null)
        {
            notificationPrefab = Resources.Load<GameObject>("NotificationPrefab");
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAchievements(); // Инициализация всех достижений
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LoadAchievements()
    {
        // Создаем ключи для ВСЕХ достижений при первом запуске
        for (int i = 1; i <= 9; i++)
        {
            string key = "Achievement" + i;
            if (!PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.SetInt(key, 0); // 0 = не разблокировано
            }
        }

        // Автоматическая разблокировка первого достижения
        if (PlayerPrefs.GetInt("Achievement1", 0) == 0)
        {
            UnlockAchievement("Achievement1");
        }

        PlayerPrefs.Save(); // Сохраняем инициализацию
    }

    public void UnlockAchievement(string achievementId)
    {
        PlayerPrefs.SetInt(achievementId, 1);
        PlayerPrefs.Save(); // Сохраняем сразу
        OnAchievementUnlocked?.Invoke(achievementId); // Вызов события
    }

    public AchievementData GetAchievementData(string achievementId)
    {
        return achievementsDict.ContainsKey(achievementId) ?
               achievementsDict[achievementId] :
               null;
    }

    public bool IsAchievementUnlocked(string achievementId)
    {
        return PlayerPrefs.GetInt(achievementId, 0) == 1;
    }
}