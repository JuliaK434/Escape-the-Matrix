using UnityEngine;
using TMPro;

public class Task1Manager : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject puzzleUI;
    public TextMeshProUGUI hintText;
    private bool _isComputerAvailable;
    public static event System.Action Task1Success;
    public static Task1Manager Instance; //SingleTone Pattern

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    private void Update()
    {
        if (_isComputerAvailable)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseComputer();
            }

            else if (Input.GetKeyDown(KeyCode.Return))
            {

                CheckAnswer();
            }
        }
    }

    public void OpenComputer()
    {
        Debug.Log("OpenComputer");
        puzzleUI.SetActive(true);
        inputField.text = "";
        _isComputerAvailable = true;
        Player.Instance.SetCanMove(false);
        inputField.Select();
    }

    private void CloseComputer()
    {
        puzzleUI.SetActive(false);
        _isComputerAvailable = false;
        Player.Instance.SetCanMove(true);
    }

    public void CheckAnswer()
    {
        string answer = inputField.text.Trim().ToLower();


        if (answer.Contains("1ew324dqegcw"))
        {
            Task1Success?.Invoke();
            CloseComputer();
        }
        else
        {
            inputField.text = "";
            hintText.text = "Пароль неверный. В доступе отказано";
            inputField.Select();
        }
    }
}