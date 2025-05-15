using UnityEngine;
using MBT;
[AddComponentMenu("")]
[MBTNode("Conditions/SeePlayer")]
public class SeePlayer : Leaf
{
    private Blackboard _blackboard;
    private Animator _animator;

    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
        _animator = gameObject.GetComponent<Animator>();
    }

    public override NodeResult Execute()
    {
        return _blackboard.SeePlayer ? NodeResult.success : NodeResult.failure;
    }

}
