using UnityEngine;

public class RoomVisibility : MonoBehaviour
{
    [SerializeField] private GameObject _room;
    private bool _isVisible = false;
    void Start()
    {
        _room.SetActive(false);
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other is BoxCollider2D)
        {
            Debug.Log("Collider Activated");
            if (!_isVisible)
            {
                _room.SetActive(true);
                _isVisible = true;
            }
            else 
            {
                _room.SetActive(false);
                _isVisible = false;
            }
        }
    }

}
