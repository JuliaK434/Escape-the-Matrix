using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodSelector : MonoBehaviour
{
    public void SelectBone()
    {
        PlayerInteraction3.hasBone = true; // ��������� ����� ������
        SceneManager.LoadScene("MainScene"); // ������������ �������
    }

    public void SelectOtherFood()
    {
        Debug.Log("������ ��� �� ���!");
    }
}