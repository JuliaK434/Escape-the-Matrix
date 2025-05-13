using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect2_2 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float delayBetweenChars = 0.05f;
    public float delayAfterComplete = 1f;

    private string[] introDialogue = {
         "- ��... ��� ����� ������� \"������\" � ���� 8-2*2?",
         "- � ���� ����������� ������ ���� �����-�� �����.",
         "- ����� ������� ���� ������ ������� � �����, ����� ����� ����� ���..."
    };
    private string[] postPuzzleDialogue = {
        "- � ����� ������ ����...",
        "- � �� �������. ��� ����� � ���� � ������� �������.",
        "- �� ��� �� ��������. � ��� ���� ���� �� ������."
    };

    private string[] currentDialogue;
    private int currentPage = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        if (textComponent == null)
        {
            textComponent = GetComponent<TextMeshProUGUI>();
        }

        StartIntroDialogue();
    }

    public void StartIntroDialogue()
    {
        currentDialogue = introDialogue;
        currentPage = 0;
        gameObject.SetActive(true);
        StartTypingPage(currentPage);
    }

    public void StartPostPuzzleDialogue()
    {
        currentDialogue = postPuzzleDialogue;
        currentPage = 0;
        gameObject.SetActive(true);
        StartTypingPage(currentPage);
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

        textComponent.text = "";
        typingCoroutine = StartCoroutine(TypeText(currentDialogue[pageIndex]));
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

        textComponent.text = currentDialogue[currentPage];
        isTyping = false;
    }

    void ShowNextPage()
    {
        currentPage++;

        if (currentPage < currentDialogue.Length)
        {
            StartTypingPage(currentPage);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}