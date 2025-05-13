using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    

    private const string Boost = "Boost";
    private const string OnFollow = "OnFollow";
    private const string OnPatrol = "OnPatrol";
    private const string OnPlayerLose = "OnPlayerLose";
    //private string OnIdle = "OnIdle";
    private Blackboard _blackboard;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {

        _animator.SetBool(OnPlayerLose, _blackboard.PlayerLose);
      

    }
}
