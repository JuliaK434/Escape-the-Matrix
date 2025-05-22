using UnityEngine;

public class Room3Visibility : MonoBehaviour
{
    private DoorTrigger _doorTrigger;
    [SerializeField] private GameObject _room;
    void Start()
    {
        _room.SetActive(false);
        _doorTrigger = gameObject.GetComponent<DoorTrigger>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other is BoxCollider2D)
        {
            _doorTrigger.UnlockDoor();
            _room.SetActive(true);
        }
    }
}
