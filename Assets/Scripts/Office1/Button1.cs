using UnityEngine;

public class Button1 : MonoBehaviour
{
    [SerializeField] GameObject _fire;
    void Start()
    {
        _fire.SetActive(false);
    }
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Untagged" && collision is CapsuleCollider2D)
        {
            _fire.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision is CapsuleCollider2D)
        {
            _fire.SetActive(false);
        }
        
        
    }
}
