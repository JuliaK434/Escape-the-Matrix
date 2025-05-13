using UnityEngine;

public class ThrowController : MonoBehaviour
{
    public GameObject throwablePrefab;      
    public float throwSpeed = 10f;          
    public float maxThrowDistance = 10f;   
    public LayerMask obstacleMask;
    private bool _hasBottle;

    public void SetHasBottle()
    {
        Debug.Log("In SetHasBottle");
        _hasBottle = true;
        Debug.Log(_hasBottle);
    }
    void Update()
    {
        if (_hasBottle)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(_hasBottle);
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = 0;

                Vector3 direction = mouseWorldPos - transform.position;
                float distance = direction.magnitude;

                if (distance > maxThrowDistance)
                {
                    direction = direction.normalized * maxThrowDistance;
                    mouseWorldPos = transform.position + direction;
                    distance = maxThrowDistance;
                }

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, distance, obstacleMask);
                if (hit.collider != null)
                {
                    mouseWorldPos = hit.point;
                }

                GameObject thrownObject = Instantiate(throwablePrefab, transform.position, Quaternion.identity);

                thrownObject.AddComponent<Mover>().Initialize(mouseWorldPos, throwSpeed);

                _hasBottle = false;

            }
        }

    }

}