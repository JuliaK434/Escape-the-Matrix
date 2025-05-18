using UnityEngine;

public class ActivateVentilation : MonoBehaviour
{
    private BoxCollider2D _doorTrigger;

    private void OnEnable()
    {
        Task1Manager.Task1Success += ActivateVentilationTrigger;
    }
    void Start()
    {
        _doorTrigger = GetComponent<BoxCollider2D>();

    }

   private void ActivateVentilationTrigger()
    {
        _doorTrigger.isTrigger = true;
    }
    private void OnDisable()
    {
        Task1Manager.Task1Success -= ActivateVentilationTrigger;
    }
}
