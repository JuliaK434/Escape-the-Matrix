using UnityEngine;
using MBT;
using System.Collections;
[AddComponentMenu("")]
[MBTNode("Actions/LookAround")]
public class LookAround : Leaf
{
    private float _startTime;
    private float _seePlayerTimer;
    private Blackboard _blackboard;
    private float _bViewAngle;

    public override void OnEnter()
    {
        _startTime = Time.time;
        _blackboard = gameObject.GetComponent<Blackboard>();
        _bViewAngle = _blackboard.ViewAngle;
         _blackboard.ViewAngle = 360f;

    }
    public override NodeResult Execute()
    { 
        if (_blackboard.SeePlayer)
        {
            return NodeResult.success;
         }

        if (_blackboard.SeeAnomaly && _blackboard.AnomalyPosition == Vector3.zero)
        {
            return NodeResult.failure;
        }

       if (Time.time - _startTime >= _blackboard.LookAroundTime)
        {
            return NodeResult.success;
        }

        return NodeResult.running;
    }

    public override void OnExit()
    {
       _blackboard.ViewAngle = _bViewAngle;
    }
}