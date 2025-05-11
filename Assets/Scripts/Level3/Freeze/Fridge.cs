using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class FridgeTrigger : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public GameObject hintText; 
    public float hintDisplayDistance = 2f; 

    private bool canInteract = false;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (hintText != null)
            hintText.SetActive(false);
    }

    private void Update()
    {
        if (canInteract)
        {
            float distance = Vector2.Distance(transform.position, playerTransform.position);
            if (hintText != null)
                hintText.SetActive(distance <= hintDisplayDistance);

            if (Input.GetKeyDown(interactKey))
            {
                SceneManager.LoadScene("Fredge");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            if (hintText != null)
                hintText.SetActive(false);
        }
    }
}