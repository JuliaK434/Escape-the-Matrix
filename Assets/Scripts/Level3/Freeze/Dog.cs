using UnityEngine;

public class Dog : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public Animator dogAnimator;
    private bool canInteract = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerInteraction3.hasBone)
        {
            canInteract = true;
            Debug.Log("Нажми E, чтобы покормить собаку");
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(interactKey))
        {
            dogAnimator.SetTrigger("Eat");
            PlayerInteraction3.hasBone = false; // Еда использована
            Debug.Log("Собака счастлива! Квест завершён.");
        }
    }
}