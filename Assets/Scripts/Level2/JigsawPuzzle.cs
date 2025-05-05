using UnityEngine;
using System.Collections.Generic;

public class JigsawPuzzle : MonoBehaviour
{
    [Header("���������")]
    [SerializeField] private List<GameObject> puzzlePieces; // ��� ������� �����
    [SerializeField] private Transform puzzleArea; // ������������ ������
    [SerializeField] private float snapDistance = 50f; // ��������� ���������� (� ��������)
    [SerializeField] private GameObject completeImage; // ������ �����������

    private Dictionary<GameObject, Vector2> originalPositions = new Dictionary<GameObject, Vector2>();
    private int correctPieces = 0;

    void Start()
    {
        completeImage.SetActive(false);
        InitializePuzzle();
    }

    private void InitializePuzzle()
    {
        Debug.Log($"������� {"Image(25)"}: {"originalPositions[Image(25)"}");
        foreach (var piece in puzzlePieces)
        {
            // ��������� ������������ �������
            originalPositions[piece] = piece.GetComponent<RectTransform>().anchoredPosition;

            // ������������
            piece.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(
                    Random.Range(-300f, 300f),
                    Random.Range(-200f, 200f)
                );

            // ��������� ���������� ��������������
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
            // ��������� �������
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
        Debug.Log("���� ������!");
        // �������������� �������� (����, ��������)
    }
}