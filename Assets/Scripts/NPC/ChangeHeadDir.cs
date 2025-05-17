using UnityEngine;
using UnityEngine.AI;

public class ChangeHeadDir: MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (_agent != null)
        {
            if (_agent.destination.x <= _agent.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -0, 0);
            }
        }
    }
}
