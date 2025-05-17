using UnityEngine;
using MBT;
using UnityEngine.AI;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;

[AddComponentMenu("")]
[MBTNode("Actions/GoToButton")]
public class GoToaButton : Leaf
{
    private Blackboard blackboard;
    private bool _startWalk;
    public override void OnEnter()
    {
        blackboard = gameObject.GetComponent<Blackboard>();
        blackboard.isWalk = true;
        _startWalk = false;
        blackboard._agent.SetDestination (blackboard.buttonPosition);
        //Debug.Log(blackboard._agent.remainingDistance);
    }
    public override NodeResult Execute()
    {
        Debug.Log(blackboard._agent.remainingDistance);
        //blackboard._agent.remainingDistance
        if (_startWalk)
        {
            if (blackboard._agent.remainingDistance <= blackboard.StopDistance)
            {
                return NodeResult.success;
            }
            blackboard.isWalk = true;
            return NodeResult.running;
        }
        else
        {
            _startWalk = true;
            return NodeResult.running;
        }
    }

    public override void OnExit()
    {
        blackboard.isWalk = false;
    }
}

