using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public int buttonIndex;
    public ColorButtonPuzzle puzzleManager;

    void OnMouseDown()
    {
        puzzleManager.OnButtonClicked(buttonIndex);
    }
}