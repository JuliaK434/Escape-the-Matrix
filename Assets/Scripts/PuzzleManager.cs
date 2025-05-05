using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject puzzleUI;
    public TextMeshProUGUI hintText;
    public TypewriterEffect dialogueSystem;
    private bool isPuzzleActive;

    public static PuzzleManager Instance;

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


        if (answer.Contains("good morning") || answer.Contains("goodmorning"))
        {
            ClosePuzzle();
            dialogueSystem.StartPostPuzzleDialogue();
        }
        else
        {
            inputField.text = "";
            hintText.text = "Неверно! Попробуйте ещё раз";
            inputField.Select();
        }
    }
}