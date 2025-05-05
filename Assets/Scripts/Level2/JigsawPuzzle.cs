using UnityEngine;
using System.Collections.Generic;

public class JigsawPuzzle : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private List<GameObject> puzzlePieces; // Все кусочки пазла
    [SerializeField] private Transform puzzleArea; // Родительский объект
    [SerializeField] private float snapDistance = 50f; // Дистанция прилипания (в пикселях)
    [SerializeField] private GameObject completeImage; // Полное изображение

    private Dictionary<GameObject, Vector2> originalPositions = new Dictionary<GameObject, Vector2>();
    private int correctPieces = 0;

    void Start()
    {
        completeImage.SetActive(false);
        InitializePuzzle();
    }

    private void InitializePuzzle()
    {
        Debug.Log($"Позиция {"Image(25)"}: {"originalPositions[Image(25)"}");
        foreach (var piece in puzzlePieces)
        {
            // Сохраняем оригинальную позицию
            originalPositions[piece] = piece.GetComponent<RectTransform>().anchoredPosition;

            // Перемешиваем
            piece.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(
                    Random.Range(-300f, 300f),
                    Random.Range(-200f, 200f)
                );

            // Добавляем функционал перетаскивания
            var draggable = piece.AddComponent<DraggablePiece>();
            draggable.Init(this);
        }
    }

    public void CheckPiecePosition(GameObject piece)
    {
        RectTransform rect = piece.GetComponent<RectTransform>();
        Vector2 targetPos = originalPositions[piece];
        float distance = Vector2.Distance(rect.anchoredPosition, targetPos);

        if (distance < snapDistance)
        {
            // Фиксируем кусочек
            rect.anchoredPosition = targetPos;
            piece.GetComponent<CanvasGroup>().blocksRaycasts = false;

            correctPieces++;
            if (correctPieces == puzzlePieces.Count)
            {
                PuzzleCompleted();
            }
        }
    }

    private void PuzzleCompleted()
    {
        completeImage.SetActive(true);
        Debug.Log("Пазл собран!");
        // Дополнительные действия (звук, анимация)
    }
}