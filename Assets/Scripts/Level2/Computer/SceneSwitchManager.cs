using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneSwitchManager : MonoBehaviour
{
    public ComputerController computerSwitch; // ������ �� ������ ���������� �����������
    public TextMeshProUGUI warningText;   // ����� �������������� (����������� Text ��� ������������ UI)
    public float warningDisplayTime = 2f;  // ����� ����������� ��������������

    private void Start()
    {
        // �������� �������������� ��� ������
        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }
    }

    public void TrySwitchScene()
    {
        // ���������, �������� �� ���������
        if (computerSwitch != null && !computerSwitch.IsComputerOn())
        {
            // ���� ��������� �������� - ����������� �����
            SceneManager.LoadScene("Level2_HomeAfterComputer"); 
            AchievementManager.Instance.UnlockAchievement("Achievement5");
        }
        else
        {
            // ���� ��������� ������� - ���������� ��������������
            ShowWarning();
        }
    }

    private void ShowWarning()
    {
        if (warningText != null)
        {
            warningText.text = "������� ���������!!!";
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