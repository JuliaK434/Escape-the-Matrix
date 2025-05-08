using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButtonPuzzle : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttons; // Список кнопок
    [SerializeField] private List<int> sequence; // Загаданная последовательность
    [SerializeField] private int playerStep = 0; // Текущий шаг игрока
    [SerializeField] private Text hintText; // Текст подсказки
    [SerializeField] private float highlightTime = 0.5f; // Время подсветки кнопки

    private bool inputEnabled = false; // Разрешён ли ввод игроку

    void Start()
    {
        StartCoroutine(GenerateSequence());
    }

    // Генерирует случайную последовательность
    IEnumerator GenerateSequence()
    {
        sequence = new List<int>();
        for (int i = 0; i < 3; i++) // Например, последовательность из 4 кнопок
        {
            sequence.Add(Random.Range(0, buttons.Count));
        }

        hintText.text = "Запомните последовательность!";
        yield return new WaitForSeconds(1f);

        // Подсвечиваем кнопки по очереди
        foreach (int index in sequence)
        {
            yield return StartCoroutine(HighlightButton(index));
        }

        hintText.text = "Повторите последовательность!";
        inputEnabled = true;
    }

    // Подсвечивает кнопку (например, меняет цвет или масштаб)
    IEnumerator HighlightButton(int index)
    {
        SpriteRenderer buttonRenderer = buttons[index].GetComponent<SpriteRenderer>();
        Color originalColor = buttonRenderer.color;
        Vector3 originalScale = buttons[index].transform.localScale;
        buttons[index].transform.localScale = originalScale * 1.2f; // Увеличение
        buttonRenderer.color = Color.white; // Яркий цвет // Подсветка (можно добавить анимацию)

        yield return new WaitForSeconds(highlightTime);

        buttonRenderer.color = originalColor;
        buttons[index].transform.localScale = originalScale;
    }

    // Вызывается при нажатии на кнопку (вешается на кнопки)
    public void OnButtonClicked(int buttonIndex)
    {
        if (!inputEnabled) return;

        StartCoroutine(HighlightButton(buttonIndex));

        if (sequence[playerStep] == buttonIndex)
        {
            playerStep++;
            if (playerStep >= sequence.Count)
            {
                hintText.text = "Победа! Последовательность верна!";
                inputEnabled = false;
                // Можно добавить перезапуск или переход на другую сцену
            }
        }
        else
        {
            hintText.text = "Ошибка! Попробуйте ещё раз.";
            playerStep = 0;
            StartCoroutine(RestartPuzzle());
        }
    }

    // Перезапуск головоломки
    IEnumerator RestartPuzzle()
    {
        inputEnabled = false;
        yield return new WaitForSeconds(2f);
        StartCoroutine(GenerateSequence());
    }
}