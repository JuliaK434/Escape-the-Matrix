using MBT;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Conditions/SeeFire")]
public class SeeFire: Leaf
{
    private Blackboard _blackboard;
    private float _firePositionX;
    private float _timer;
    private float _animationTime = 2f;
    private bool _animationPlay;
    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
        _firePositionX = 3.4785f;
        _blackboard.isAngry = true;
        _timer = Time.time;
        _animationPlay = false;

        if(_blackboard._agent != null)
        {
            _blackboard._agent.isStopped = true;
            //_blackboard._agent.ResetPath();
        }
    }
    public override NodeResult Execute()
    {
        if(_blackboard.AnomalyObject.name != "Fire")
        {
            return NodeResult.failure;
        }

        if (!_animationPlay)
        {
            _blackboard.isAngry = true;
            _blackboard.FireLocation = transform.position.x < _firePositionX ? false : true;
            _timer = Time.time;
            _animationPlay = true;
        }
        if (Time.time - _timer < _animationTime)
        {
            return NodeResult.running;
        }

        
        _blackboard.isAngry = false;
        return NodeResult.success;
    }

    public override void OnExit()
    {
        _blackboard.isAngry = false;
        if(_blackboard._agent != null)
        {
            _blackboard._agent.isStopped = false;
        }
    }


}
