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
            Debug.Log("����� E, ����� ��������� ������");
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(interactKey))
        {
            dogAnimator.SetTrigger("Eat");
            PlayerInteraction3.hasBone = false; // ��� ������������
            Debug.Log("������ ���������! ����� ��������.");
        }
    }
}