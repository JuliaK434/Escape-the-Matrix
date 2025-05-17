using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Conditions/WasChasing")]
public class WasChasing : Leaf
{
    private Blackboard _blackboard;

    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
    }
    public override NodeResult Execute()
    {

        if(_blackboard.SeePlayer == false && _blackboard.lastKnownPlayerPosition != Vector3.zero)
        {

            return NodeResult.success;
        }
        return NodeResult.failure;
    }
}