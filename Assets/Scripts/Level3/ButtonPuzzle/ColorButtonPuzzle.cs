using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButtonPuzzle : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttons; // ������ ������
    [SerializeField] private List<int> sequence; // ���������� ������������������
    [SerializeField] private int playerStep = 0; // ������� ��� ������
    [SerializeField] private Text hintText; // ����� ���������
    [SerializeField] private float highlightTime = 0.5f; // ����� ��������� ������

    private bool inputEnabled = false; // �������� �� ���� ������

    void Start()
    {
        StartCoroutine(GenerateSequence());
    }

    // ���������� ��������� ������������������
    IEnumerator GenerateSequence()
    {
        sequence = new List<int>();
        for (int i = 0; i < 3; i++) // ��������, ������������������ �� 4 ������
        {
            sequence.Add(Random.Range(0, buttons.Count));
        }

        hintText.text = "��������� ������������������!";
        yield return new WaitForSeconds(1f);

        // ������������ ������ �� �������
        foreach (int index in sequence)
        {
            yield return StartCoroutine(HighlightButton(index));
        }

        hintText.text = "��������� ������������������!";
        inputEnabled = true;
    }

    // ������������ ������ (��������, ������ ���� ��� �������)
    IEnumerator HighlightButton(int index)
    {
        SpriteRenderer buttonRenderer = buttons[index].GetComponent<SpriteRenderer>();
        Color originalColor = buttonRenderer.color;
        Vector3 originalScale = buttons[index].transform.localScale;
        buttons[index].transform.localScale = originalScale * 1.2f; // ����������
        buttonRenderer.color = Color.white; // ����� ���� // ��������� (����� �������� ��������)

        yield return new WaitForSeconds(highlightTime);

        buttonRenderer.color = originalColor;
        buttons[index].transform.localScale = originalScale;
    }

    // ���������� ��� ������� �� ������ (�������� �� ������)
    public void OnButtonClicked(int buttonIndex)
    {
        if (!inputEnabled) return;

        StartCoroutine(HighlightButton(buttonIndex));

        if (sequence[playerStep] == buttonIndex)
        {
            playerStep++;
            if (playerStep >= sequence.Count)
            {
                hintText.text = "������! ������������������ �����!";
                inputEnabled = false;
                // ����� �������� ���������� ��� ������� �� ������ �����
            }
        }
        else
        {
            hintText.text = "������! ���������� ��� ���.";
            playerStep = 0;
            StartCoroutine(RestartPuzzle());
        }
    }

    // ���������� �����������
    IEnumerator RestartPuzzle()
    {
        inputEnabled = false;
        yield return new WaitForSeconds(2f);
        StartCoroutine(GenerateSequence());
    }
}