using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Actions/ChangeWayPoints")]
public class ChangeWayPoints : Leaf
{
    private Blackboard blackboard;

    public override void OnEnter()
    {
        blackboard = gameObject.GetComponent<Blackboard>();
    }
    public override NodeResult Execute()
    {
        blackboard.wayPoints = blackboard.reserveWayPoints;
        return NodeResult.success;
    }
}