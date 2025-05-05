using UnityEngine;
using TMPro;

public class PuzzleManager2 : MonoBehaviour
{
    [SerializeField] private DoorTrigger exitDoor;
    public TMP_InputField inputField;
    public GameObject puzzleUI;
    public TextMeshProUGUI hintText;
    public TypewriterEffect2 dialogueSystem;
    private bool isPuzzleActive;

    public static PuzzleManager2 Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("PuzzleManager2 initialized"); // Для отладки
        }

    }
    private void Update()
    {
        if (isPuzzleActive)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePuzzle();
            }

            else if (Input.GetKeyDown(KeyCode.Return))
            {

                CheckAnswer();
            }
        }
    }

    public void OpenPuzzle()
    {
        puzzleUI.SetActive(true);
        inputField.text = "";
        isPuzzleActive = true;
        Player.Instance.SetCanMove(false);
        inputField.Select();
    }

    private void ClosePuzzle()
    {
        puzzleUI.SetActive(false);
        isPuzzleActive = false;
        Player.Instance.SetCanMove(true);
    }

    public void CheckAnswer()
    {
        string answer = inputField.text.Trim().ToLower();


        if (answer.Contains("good morning") || answer.Contains("goodmorning"))
        {
            ClosePuzzle();
            dialogueSystem.StartPostPuzzleDialogue();
            if (exitDoor != null)
            {
                exitDoor.UnlockDoor();
            }
            else
            {
                Debug.LogError("Exit door reference not set!", this);
            }
        }
        else
        {
            inputField.text = "";
            hintText.text = "Неверно! Попробуйте ещё раз";
            inputField.Select();
        }
    }
}