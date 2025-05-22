using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    int fullElement; // Кол-во всех элементов пазла
    public static int myElement; // Число элементов, лежащих на своем месте
    public GameObject myPuzzl; // Родительский объект, содержащий все элементы пазла 
    public GameObject myPanel; // Панель с пазлом
    public GameObject winPanel; // Панель победы

    void Start()
    {
        fullElement = myPuzzl.transform.childCount; // Получаем кол-во элементов пазла
    }

    void Update()
    {
        if (fullElement == myElement) // Если все элементы на своем месте
        {
            myPanel.SetActive(false); // Скрываем панель с пазлом
            winPanel.SetActive(true); // Показываем панель победы
            AchievementManager.Instance.UnlockAchievement("Achievement4"); //Разблокируем достижение 4
            Invoke("ReturnToMainScene", 2f); // Возвращаемся на основную сцену через 2 секунды
        }
    }

    // Функция увеличения кол-ва элементов, которые лежат на своем месте
    public static void AddElement()
    {
        myElement++; // Увеличиваем
    }

    private void ReturnToMainScene()
    {
        SceneManager.LoadScene("Level2_HomeAfterPuzzle"); // Укажите имя вашей основной сцены
    }
}