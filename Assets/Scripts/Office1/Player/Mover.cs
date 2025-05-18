using UnityEngine;

public class Mover : MonoBehaviour
{
    private Vector3 _targetPosition;
    private float _speed;
    private bool _moving = false;

    public void Initialize(Vector3 target, float moveSpeed)
    {
        _targetPosition = target;
        _speed = moveSpeed;
        _moving = true;
    }

    void Update()
    {
        if (!_moving) return;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _targetPosition) < 0.01f)
        {

            transform.position = _targetPosition;
            _moving = false;

        }
    }
}