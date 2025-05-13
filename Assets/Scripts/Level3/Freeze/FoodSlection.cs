using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodSelector : MonoBehaviour
{
    public void SelectBone()
    {
        PlayerInteraction3.hasBone = true; // Сохраняем выбор игрока
        SceneManager.LoadScene("MainScene"); // Возвращаемся обратно
    }

    public void SelectOtherFood()
    {
        Debug.Log("Собака это не ест!");
    }
}