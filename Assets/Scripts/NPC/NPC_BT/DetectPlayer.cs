using UnityEngine;
using MBT;
using UnityEngine.SceneManagement;
using System.Collections;



[AddComponentMenu("")]
[MBTNode("Actions/DetectPlayer")]
public class DetectPlayer : Leaf
{
    private Blackboard _blackboard;
    private Animator _animator;
    private float timer = 0f;

    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
        _animator = gameObject.GetComponent<Animator>();

        _animator?.SetBool("isStay", true);
    }
    public override NodeResult Execute()
    {
        if (_blackboard.SeePlayer)
        {
            timer += Time.deltaTime;
            if (timer >= _blackboard.DetectTime)
            {
                _blackboard.PlayerLose = true;
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

    public override void OnExit()
    {
        _animator?.SetBool("isStay", false);
    }
}
