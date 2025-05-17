using MBT;
using UnityEngine;
using System.Collections;

[AddComponentMenu("")]
[MBTNode("Actions/ActivateButton")]
public class ActivateButton: Leaf

{
    private float _timer;
    private float _animationTime = 2f;
    private bool _animationPlay;
    private Blackboard _blackboard;
    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
        _blackboard.isUse = true;
        _timer = Time.time;
        _animationPlay = false;
    }
    public override NodeResult Execute()
    {
        if (!_animationPlay)
        {
            _animationPlay = true;
            _timer = Time.time;
            _blackboard.isUse = true;
        }

        if(Time.time - _timer < _animationTime) 
        { 
            return NodeResult.running; 
        }

        if(_blackboard.AnomalyObject.name != "Fire")
        {
            return NodeResult.failure;
        }
        _blackboard.AnomalyObject.SetActive(false);
        _blackboard.Button1.GetComponent<BoxCollider2D>().enabled = false;
        _blackboard.Button1.GetComponent<Button1>().enabled = false;
        _blackboard.isUse = false;
        return NodeResult.success;
    }

    public override void OnExit()
    {
        _blackboard.isUse = false; 
    }


}
