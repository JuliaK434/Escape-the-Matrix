using UnityEngine;
using UnityEngine.UI;

public class AchievementButton : MonoBehaviour
{
    public GameObject achievementPanel;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            achievementPanel.SetActive(!achievementPanel.activeSelf);
        });
    }
}