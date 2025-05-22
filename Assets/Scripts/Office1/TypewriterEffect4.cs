using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect4 : MonoBehaviour
{
    private static bool introDialogueShow = false;
    public TextMeshProUGUI textComponent;
    public float delayBetweenChars = 0.05f;
    public float delayAfterComplete = 1f;

    private string[] introDialogue =
    {
        "-Наконец-то попал в свой офис",
        "-Но тут все не так... Все не на своих местах",
        "-Я слышу какие-то шаги в комнате с компьютерами",
        "-Странно... Тут никого не должно быть",
        "-Кто бы это не был, лучше не попадаться ему на глаза",
         "-Мне нужно найти способ попасть в мой кабинет",
        "-Может, в я найду ответ в комнате с компьюерами?",
        "-Нужно как-то выманить ЕГО из комнаты",
        "-Что же, пора зажигать!"
    };
    private string[] postComputerDialogie =
    {
        "-Ура, наконец-то я получил доступ к компьютеру. Нужно проверить план здания...",
        "Ага, в углу большой комнаты есть какой-то проход"
    };

    private string[] currentDialogue;
    private int currentPage = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;
    public TypewriterEffect4 Instance;

    private void OnEnable()
    {
        Task1Manager.Task1Success += StartPostComputerDialogue;
        Debug.Log("Subscribe");
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
        void Start()
    {
        if (textComponent == null)
        {
            textComponent = GetComponent<TextMeshProUGUI>();
        }
        if (!introDialogueShow)
        {
            StartIntroDialogue();
            introDialogueShow = true;
        }
    }


    private void StartIntroDialogue()
    {
        currentDialogue = introDialogue;
        currentPage = 0;
        gameObject.SetActive(true);
        StartTypingPage(currentPage);
    }
    private void StartPostComputerDialogue()
    {
        currentDialogue = postComputerDialogie;
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
                if(currentDialogue != null)
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
    private void OnDisable()
    {
        //Task1Manager.Task1Success -= StartPostComputerDialogue;
    }
}
