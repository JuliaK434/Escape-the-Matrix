using UnityEngine;
using UnityEngine.UI;

public class CloseAchievements : MonoBehaviour
{
    public GameObject achievementPanel;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            achievementPanel.SetActive(false);
        });
    }
}