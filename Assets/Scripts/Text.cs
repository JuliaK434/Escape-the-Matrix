using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textComponent; 
                                                

    public float delayBetweenChars = 0.05f;
    public float delayAfterComplete = 1f;

    private string[] textPages;
    private int currentPage = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        // �������� ��� textComponent ��������
        if (textComponent == null)
        {
            textComponent = GetComponent<TMPro.TextMeshProUGUI>();
        }

        textPages = new string[] {
            "- ������ ���!",
            "- ������ ���� ���� � �� ��: ����������, �������, ������� \"���������� �������\" � ����� � �����, ������������������� �� ����������� ����������...",
            "- �� ������ �������, �� ����������, �� ��� ��� ���-�� �������, ��� �... �� �����. ��� ���.",
            "- �� ������� ���-�� �� ���... � ������ � �����, � � ����� � �������� ������������.",
            "- ����� ����� ���-�� ������...",
            "- �����, � �����?",
            "- ���, �� �����, ����� ������ �������. ����� �� �������, ��... ��� ���� � �� ���� �����? ���� ���������."
        };

        StartTypingPage(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                FinishTypingCurrentPage();
            }
            else
            {
                ShowNextPage();
            }
        }
    }

    void StartTypingPage(int pageIndex)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        textComponent.text = ""; // ���������� text � ��������� �����
        typingCoroutine = StartCoroutine(TypeText(textPages[pageIndex]));
    }

    IEnumerator TypeText(string textToType)
    {
        isTyping = true;

        foreach (char c in textToType)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(delayBetweenChars);
        }

        isTyping = false;
    }

    void FinishTypingCurrentPage()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        textComponent.text = textPages[currentPage]; // ���������� text � ��������� �����
        isTyping = false;
    }

    void ShowNextPage()
    {
        currentPage++;

        if (currentPage < textPages.Length)
        {
            StartTypingPage(currentPage);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}