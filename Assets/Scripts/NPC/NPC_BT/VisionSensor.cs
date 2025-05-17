using Unity.VisualScripting;
using UnityEngine;
public class VisionSensor : MonoBehaviour
{
    public float ViewDistance = 5f;
   
    public LayerMask PlayerMask;
    public LayerMask AnomalyMask;
    public LayerMask ObstacleMask;


    private Blackboard blackboard;
    private Collider2D _PlayerCollider;
    private Collider2D _AnomalyCollider;
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
            blackboard.AnomalyObject = _AnomalyCollider.gameObject;
            //Debug.Log(blackboard.AnomalyObject.name == "Fire");
        }
        if (_PlayerCollider != null)
        {
            blackboard.lastKnownPlayerPosition = _PlayerCollider.transform.position;
            blackboard.SeePlayer = true;
        }
        else
        {
            blackboard.SeePlayer = false;

        }

    }
    Collider2D DetectItem(LayerMask ItemMask) 
    {
        //Debug.Log(ViewDistance);

        Collider2D target = Physics2D.OverlapCircle(transform.position, ViewDistance, ItemMask);
        if (target != null)
        {
            Vector2 dirToTarget = (target.transform.position - transform.position).normalized;

            float distanceToTarget = Mathf.Abs(Vector2.Distance(target.transform.position, transform.position));
            if (distanceToTarget < ViewDistance) 
            {
                ViewDistance = distanceToTarget;
            }

            float angleToTarget = Vector2.Angle(transform.right, dirToTarget);

            if (angleToTarget < blackboard.ViewAngle / 2)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, dirToTarget, ViewDistance, ObstacleMask);
                if (hit.collider == null)
                {
                    return target;
                }
                else
                {
                  //  Debug.Log(hit.collider.gameObject);
                }
            }
        }

        else
        {
            ViewDistance = 5f;
        }

        return null;
    }
}

