using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    int fullElement; // ���-�� ���� ��������� �����
    public static int myElement; // ����� ���������, ������� �� ����� �����
    public GameObject myPuzzl; // ������������ ������, ���������� ��� �������� ����� 
    public GameObject myPanel; // ������ � ������
    public GameObject winPanel; // ������ ������

    void Start()
    {
        fullElement = myPuzzl.transform.childCount; // �������� ���-�� ��������� �����
    }

    void Update()
    {
        if (fullElement == myElement) // ���� ��� �������� �� ����� �����
        {
            myPanel.SetActive(false); // �������� ������ � ������
            winPanel.SetActive(true); // ���������� ������ ������
            AchievementManager.Instance.UnlockAchievement("Achievement4"); //������������ ���������� 4
            Invoke("ReturnToMainScene", 2f); // ������������ �� �������� ����� ����� 2 �������
        }
    }

    // ������� ���������� ���-�� ���������, ������� ����� �� ����� �����
    public static void AddElement()
    {
        myElement++; // �����������
    }

    private void ReturnToMainScene()
    {
        SceneManager.LoadScene("Level2_HomeAfterPuzzle"); // ������� ��� ����� �������� �����
    }
}