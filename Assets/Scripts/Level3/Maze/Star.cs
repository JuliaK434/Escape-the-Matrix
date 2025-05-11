using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StarManager.Instance.CollectStar();
            Destroy(gameObject);
        }
    }
}