using UnityEngine;
using MBT;
[AddComponentMenu("")]
[MBTNode("Conditions/SeeAnomaly")]
public class SeeAnomaly : Leaf
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
        return _blackboard.SeeAnomaly ? NodeResult.success : NodeResult.failure;
    }

    public override void OnExit()
    {
        _animator?.SetBool("isStay", false);
    }

}
