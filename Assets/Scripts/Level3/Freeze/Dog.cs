using UnityEngine;
using TMPro;
using System.Collections;

public class Dog : MonoBehaviour
{
    [Header("���������")]
    public KeyCode interactKey = KeyCode.E;
    public float fadeDuration = 1.0f;

    [Header("������")]
    public TextMeshProUGUI interactionText;
    public TypewriterEffect3_2 dialogueSystem;

    private bool canInteract = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (interactionText) interactionText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            if (interactionText)
            {
                interactionText.text = $"����� {interactKey} ����� ���������";
                interactionText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            if (interactionText) interactionText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(interactKey))
        {
            StartCoroutine(FadeOutAndDisappear());
        }
    }

    private IEnumerator FadeOutAndDisappear()
    {
        // ��������� ��������������
        canInteract = false;
        if (interactionText) interactionText.gameObject.SetActive(false);

        // ������� ������������
        float timer = 0;
        Color startColor = spriteRenderer.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, timer / fadeDuration);
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // ���������� ������� �������� ���� ��� ���������
        if (dialogueSystem)
        {
            dialogueSystem.gameObject.SetActive(true); // �������� ������!

            // ��� ���� ���� ��� �������������
            yield return new WaitForEndOfFrame();

            dialogueSystem.StartPostPuzzleDialogue();
        }

        Destroy(gameObject);
    }
}