using UnityEngine;
using UnityEngine.AI;

public class Blackboard : MonoBehaviour
{
    public bool SeePlayer;
    public float ViewAngle;
    public bool SeeAnomaly;
    public GameObject AnomalyObject;
    public Vector3 lastKnownPlayerPosition;
    public Vector3 AnomalyPosition;
    public Transform[] wayPoints;
    public float StopDistance;
    public float DetectTime;
    public float PatrolSpeed;
    public float ChasingSpeed;
    public NavMeshAgent _agent;
    public float _fixDuration;



    // For animations
    public bool Patrol;
    public bool Detect;
    public bool PlayerLose;
   


}
