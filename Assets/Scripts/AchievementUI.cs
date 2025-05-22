using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class AchievementUI : MonoBehaviour
{
    public Image achievement1Icon;
    public TMP_Text achievement1Text;
    public Image achievement2Icon;
    public TMP_Text achievement2Text;
    public Image achievement3Icon;
    public TMP_Text achievement3Text;
    public Image achievement4Icon;
    public TMP_Text achievement4Text;
    public Image achievement5Icon;
    public TMP_Text achievement5Text;
    public Image achievement6Icon;
    public TMP_Text achievement6Text;
    public Image achievement7Icon;
    public TMP_Text achievement7Text;
    public Image achievement8Icon;
    public TMP_Text achievement8Text;


    void OnEnable()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        bool unlocked = AchievementManager.Instance.IsAchievementUnlocked("Achievement1");
        achievement1Icon.color = unlocked ? Color.white : Color.gray;
        achievement1Text.gameObject.SetActive(!unlocked);
        bool unlocked2 = AchievementManager.Instance.IsAchievementUnlocked("Achievement2");
        achievement2Icon.color = unlocked2 ? Color.white : Color.gray;
        achievement2Text.gameObject.SetActive(!unlocked2);
        bool unlocked3 = AchievementManager.Instance.IsAchievementUnlocked("Achievement3");
        achievement3Icon.color = unlocked3 ? Color.white : Color.gray;
        achievement3Text.gameObject.SetActive(!unlocked3);
        bool unlocked4 = AchievementManager.Instance.IsAchievementUnlocked("Achievement4");
        achievement4Icon.color = unlocked4 ? Color.white : Color.gray;
        achievement4Text.gameObject.SetActive(!unlocked4);
        bool unlocked5 = AchievementManager.Instance.IsAchievementUnlocked("Achievement5");
        achievement5Icon.color = unlocked5 ? Color.white : Color.gray;
        achievement5Text.gameObject.SetActive(!unlocked5);
        bool unlocked6 = AchievementManager.Instance.IsAchievementUnlocked("Achievement6");
        achievement6Icon.color = unlocked6 ? Color.white : Color.gray;
        achievement6Text.gameObject.SetActive(!unlocked6);
        bool unlocked7 = AchievementManager.Instance.IsAchievementUnlocked("Achievement7");
        achievement7Icon.color = unlocked7 ? Color.white : Color.gray;
        achievement7Text.gameObject.SetActive(!unlocked7);
        bool unlocked8 = AchievementManager.Instance.IsAchievementUnlocked("Achievement8");
        achievement8Icon.color = unlocked8 ? Color.white : Color.gray;
        achievement8Text.gameObject.SetActive(!unlocked8);
    }
}