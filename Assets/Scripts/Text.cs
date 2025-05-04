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
        // Проверка что textComponent назначен
        if (textComponent == null)
        {
            textComponent = GetComponent<TMPro.TextMeshProUGUI>();
        }

        textPages = new string[] {
            "- Привет мир!",
            "- Каждый день одно и то же: проснуться, умыться, сделать \"умственную зарядку\" — будто я робот, запрограммированный на бесконечное повторение...",
            "- Не думать лишнего, не выделяться, не дай бог кто-то заметит, что я... не такой. Как они.",
            "- Но сегодня что-то не так... В голове — туман, а в груди — странное беспокойство.",
            "- Будто забыл что-то важное...",
            "- Может, в шкафу?",
            "- Там, на полке, лежит старый блокнот. Вроде бы обычный, но... что если в нём есть ответ? Надо проверить."
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

        textComponent.text = ""; // Используем text с маленькой буквы
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

        textComponent.text = textPages[currentPage]; // Используем text с маленькой буквы
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