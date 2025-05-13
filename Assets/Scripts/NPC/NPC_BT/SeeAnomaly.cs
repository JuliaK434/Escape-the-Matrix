using UnityEngine;
using MBT;
[AddComponentMenu("")]
[MBTNode("Conditions/SeeAnomaly")]
public class SeeAnomaly : Leaf
{
    private Blackboard blackboard;
    private bool _initialized;

    public override NodeResult Execute()
    {
        if (!_initialized)
        {
            blackboard = gameObject.GetComponent<Blackboard>();
        }

        return blackboard.SeeAnomaly ? NodeResult.success : NodeResult.failure;
    }

}
