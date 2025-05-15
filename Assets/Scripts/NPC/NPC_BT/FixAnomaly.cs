using UnityEngine;
using MBT;

[AddComponentMenu("")]
[MBTNode("Actions/FixAnomaly")]
public class FixAnomaly : Leaf
{
    private Blackboard _blackboard;
    private Animator _animator;
    private float _fixTimer = 0f;

    public override void OnEnter()
    {
        _fixTimer = 0f;
        _blackboard = gameObject.GetComponent<Blackboard>();
        _animator = gameObject.GetComponent<Animator>();

        _animator?.SetBool("isFix", true);
    }
    public override NodeResult Execute()
    {
        if (_blackboard.SeePlayer)
        {
            _blackboard.SeePlayer = false;
            _blackboard.lastKnownPlayerPosition = Vector3.zero;
        }
        _fixTimer += Time.deltaTime;
        if(_fixTimer >= _blackboard._fixDuration)
        {
            return NodeResult.success;
        }
        return NodeResult.running;
    }

    public override void OnExit()
    {
        _animator?.SetBool("isFix", false);
    }
}

    
