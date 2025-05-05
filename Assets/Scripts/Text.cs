using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float delayBetweenChars = 0.05f;
    public float delayAfterComplete = 1f;

    private string[] introDialogue = {
        "- Привет мир!",
        "- Каждый день одно и то же: проснуться, умыться, сделать \"умственную зарядку\" — будто я робот, запрограммированный на бесконечное повторение...",
        "- Не думать лишнего, не выделяться, не дай бог кто-то заметит, что я... не такой. Как они.",
        "- Но сегодня что-то не так... В голове — туман, а в груди — странное беспокойство.",
        "- Будто забыл что-то важное...",
        "- Может, в шкафу?",
        "- Там, на полке, лежит старый блокнот. Вроде бы обычный, но... что если в нём есть ответ? Надо проверить."
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

        // Начинаем с начального диалога
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
            // Можно добавить событие окончания диалога
        }
    }
}