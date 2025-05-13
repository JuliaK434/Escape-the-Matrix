using UnityEngine;
using MBT;
[AddComponentMenu("")]
[MBTNode("Actions/LookAround")]
public class LookAround : Leaf
{
    private float _startTime;
    private bool _initialized = false;
    private Blackboard _blackboard;

    public float lookDuration = 3f;
    public override NodeResult Execute()
    {
        if (!_initialized)
        {
            _startTime = Time.time;
            _blackboard = gameObject.GetComponent<Blackboard>();
           // _blackboard.ViewAngle = 180f;
            _initialized = true;
        }


        if (_blackboard.SeePlayer)
        {
            Debug.Log("In look around, see Player");
            _initialized = false;
            //_blackboard.ViewAngle = 120f;
            return NodeResult.success; 
        }

        else if (_blackboard.SeeAnomaly && _blackboard.AnomalyPosition == Vector3.zero)
        {
            Debug.Log("In look around, seeAnomaly");
            _initialized = false;
            //_blackboard.ViewAngle = 120f;
            return NodeResult.failure;
        }

        if(Time.time - _startTime >= lookDuration / 2)
        {
            Debug.Log("In look around");
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }

        if (Time.time - _startTime >= lookDuration)
        {
            _initialized = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
           // _blackboard.ViewAngle = 120f;
            return NodeResult.success;
        }

        return NodeResult.running;
    }
}