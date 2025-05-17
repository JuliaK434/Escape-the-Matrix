using MBT;
using UnityEngine;
using UnityEngine.AI;
//public event Event AttackEvent;
//AttackEvent?.Invoke(this, EventArgs.Empty);
//[SerializeField] private EnemyNPC _enemy;
//_enemy.AttackEvent += _enemy_AttackEvent;
//_enemy.AttackEvent -= _enemy_AttackEvent;
/*
void _enemy_AttackEvent(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(OnTakeHit);
    }
*/
[AddComponentMenu("")]
[MBTNode("Actions/InitNavMeshAgent")]
public class InitNavMeshAgent: Leaf
{
    
    private Blackboard _blackboard;

    public override NodeResult Execute()
    {
        Debug.Log("First node");
        _blackboard = gameObject.GetComponent<Blackboard>();
        if (_blackboard._agent == null)
        {
            Debug.Log("here");
            _blackboard._agent = GetComponent<NavMeshAgent>();
           _blackboard._agent.updateRotation = false;
           _blackboard._agent.updateUpAxis = false;

            

        }

        return NodeResult.success;
    }

}
