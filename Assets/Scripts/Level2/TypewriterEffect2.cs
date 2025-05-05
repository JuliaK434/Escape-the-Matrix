using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect2 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float delayBetweenChars = 0.05f;
    public float delayAfterComplete = 1f;

    private string[] introDialogue = {
         "-Доброе утро!...Опять?",
            "-Нет, подожди...Разве я уже не просыпался сегодня? Или это снова... тот же день?",
            "-Комната вроде та же, но... что-то не так.",
            "- Я забыл выключить компьютер?! Со мной такое впервые.",
            "- Стоп, а кресло всегда было оранжевого цвета?...",
            "- Или просто мой мозг так отчаянно цепляется за любую странность, лишь бы не признать: всё это — бесконечный цикл. \"Умственная зарядка\", повиновение, страх... ",
            "- Пойду проверю свой старый блокнот в шкафу, вдруг найду ответ там..."
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