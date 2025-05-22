using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotificationPopup : MonoBehaviour
{
    public Image icon;
    public TMP_Text titleText;
    public TMP_Text descriptionText;

    public void Show(Sprite icon, string title, string description)
    {
        this.icon.sprite = icon;
        titleText.text = title;
        descriptionText.text = description;
    }
}