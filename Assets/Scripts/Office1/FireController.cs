using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private GameObject[] _fires;
    void OnEnable()
    {
        TileRoom3.LineActivated += DeactivateFire;
    }
    private void DeactivateFire(int FireNumber)
    {
        if (_fires[FireNumber] != null)
        {
            _fires[FireNumber].SetActive(false);
        }
    }
    private void OnDisable()
    {
        TileRoom3.LineActivated -= DeactivateFire;
    }
}
