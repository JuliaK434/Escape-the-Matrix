using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Actions/ResetAnomaly")]
public class ResetAnomaly: Leaf
{
    private Blackboard _blackboard;

    public override NodeResult Execute()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();

        if (_blackboard.AnomalyObject != null)
        {
            Debug.Log("In ResetAnomaly: success");
            _blackboard.SeeAnomaly = false;
            _blackboard.AnomalyObject.SetActive(false);
            _blackboard.AnomalyObject = null;
            _blackboard.AnomalyPosition = Vector3.zero;
            return NodeResult.success;
        }
        else
        {
            Debug.Log("In ResetAnomaly: failture");
            return NodeResult.failure;
        }
       
    }
}
