using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Actions/ResetAnomaly")]
public class ResetAnomaly: Leaf
{
    private Blackboard _blackboard;
    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();

    }

    public override NodeResult Execute()
    {

        if (_blackboard.AnomalyObject != null)
        {
            _blackboard.SeeAnomaly = false;
            _blackboard.AnomalyObject.SetActive(false);
            _blackboard.AnomalyObject = null;
            _blackboard.AnomalyPosition = Vector3.zero;
            return NodeResult.success;
        }
        else
        {
            return NodeResult.failure;
        }
       
    }
}
