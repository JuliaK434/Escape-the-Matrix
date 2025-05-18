using UnityEngine;
using UnityEngine.AI;

public class Blackboard : MonoBehaviour
{
    public bool SeePlayer;
    public float ViewAngle;
    public bool SeeAnomaly;
    public GameObject AnomalyObject;
    public GameObject Button1;
    public Vector3 lastKnownPlayerPosition;
    public Vector3 AnomalyPosition;
    public Vector3 buttonPosition;
    public Transform[] wayPoints;
    public Transform[] reserveWayPoints;
    public bool FireLocation; // 0 - right; 1 - left
    public float StopDistance;
    public float LookAroundTime = 2f;
    public float DetectTime;
    public float ForgetTime;
    public float PatrolSpeed;
    public float ChasingSpeed;
    public NavMeshAgent _agent;
    public float _fixDuration;



    // For animations
    public bool isStay;
    public bool isChase;
    public bool isFix;
    public bool isWalk;
    public bool isAngry;
    public bool isHappy;
    public bool isUse;




}
