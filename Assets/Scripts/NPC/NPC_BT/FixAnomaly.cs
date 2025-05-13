using UnityEngine;
using MBT;

[AddComponentMenu("")]
[MBTNode("Actions/FixAnomaly")]
public class FixAnomaly : Leaf
{
    private Blackboard _blackboard;
    private bool _initialized;
    private float _fixTimer = 0f;
    public override NodeResult Execute()
    {
        if (!_initialized)
        {
            _blackboard = gameObject.GetComponent<Blackboard>();
            _initialized = true;
            _fixTimer = 0f;
        }

        if (_blackboard.SeePlayer)
        {
            _blackboard.SeePlayer = false;
            _blackboard.lastKnownPlayerPosition = Vector3.zero;
        }

        _fixTimer += Time.deltaTime;
        if(_fixTimer >= _blackboard._fixDuration)
        {
            Debug.Log("Fixed");
            _initialized = false;
            return NodeResult.success;
        }

        return NodeResult.running;
    }
}

    
