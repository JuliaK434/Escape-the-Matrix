using UnityEngine;

public class PlayerInteractionOffice1 : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    private WardrobeTrigger _currentWardrobe;
    private ThrowController _throwController;


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Wardrobe"))
        {
            if (Input.GetKeyDown(interactionKey))
            {
                _throwController = GetComponent<ThrowController>();
                _throwController.SetHasBottle();
                //_throwController.throwablePrefab = other.gameObject;
                other.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wardrobe"))
        {
            _currentWardrobe = other.GetComponent<WardrobeTrigger>();
            Debug.Log(_currentWardrobe);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wardrobe"))
        {
            _currentWardrobe = null;

        }
    }


}