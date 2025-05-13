using UnityEngine;

public class Room3Visibility : MonoBehaviour
{
    [SerializeField] private GameObject _room;
    void Start()
    {
        _room.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Room3 activated");
        if (other.CompareTag("Player") && other is BoxCollider2D)
        {
            _room.SetActive(true);
        }
    }
}
