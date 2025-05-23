using UnityEngine;
using MBT;
using System.Diagnostics;

[AddComponentMenu("")]
[MBTNode("Conditions/SeePlayer")]
public class SeePlayer : Leaf
{
    private Blackboard _blackboard;

    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
    }

    public override NodeResult Execute()
    {
        return _blackboard.SeePlayer ? NodeResult.success : NodeResult.failure;
    }



}
