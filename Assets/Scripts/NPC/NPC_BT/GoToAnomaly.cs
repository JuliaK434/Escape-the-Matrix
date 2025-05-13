using UnityEngine;
using MBT;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode("Actions/GoToAnomaly")]
public class GoToanomaly: Leaf
{
    private Blackboard blackboard;
    private NavMeshAgent _agent;
    private bool _initialized = false;
    
    public override NodeResult Execute()
    {
        if (!_initialized)
        {
            blackboard = gameObject.GetComponent<Blackboard>();

            _agent = blackboard._agent;

            _initialized = true;

        }
 
        _agent.destination = blackboard.AnomalyPosition;
 
        return NodeResult.running;
    }
}
