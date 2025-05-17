using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Conditions/FireRight")]
public class FireRight : Leaf
{
    private Blackboard _blackboard;
    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
    }
    public override NodeResult Execute()
    {

        return _blackboard.FireLocation ? NodeResult.failure : NodeResult.success;

    }
}




