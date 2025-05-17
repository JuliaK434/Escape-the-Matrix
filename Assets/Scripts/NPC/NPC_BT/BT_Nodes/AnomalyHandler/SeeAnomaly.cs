using UnityEngine;
using MBT;
[AddComponentMenu("")]
[MBTNode("Conditions/SeeAnomaly")]
public class SeeAnomaly : Leaf
{
    private Blackboard _blackboard;
    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
    }

    public override NodeResult Execute()
    {
        return _blackboard.SeeAnomaly ? NodeResult.success : NodeResult.failure;
    }

}
