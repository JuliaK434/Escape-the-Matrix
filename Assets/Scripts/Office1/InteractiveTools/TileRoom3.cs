using UnityEngine;
using System.Collections;
public class TileRoom3 : MonoBehaviour
{
    [SerializeField] private GameObject _answerTile;
    [SerializeField] private bool _rightTile;
    [SerializeField] private int _lineNumber;
    public static event System.Action<int> LineActivated;
    public static event System.Action PlayerLose;


    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other is CapsuleCollider2D)
        {
            gameObject.SetActive(false);
            _answerTile.SetActive(true);
            if (!_rightTile)
            {
                PlayerLose?.Invoke();
            }
            else if (_rightTile)
            {
                Debug.Log("Right tile");
                LineActivated?.Invoke(_lineNumber);
            }
        }
    }



}
