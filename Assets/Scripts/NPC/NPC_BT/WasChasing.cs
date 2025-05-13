using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Conditions/WasChasing")]
public class WasChasing : Leaf
{
    private Blackboard _blackboard;
    private bool _initialized;

    public override NodeResult Execute()
    {
        Debug.Log("In WasChasing");
        if (!_initialized)
        {
            _blackboard = gameObject.GetComponent<Blackboard>();
        }

        if(_blackboard.SeePlayer == false && _blackboard.lastKnownPlayerPosition != Vector3.zero)
        {
            return NodeResult.success;
        }
        return NodeResult.failure;
    }
}