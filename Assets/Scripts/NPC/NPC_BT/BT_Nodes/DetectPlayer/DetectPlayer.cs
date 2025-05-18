using UnityEngine;
using MBT;
using UnityEngine.SceneManagement;
using System.Collections;



[AddComponentMenu("")]
[MBTNode("Actions/DetectPlayer")]
public class DetectPlayer : Leaf
{
    private Blackboard _blackboard;
    private float timer = 0f;

    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
        timer = 0f;
    }
    public override NodeResult Execute()
    {
        if (_blackboard.SeePlayer)
        {
            timer += Time.deltaTime;
            if (timer >= _blackboard.DetectTime)
            {
                StartCoroutine(RestartAfterDelay(0.5f));
                return NodeResult.success;
            }
            else
            {
                return NodeResult.running;
            }
        }
        else
        {
            timer = 0f;
            return NodeResult.failure;
        }
    }
    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
