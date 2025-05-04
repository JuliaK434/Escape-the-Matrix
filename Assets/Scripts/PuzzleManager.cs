using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject puzzleUI;
    public TextMeshProUGUI hintText;
    private bool isPuzzleActive;

    private void Update()
    {
        if (isPuzzleActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePuzzle();
            }
            else if (Input.GetKeyDown(KeyCode.Return)) // Проверка нажатия Enter
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
        inputField.Select(); // Автоматически активируем поле ввода
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

        if (answer == "good morning" || answer == "goodmorning")
        {
            ClosePuzzle();
            Debug.Log("Головоломка решена!");
            // Здесь можно вызвать диалог
        }
        else
        {
            inputField.text = "";
            hintText.text = "Неверно! Попробуйте ещё раз";
            inputField.Select(); // Снова активируем поле ввода после очистки
        }
    }
}