using UnityEngine;
using MBT;
using UnityEngine.SceneManagement;
using System.Collections;



[AddComponentMenu("")]
[MBTNode("Actions/DetectPlayer")]
public class DetectPlayer : Leaf
{
    private Blackboard blackboard;
    private bool _initialized;
    private float timer = 0f;

    public override NodeResult Execute()
    {
        if (!_initialized)
        {
            blackboard = gameObject.GetComponent<Blackboard>();
            _initialized = true;
        }

        if (blackboard.SeePlayer)
        {
            timer += Time.deltaTime;
            if (timer >= blackboard.DetectTime)
            {
                blackboard.PlayerLose = true;
                StartCoroutine(RestartAfterDelay(0.5f));
                Debug.Log("In DetectPlayer, success");
                return NodeResult.success;
            }
            else
            {
                return NodeResult.running;
            }
        }

        else
        {
            Debug.Log("In DetectPlayer, failture");
            timer = 0f;
            return NodeResult.failure;
        }
    }
    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("In DetectPlayer: Coroutine");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
