using System.Collections;
using Unity.Hierarchy;
using UnityEngine;
public class VisionSensor : MonoBehaviour
{
    public float ViewDistance = 100f;
   
    public LayerMask PlayerMask;
    public LayerMask AnomalyMask;
    public LayerMask ObstacleMask;
    public float updateFrequency;

    private Blackboard blackboard;
    private Collider2D _PlayerCollider;
    private Collider2D _AnomalyCollider;
    void Start()
    {
        blackboard = gameObject.GetComponent<Blackboard>();
        StartCoroutine(VisionRoutine());
    }

    IEnumerator VisionRoutine()
    {
        while (true)
        {

            _PlayerCollider = DetectAnomaly(PlayerMask);
            _AnomalyCollider = DetectAnomaly(AnomalyMask);//DetectItem(AnomalyMask);

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
            yield return new WaitForSeconds(updateFrequency);
        }

    }
    Collider2D DetectItem(LayerMask ItemMask) 
    {
        Collider2D target = Physics2D.OverlapCircle(transform.position, ViewDistance, ItemMask);
        if (target != null)
        {
            Vector2 dirToTarget = (target.transform.position - transform.position).normalized;

            float distanceToTarget = Mathf.Abs(Vector2.Distance(target.transform.position, transform.position));
            float angleToTarget = Vector2.Angle(transform.right, dirToTarget);

            if (angleToTarget < blackboard.ViewAngle / 2)
            {
                Debug.DrawRay(transform.position, dirToTarget *distanceToTarget, Color.red, 1f);
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, dirToTarget, distanceToTarget, ObstacleMask | ItemMask);
                if (hits.Length > 0)
                {
                    RaycastHit2D hit = hits[0];
                    if(hit.collider is CircleCollider2D)
                    {
                        if(hits.Length > 1)
                        {
                            hit = hits[1];
                        }
                        else
                        {
                            return null;
                        }
                    }

                    //Debug.Log(hit.collider is BoxCollider2D);
                    if (((1 << hit.collider.gameObject.layer) & ItemMask) != 0)
                        return hit.collider;
                    if (((1 << hit.collider.gameObject.layer) & ObstacleMask) != 0)
                        return null;
                }
            }
        }
        return null;
    }


    Collider2D DetectAnomaly(LayerMask ItemMask)
    {
        Collider2D[] anomalies = Physics2D.OverlapCircleAll(transform.position, ViewDistance, ItemMask);
        Collider2D nearAnomaly = null;
        float minDistance = Mathf.Infinity;
        foreach (var anomaly in anomalies)
        {
            if(anomaly is CircleCollider2D)
            {
                continue;
            }
            Vector2 dirToTarget = (anomaly.transform.position - transform.position).normalized;
            float distanceToTarget = Vector2.Distance(transform.position, anomaly.transform.position);
            float angleToTarget = Vector2.Angle(transform.right, dirToTarget);

            if (angleToTarget < blackboard.ViewAngle / 2)
            {
                Debug.DrawRay(transform.position, dirToTarget * distanceToTarget, Color.red, 1f);
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, dirToTarget, distanceToTarget, ObstacleMask | ItemMask);
                    foreach (var hit in hits) 
                    {
                        if (((1 << hit.collider.gameObject.layer) & ObstacleMask) != 0)
                            break;

                        if (((1 << hit.collider.gameObject.layer) & ItemMask) != 0)
                        {
                            if (distanceToTarget < minDistance)
                            {
                                nearAnomaly = hit.collider;
                                minDistance = distanceToTarget;
                            }
                        }
                    }
            }
        }
        if(nearAnomaly != null)
        {
            return nearAnomaly;
        }
        return null;
    }
}

