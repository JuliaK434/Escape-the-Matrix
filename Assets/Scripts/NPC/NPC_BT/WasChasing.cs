using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Conditions/WasChasing")]
public class WasChasing : Leaf
{
    private Blackboard _blackboard;
    private Animator _animator;

    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
        _animator = gameObject.GetComponent<Animator>();
        _animator?.SetBool("isStay", true);
    }
    public override NodeResult Execute()
    {

        if(_blackboard.SeePlayer == false && _blackboard.lastKnownPlayerPosition != Vector3.zero)
        {

            return NodeResult.success;
        }
        return NodeResult.failure;
    }

    public override void OnExit()
    {
        _animator?.SetBool("isStay", false);
    }
}