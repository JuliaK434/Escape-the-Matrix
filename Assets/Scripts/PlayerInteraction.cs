using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public GameObject puzzleMenu;

    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            var wardrobes = FindObjectsByType<WardrobeTrigger>(FindObjectsSortMode.None);

            foreach (var wardrobe in wardrobes)
            {
                if (wardrobe.CanInteract())
                {
                    TogglePuzzleMenu();
                    return;
                }
            }
        }
    }

    void TogglePuzzleMenu()
    {
        bool isMenuActive = !puzzleMenu.activeSelf;
        puzzleMenu.SetActive(isMenuActive);
        Player.Instance.SetCanMove(!isMenuActive);

    }
}