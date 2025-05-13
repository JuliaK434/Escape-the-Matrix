using UnityEngine;

public class Phone : MonoBehaviour

{
    public TypewriterEffect3 typewriter;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInteraction3>().hasPhone = true;
            Destroy(gameObject);
            TypewriterEffect3 typewriter = FindObjectOfType<TypewriterEffect3>(true);
            if (typewriter != null)
            {
                typewriter.gameObject.SetActive(true);
                typewriter.StartPostPuzzleDialogue();
            }
        }
    }
}
