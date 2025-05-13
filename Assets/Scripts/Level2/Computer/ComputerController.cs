using UnityEngine;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour
{
    public Sprite computerOn;        // ������ ����������� ����������
    public Sprite computerOff;       // ������ ������������ ����������
    public GameObject screenContent; // ������ � ������������ �� ������ (������ ���� ��������)

    private Image computerImage;     // ��������� Image ��� ����������� �������
    private bool isOn = true;       // ������� ��������� ����������

    void Start()
    {
        // �������� ��������� Image
        computerImage = GetComponent<Image>();

        // ������������� ��������� ������ � ��������� ������
        if (computerImage != null && computerOn != null)
        {
            computerImage.sprite = computerOn;
        }

        // �������������� ��������� ������
        UpdateScreenState();
    }

    // ����� ��� ������������ ��������� ����������
    public void ToggleComputer()
    {
        isOn = !isOn; // ����������� ���������

        // ������ ������
        if (computerImage != null)
        {
            computerImage.sprite = isOn ? computerOn : computerOff;
        }

        // ��������� ��������� ������
        UpdateScreenState();

    }

    // ����� ��� ���������� ��������� ������
    private void UpdateScreenState()
    {
        if (screenContent != null)
        {
            screenContent.SetActive(isOn);
        }
    }
    public bool IsComputerOn()
    {
        return isOn;
    }
}