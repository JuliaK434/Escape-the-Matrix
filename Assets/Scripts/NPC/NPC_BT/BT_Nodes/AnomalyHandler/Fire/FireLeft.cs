using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Conditions/FireLeft")]
public class FireLeft : Leaf
{
    private Blackboard _blackboard;
    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
    }
    public override NodeResult Execute()
    {

        return _blackboard.FireLocation ? NodeResult.success : NodeResult.failure;

    }
}




