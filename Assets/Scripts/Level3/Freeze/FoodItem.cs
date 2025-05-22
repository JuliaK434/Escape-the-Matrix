using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FoodSelectionManager : MonoBehaviour
{
    [Header("TMP References")]
    public TMP_Text correctText;
    public TMP_Text wrongText;
    public float messageDisplayTime = 2f;

    [Header("Valid Foods")]
    public string[] validFoods = { "Bone", "Meat", "DogFood" };

    private void Start()
    {
        correctText.gameObject.SetActive(false);
        wrongText.gameObject.SetActive(false);
    }

    // Метод для кнопок (вызывается через Inspector)
    public void OnFoodSelected(string foodName)
    {
        if (IsValidFood(foodName))
        {
            ShowMessage(correctText, "Собака будет довольна!");
            Invoke(nameof(LoadMainScene), messageDisplayTime);
        }
        else
        {
            ShowMessage(wrongText, "Собака это не ест!");
        }
    }

    private bool IsValidFood(string food)
    {
        return System.Array.Exists(validFoods, x => x == food);
    }

    private void ShowMessage(TMP_Text textElement, string message)
    {
        textElement.text = message;
        textElement.gameObject.SetActive(true);
        Invoke(nameof(HideMessages), messageDisplayTime);
    }

    private void HideMessages()
    {
        correctText.gameObject.SetActive(false);
        wrongText.gameObject.SetActive(false);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("Level3_AfterFredge");
        AchievementManager.Instance.UnlockAchievement("Achievement8");
        Debug.Log("Achievement8 разблокирован!");
    }
}