using UnityEngine;

public class WinScript:MonoBehaviour
{
    int fullElement;
    public static int myElement;
    public GameInput Puzzle;
    public GameObject Panel;
    public GameObject winPannel;

    void Start()
    {
        fullElement = Puzzle.transform.childCount;    
    }

    private void Update()
    {
        if (fullElement == myElement)
        {
            Panel.SetActive(false);
            winPannel.SetActive(true);
        }
    }
    public static void AddElement()
    {
        myElement++;
    }
}
