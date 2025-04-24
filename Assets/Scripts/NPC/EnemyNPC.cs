using System;
using UnityEngine;
using UnityEngine.AI;


//velocity - Vector3,  speed
[RequireComponent(typeof(NavMeshAgent))] 

public class EnemyNPC : MonoBehaviour
{
    public GameObject player;
    public Transform[] wayPoints;
    public Transform[] _allies;
    public float RunBoost = 1.5f;
    public float AttackSpeed = 3f;
    public float AttackDistance = 0.5f;
    public float TriggerFollowDistance = 5f;
    public float StopDistance = 0.5f;




    private bool OnFollow = false;
    private bool OnAttack = false;
    private bool OnPatrol = false;
    private enum State { Idle, Patrol, FollowPlayer, Attack, Escape, CallHelp, Death};
    private State _state = State.Idle;
    //public event Event AttackEvent;

    private int _currentWaypoint = 0;
    private NavMeshAgent _agent;
    private float _NextAttackTime = 0;
    private float PatrolSpeed;
    private float RunSpeed;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;


        PatrolSpeed = _agent.speed;
        RunSpeed = _agent.speed * RunBoost;
}

    void Update()
    {
        FSM();
        ChangeHeadDirection();
    }

    public float GetBoost()
    {
        return _agent.speed / PatrolSpeed;
    }

    public bool GetOnFollow()
    {
        return OnFollow;
    }

    public bool GetOnAttack()
    {
        return OnAttack;
    }

    public bool GetOnPatrol()
    {
        return OnPatrol;
    }

    public void ActivateDeath()
    {
        _state = State.Death;
    }

    void Idle()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < TriggerFollowDistance)
        {
            _state = State.FollowPlayer;
        }
        else
        {
            _state = State.Patrol;
        }
    }

    void Patrol()
    {
        OnPatrol = true;

        if (Vector3.Distance(player.transform.position, transform.position) < TriggerFollowDistance)
        {
            OnPatrol = false;
            _state = State.FollowPlayer;

        }

        else if (_agent.remainingDistance < StopDistance)
        {
            _currentWaypoint = (_currentWaypoint + 1) % wayPoints.Length;
            _agent.destination = wayPoints[_currentWaypoint].position;
        }
    }

    void FollowPlayer()
    {
        _agent.destination = player.transform.position;
        OnFollow = true;
        _agent.speed = RunSpeed;

        float DistanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (DistanceToPlayer >= TriggerFollowDistance)
        {
            _state = State.Patrol;
            
            OnFollow = false;
            _agent.speed = PatrolSpeed;


        }
        else if (DistanceToPlayer <= AttackDistance)
        {
            _state = State.Attack;

            OnFollow = false;
            _agent.speed = PatrolSpeed;
        }
    }

    void Attack() 
    {
        OnAttack = true;
        if (Time.time > _NextAttackTime)
        {
            //AttackEvent?.Invoke(this, EventArgs.Empty);
            _NextAttackTime = Time.time + AttackSpeed;

        }

        if(Vector3.Distance(player.transform.position, transform.position) > AttackDistance)
        {
            OnAttack = false;
            _state = State.Idle;
        }

    }

    void Escape()
    {
    }

    void CallHelp()
    {

    }

    void Death()
    {
 
    }

    void FindAllies()
    {

    }

    void FSM()
    {
        switch (_state)
        {
            case (State.Idle):
                Idle();
                break;
            case (State.Patrol):
                Patrol();
                break;
            case (State.FollowPlayer):
                FollowPlayer();
                break;
            case (State.Attack):
                Attack();
                break;
            case (State.Escape):
                Escape();
                break;
            case (State.CallHelp):
                CallHelp();
                break;
            case (State.Death):
                Death();
                break;

        }
    }

    void ChangeHeadDirection()
    {
        if (_agent.destination.x < _agent.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -0, 0);
        }
    }
}

