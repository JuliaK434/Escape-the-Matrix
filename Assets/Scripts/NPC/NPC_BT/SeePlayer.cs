using UnityEngine;
using MBT;
[AddComponentMenu("")]
[MBTNode("Conditions/SeePlayer")]
public class SeePlayer : Leaf
{
    private Blackboard blackboard;
    private bool initialized;

    public override NodeResult Execute()
    {
        Debug.Log("in SeePlayer");
        if (!initialized)
        {
            blackboard = gameObject.GetComponent<Blackboard>();
        }

        return blackboard.SeePlayer ? NodeResult.success : NodeResult.failure;
    }

}
