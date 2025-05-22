using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneSwitchManager : MonoBehaviour
{
    public ComputerController computerSwitch; // Ссылка на скрипт управления компьютером
    public TextMeshProUGUI warningText;   // Текст предупреждения (используйте Text для стандартного UI)
    public float warningDisplayTime = 2f;  // Время отображения предупреждения

    private void Start()
    {
        // Скрываем предупреждение при старте
        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }
    }

    public void TrySwitchScene()
    {
        // Проверяем, выключен ли компьютер
        if (computerSwitch != null && !computerSwitch.IsComputerOn())
        {
            // Если компьютер выключен - переключаем сцену
            SceneManager.LoadScene("Level2_HomeAfterComputer"); 
            AchievementManager.Instance.UnlockAchievement("Achievement5");
        }
        else
        {
            // Если компьютер включен - показываем предупреждение
            ShowWarning();
        }
    }

    private void ShowWarning()
    {
        if (warningText != null)
        {
            warningText.text = "Выключи компьютер!!!";
            warningText.gameObject.SetActive(true);
            Invoke("HideWarning", warningDisplayTime);
        }
    }

    private void HideWarning()
    {
        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }
    }
}