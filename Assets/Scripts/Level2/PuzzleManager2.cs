/*using UnityEngine;

public class BookPuzzleManager : MonoBehaviour
{
    public GameObject puzzlePanel;
    public GameObject winPanel;
    public TypewriterEffect2 dialogueSystem;

    public static BookPuzzleManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OpenPuzzle()
    {
        Debug.Log($"Puzzle elements: {puzzlePanel.transform.GetChild(0).childCount}");
        foreach (Transform piece in puzzlePanel.transform.GetChild(0))
        {
            Debug.Log($"Piece: {piece.name}, active: {piece.gameObject.activeSelf}");
        }
        puzzlePanel.SetActive(true);
        winPanel.SetActive(false);
        WinScript.myElement = 0;
        Player.Instance.SetCanMove(false);
        Transform puzzleParent = puzzlePanel.transform.Find("Puzzle");
        

        foreach (Transform piece in puzzleParent)
        {
            piece.gameObject.SetActive(true);
        }
        var canvasGroup = puzzlePanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = puzzlePanel.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public void PuzzleCompleted()
    {
        winPanel.SetActive(true);
        Invoke("FinishPuzzle", 2f);
    }

    private void FinishPuzzle()
    {
        puzzlePanel.SetActive(false);
        winPanel.SetActive(false);
        Player.Instance.SetCanMove(true);
        dialogueSystem.StartPostPuzzleDialogue();
    }
}*/