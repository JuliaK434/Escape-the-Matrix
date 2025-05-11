using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect3 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float delayBetweenChars = 0.05f;
    public float delayAfterComplete = 1f;

    private string[] introDialogue = {
         "- Дай угадаю... Снова утро? И кстати в этот раз достаточно раннее...",
            "- С каждым разом это звучит всё более издевательски. Как будто сама реальность издевается надо мной.",
            "- Но сегодня всё иначе. Комната... сместилась. Стены будто дышат, углы плывут.",
            "- Моя кровать всегда была такой маленькой? Я не помню как наполнял ванну... Неужели я забыл закрыть холодильник?",
            "- Стоп. Где мой телефон?!",
            "- Я где-то его потерял, нужно срочно найти!"
    };

    private string[] postPuzzleDialogue = {
        "- Как он оказался рядом с туалетом?",
        "- Ладно это не важно. Неужели вышло обновление моей любимой игры?",
        "- Нужно срочно пройти. Но для начала нужно освободить место на кресле."
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