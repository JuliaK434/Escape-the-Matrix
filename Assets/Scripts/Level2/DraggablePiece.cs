using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePiece : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private JigsawPuzzle puzzleManager;
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 startPosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform не найден на объекте: " + gameObject.name);
            return;
        }

        canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Canvas не найден среди родительских объектов: " + gameObject.name);
            return;
        }

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void Init(JigsawPuzzle manager)
    {
        if (manager == null)
        {
            Debug.LogError("JigsawPuzzle manager не назначен!");
            return;
        }
        puzzleManager = manager;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (rectTransform == null || canvasGroup == null) return;

        startPosition = rectTransform.anchoredPosition;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (rectTransform == null || canvas == null) return;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canvasGroup == null || puzzleManager == null) return;

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        puzzleManager.CheckPiecePosition(gameObject);
    }
}