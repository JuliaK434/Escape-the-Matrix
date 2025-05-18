using TMPro;
using UnityEngine;

public class PlayerInteractionOffice1 : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    [SerializeField] private TextMeshProUGUI _FirstComputerPassword;
    [SerializeField] private TextMeshProUGUI _SecondComputerPassword;
    [SerializeField] private TextMeshProUGUI _LastComputerPassword;
    private WardrobeTrigger _currentWardrobe;
    private ThrowController _throwController;


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Wardrobe") || other.CompareTag("Book"))
        {
            if (Input.GetKeyDown(interactionKey))
            {
                Debug.Log("Take Wardrobe");
                Debug.Log(other.gameObject);
                _throwController = GetComponent<ThrowController>();
                _throwController.SetHasBottle();
                //_throwController.throwablePrefab = other.gameObject;
                other.gameObject.SetActive(false);
            }
        }
        if (other.CompareTag("Computer1"))
        {
            if (Input.GetKeyDown(interactionKey))
            {
                _FirstComputerPassword.gameObject.SetActive(true);
            }
        }

        if (other.CompareTag("Computer2"))
        {
            if (Input.GetKeyDown(interactionKey))
            {
                _SecondComputerPassword.gameObject.SetActive(true);
            }
        }

        if (other.CompareTag("Computer3"))
        {
            if (Input.GetKeyDown(interactionKey))
            {
                _LastComputerPassword.gameObject.SetActive(true);
            }
        }

        if (other.CompareTag("MainComputer"))
        {
            if (Input.GetKeyDown(interactionKey))
            {
                if (Task1Manager.Instance != null)
                {
                    Debug.Log("Almost open computer");
                    Task1Manager.Instance.OpenComputer();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wardrobe") || other.CompareTag("Book"))
        {
            _currentWardrobe = other.GetComponent<WardrobeTrigger>();
           // Debug.Log(_currentWardrobe);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wardrobe") || other.CompareTag("Book"))
        {
            _currentWardrobe = null;
        }

        if (other.CompareTag("Computer1"))
        {
            _FirstComputerPassword.gameObject.SetActive(false);
        }

        if (other.CompareTag("Computer2"))
        {
            _SecondComputerPassword.gameObject.SetActive(false);
        }

        if (other.CompareTag("Computer3"))
        {
            _LastComputerPassword.gameObject.SetActive(false);
        }
    }


}