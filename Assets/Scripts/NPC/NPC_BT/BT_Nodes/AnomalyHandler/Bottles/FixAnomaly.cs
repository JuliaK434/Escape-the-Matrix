using UnityEngine;
using MBT;

[AddComponentMenu("")]
[MBTNode("Actions/FixAnomaly")]
public class FixAnomaly : Leaf
{
    private Blackboard _blackboard;
    private float _timer;
    private bool _animationPlay;

    public override void OnEnter()
    {
        _timer = Time.time;
        _animationPlay = false;
        _blackboard = gameObject.GetComponent<Blackboard>();
        _blackboard.isFix = true;

    }
    public override NodeResult Execute()
    {
        if (_blackboard.SeePlayer)
        {
            //_blackboard.SeePlayer = false;
            //_blackboard.lastKnownPlayerPosition = Vector3.zero;
        }

        if (!_animationPlay)
        {
            _animationPlay = true;
            _blackboard.isFix = true;
            _timer = Time.time;
        }

        if(Time.time - _timer < _blackboard._fixDuration)
        {
            return NodeResult.running;
        }
        _blackboard.isFix = false;
        return NodeResult.success;
    }

    public override void OnExit()
    {
        _blackboard.isFix = false;
    }
}

    
