using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public void PlayGame()
    {
        sceneTransition.LoadSceneWithFade(0);
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Debug.Log("Вышли из игры");
        Application.Quit();
    }
}
