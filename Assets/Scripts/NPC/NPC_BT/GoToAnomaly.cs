using UnityEngine;
using MBT;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode("Actions/GoToAnomaly")]
public class GoToanomaly: Leaf
{
    private Blackboard blackboard;
    private bool _initialized = false;

    private bool _PrintMessage;
    
    public override NodeResult Execute()
    {
        if (!_initialized)
        {
            blackboard = gameObject.GetComponent<Blackboard>();
            _initialized = true;
            _PrintMessage = false;

        }
        if(!_PrintMessage)
        {
            Debug.Log("Go To Anomaly");
            _PrintMessage = true;
        }

        blackboard._agent.destination = blackboard.AnomalyPosition;

        if (blackboard.SeePlayer)
        {
            Debug.Log("In GoToAnomaly: see player");
            _initialized = false;
            return NodeResult.success;
        }

        if(blackboard._agent.remainingDistance <= blackboard.StopDistance)
        {
            _initialized = false;
            return NodeResult.success;
        }

 
        return NodeResult.running;
    }
}
