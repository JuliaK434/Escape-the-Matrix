using UnityEngine;
using UnityEngine.AI;

public class InitNavMeshA : MonoBehaviour
{
    private Blackboard _blackboard;
    
    void Start()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
        _blackboard._agent = gameObject.GetComponent<NavMeshAgent>();
        _blackboard._agent.updateRotation = false;
        _blackboard._agent.updateUpAxis = false;
    }


}
