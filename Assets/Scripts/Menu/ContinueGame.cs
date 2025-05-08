using UnityEngine;

public class ContinueGame:MonoBehaviour
{
    public GameObject panel;

    public void continuegame(){
        Time.timeScale = 1f;
        panel.SetActive(false);
    }
}
