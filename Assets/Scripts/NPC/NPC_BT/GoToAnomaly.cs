using UnityEngine;
using MBT;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode("Actions/GoToAnomaly")]
public class GoToanomaly: Leaf
{
    private Blackboard blackboard;
    private Animator _animator;


    public override void OnEnter()
    {
        blackboard = gameObject.GetComponent<Blackboard>();
        _animator = gameObject.GetComponent<Animator>();

        _animator?.SetBool("isChase", true);
    }
    public override NodeResult Execute()
    {
        blackboard._agent.destination = blackboard.AnomalyPosition;

        if (blackboard.SeePlayer)
        {
            return NodeResult.success;
        }

        if(blackboard._agent.remainingDistance <= blackboard.StopDistance)
        {
            return NodeResult.success;
        }
        return NodeResult.running;
    }

    public override void OnExit()
    {
        _animator?.SetBool("isChase", false);
    }

}
