using UnityEngine;
public class VisionSensor : MonoBehaviour
{
    public float ViewDistance = 10f;
   
    public LayerMask PlayerMask;
    public LayerMask AnomalyMask;
    public LayerMask ObstacleMask;


    private Blackboard blackboard;
    private bool SeeItem;
    private Collider2D _PlayerCollider;
    private Collider2D _AnomalyCollider;

    private bool SeeFlag;
    void Start()
    {
        blackboard = gameObject.GetComponent<Blackboard>();

    }

    void Update()
    {
       _PlayerCollider = DetectItem(PlayerMask);
       _AnomalyCollider = DetectItem(AnomalyMask);

        if (_AnomalyCollider != null)
        {
            blackboard.AnomalyPosition = _AnomalyCollider.transform.position;
            blackboard.SeeAnomaly = true;
        }
        if (_PlayerCollider != null)
        {
            if(!SeeFlag)
                Debug.Log("VisionSensor: See palyer");
            SeeFlag = true;
            blackboard.lastKnownPlayerPosition = _PlayerCollider.transform.position;
            blackboard.SeePlayer = true;
        }
        else
        {
            blackboard.SeePlayer = false;

            if (SeeFlag)
                Debug.Log("VisionSensor: Dont see palyer");
            SeeFlag = false;
        }

    }
    Collider2D DetectItem(LayerMask ItemMask) 
    {
        Collider2D target = Physics2D.OverlapCircle(transform.position, ViewDistance, ItemMask);

        if (target != null)
        {
            Vector2 dirToTarget = (target.transform.position - transform.position).normalized;
            float angleToTarget = Vector2.Angle(transform.right, dirToTarget);

            if (angleToTarget < blackboard.ViewAngle / 2)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, dirToTarget, ViewDistance, ObstacleMask);
                if (hit.collider == null)
                {
                    return target;
                }
            }
        }

        return null;
    }
}

