using UnityEngine;

public class ActivateVentilation : MonoBehaviour
{
    private static bool _ventilationOpened = false;
    private BoxCollider2D _doorTrigger;

    private void OnEnable()
    {
        Task1Manager.Task1Success += ActivateVentilationTrigger;
    }
    void Start()
    {
        _doorTrigger = GetComponent<BoxCollider2D>();
        if (_ventilationOpened) 
        {
            _doorTrigger.isTrigger = true;
        }


    }

   private void ActivateVentilationTrigger()
    {
        _doorTrigger.isTrigger = true;
        _ventilationOpened = true;
    }
    private void OnDisable()
    {
        Task1Manager.Task1Success -= ActivateVentilationTrigger;
    }
}
