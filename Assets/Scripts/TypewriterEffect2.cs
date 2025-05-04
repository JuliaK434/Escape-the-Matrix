using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect2 : MonoBehaviour
{
    public TextMeshProUGUI textComponent; 

    public float delayBetweenChars = 0.05f;
    public float delayAfterComplete = 1f;

    private string[] textPages;
    private int currentPage = 0;
    private bool isTyping = false;
    private bool isWaitingAfterComplete = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        if (textComponent == null)
        {
            textComponent = GetComponent<TextMeshProUGUI>(); 
        }

        textPages = new string[] {
            "-������ ����!...�����?",
            "-���, �������...����� � ��� �� ���������� �������? ��� ��� �����... ��� �� ����?",
            "-������� ����� �� ��, ��... ���-�� �� ���.",
            "- � ����� ��������� ���������?! �� ���� ����� �������.",
            "- ����, � ������ ������ ���� ���������� �����?...",
            "- ��� ������ ��� ���� ��� �������� ��������� �� ����� ����������, ���� �� �� ��������: �� ��� � ����������� ����. \"���������� �������\", �����������, �����... ",
            "- ����� ������� ���� ������ ������� � �����, ����� ����� ����� ���..."
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
                isWaitingAfterComplete = false;
            }
            else if (!isWaitingAfterComplete)
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

        textComponent.text = "";
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

        yield return new WaitForSeconds(delayAfterComplete);
        isTyping = false;
    }

    void FinishTypingCurrentPage()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        textComponent.text = textPages[currentPage];
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