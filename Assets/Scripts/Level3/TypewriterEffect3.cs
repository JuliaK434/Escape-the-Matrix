using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect3 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float delayBetweenChars = 0.05f;
    public float delayAfterComplete = 1f;

    private string[] introDialogue = {
         "- Дай угадаю... Снова утро?",
            "- С каждым разом это звучит всё более издевательски. Как будто сама реальность издевается надо мной.",
            "- Но сегодня всё иначе. Комната... сместилась. Стены будто дышат, углы плывут.",
            "- Моя кровать всегда была такой маленькой? Я не помню как наполнял ванну... Неужели я забыл закрыть холодильник?",
            "- На столе — записка. Опять шифр??"
    };

    private string[] postPuzzleDialogue = {
        "- Хм 'good morning'... Да, очень \"хорошее\" утро. Как и вчера. И как позавчера...",
        "- Чёрт, я опаздываю. Опять.",
        "- Пора бы выходить на улицу и идти на работу.",
        "- Но... что если завтра я снова увижу этот блокнот? И снова решу этот шифр?",
        "- Неважно. Сейчас - на работу."
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