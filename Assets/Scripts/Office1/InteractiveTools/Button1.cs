using UnityEngine;

public class Button1 : MonoBehaviour
{
    [SerializeField] GameObject _fire;

    public static event System.Action<bool> IsFire;

    void Start()
    {
        _fire.SetActive(false);
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if ( (collision.tag == "Player" && collision is CapsuleCollider2D ) || collision.tag == "Book")
        {
            _fire.SetActive(true);
            IsFire?.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if((collision.tag == "Player" && collision is CapsuleCollider2D) || collision.tag != "Book")
        {
            _fire.SetActive(false);
            IsFire?.Invoke(false);
        }
        
        
    }
}
