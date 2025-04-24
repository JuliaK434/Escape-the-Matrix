using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyNPC))]
[RequireComponent(typeof(EnemyState))]


public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private EnemyNPC _enemy;
    [SerializeField] private EnemyState _EnemyState;

    private const string Boost = "Boost";
    private const string OnFollow = "OnFollow";
    private const string OnPatrol = "OnPatrol";
    private const string OnAttack = "OnAttack";
    private const string OnDeath = "OnDeath";
    private const string OnTakeHit = "TakeHit";

    void Start()
    {
        _animator = GetComponent<Animator>();
        //_enemy.AttackEvent += _enemy_AttackEvent;
        _EnemyState.OnTakeHit += _enemyTakeHit;
    }

    void Update()
    {

        _animator.SetBool(OnPatrol, _enemy.GetOnPatrol());
        _animator.SetBool(OnFollow, _enemy.GetOnFollow());
        _animator.SetBool(OnAttack, _enemy.GetOnAttack());
        _animator.SetBool(OnDeath, _EnemyState.GetOnDeath());

    }

    void OnDestroy()
    {
        _EnemyState.OnTakeHit -= _enemyTakeHit;
        //_enemy.AttackEvent -= _enemy_AttackEvent;
    }

     void _enemyTakeHit(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(OnTakeHit);
    }
}
