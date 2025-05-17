using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private Blackboard _blackboard;
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _blackboard = gameObject.GetComponent<Blackboard>();
    }

    void Update()
    {
      /*  if (_blackboard.isWalk)
            Debug.Log("isWalk");
        if (_blackboard.isFix)
            Debug.Log("isFix");
        if (_blackboard.isChase)
            Debug.Log("isChase");
        if (_blackboard.isHappy)
            Debug.Log("isHappy");
        if (_blackboard.isAngry)
            Debug.Log("isAngry");
        if (_blackboard.isUse)
            Debug.Log("isUse");
      */

        _animator.SetBool("isWalk", _blackboard.isWalk);
        _animator.SetBool("isFix", _blackboard.isFix);
        _animator.SetBool("isChase", _blackboard.isChase);
        _animator.SetBool("isHappy", _blackboard.isHappy);
        _animator.SetBool("isAngry", _blackboard.isAngry);
        _animator.SetBool("isStay", _blackboard.isStay);
        _animator.SetBool("isUse", _blackboard.isUse);

    }
}
