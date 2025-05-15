using UnityEngine;
using MBT;
[AddComponentMenu("")]
[MBTNode("Actions/LookAround")]
public class LookAround : Leaf
{
    private float _startTime;
    private Blackboard _blackboard;
    private Animator _animator;
    public float lookDuration = 4f;
    private float _bViewAngle;

    public override void OnEnter()
    {
        _startTime = Time.time;
        _blackboard = gameObject.GetComponent<Blackboard>();
        _animator = gameObject.GetComponent<Animator>();
        _bViewAngle = _blackboard.ViewAngle;
        _blackboard.ViewAngle = 360f; 

        _animator.SetBool("isStay", true);
    }
    public override NodeResult Execute()
    { 
        if (_blackboard.SeePlayer)
        {
            Debug.Log("SeePlayer");
            return NodeResult.success; 
        }

        else if (_blackboard.SeeAnomaly && _blackboard.AnomalyPosition == Vector3.zero)
        {
            return NodeResult.failure;
        }

       // if(Time.time - _startTime >= lookDuration / 2)
        //{
        //    transform.rotation = Quaternion.Euler(0, -180, 0);
        //}

        if (Time.time - _startTime >= lookDuration)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            return NodeResult.success;
        }

        return NodeResult.running;
    }

    public override void OnExit()
    {
        _animator?.SetBool("isStay", false);
        _blackboard.ViewAngle = _bViewAngle;
    }
}