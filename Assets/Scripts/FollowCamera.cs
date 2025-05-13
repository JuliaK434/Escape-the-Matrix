using UnityEngine;
public class FollowCamera : MonoBehaviour
{
    private Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = _player.position.x;
        temp.y = _player.position.y;
        transform.position = temp;

    }
}
