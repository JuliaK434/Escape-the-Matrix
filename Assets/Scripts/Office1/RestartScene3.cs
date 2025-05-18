using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartScene3: MonoBehaviour 
{

    private void OnEnable()
    {
        TileRoom3.PlayerLose += RestartScene;
    }

    private void RestartScene()
    {
        Player.Instance.SetCanMove(false);
        StartCoroutine(RestartAfterDelay(1f));
    }
    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void OnDisable()
    {
        TileRoom3.PlayerLose -= RestartScene;
    }
}
