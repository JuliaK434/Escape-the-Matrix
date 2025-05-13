using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Image fadeOverlay; // Ссылка на Image
    public float fadeDuration = 1.0f; // Длительность затухания

    private void Start()
    {
        // Плавное появление сцены (fade-in)
        if (fadeOverlay != null)
        {
            fadeOverlay.color = new Color(0, 0, 0, 1); // Начальная непрозрачность
            fadeOverlay.CrossFadeAlpha(0, fadeDuration, false); // Плавное исчезновение
        }
    }

    public void LoadSceneWithFade(int sceneIndex)
    {
        if (fadeOverlay != null)
        {
            fadeOverlay.color = new Color(0, 0, 0, 0); // Начальная прозрачность
            fadeOverlay.CrossFadeAlpha(1, fadeDuration, false); // Плавное затемнение
        }

        Invoke(nameof(LoadScene), fadeDuration); // Загрузка сцены после затухания
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}