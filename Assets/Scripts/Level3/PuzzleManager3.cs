using UnityEngine;
using TMPro;

public class PuzzleManager3 : MonoBehaviour
{
    [SerializeField] private DoorTrigger exitDoor;
    public TMP_InputField inputField;
    public GameObject puzzleUI;
    public TextMeshProUGUI hintText;
    public TypewriterEffect3_2 dialogueSystem;
    private bool isPuzzleActive;

    public static PuzzleManager3 Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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


        if (answer.Contains("i think good morning") || answer.Contains("ithinkgoodmorning"))
        {
            ClosePuzzle();
            dialogueSystem.StartAfterPuzzleDialogue();
            if (exitDoor != null)
            {
                exitDoor.UnlockDoor();
            }
            AchievementManager.Instance.UnlockAchievement("Achievement7");
            Debug.Log("Achievement7 разблокирован!");
        }
        else
        {
            inputField.text = "";
            hintText.text = "Неверно! Попробуйте ещё раз";
            inputField.Select();
        }
    }
}