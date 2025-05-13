using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public void menu(){
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
