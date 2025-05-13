using UnityEngine;
using UnityEngine.SceneManagement;
public class Player: MonoBehaviour 
{
    public static Player Instance { get; private set; } 
    [SerializeField]private float movingSpeed = 5f;
    private Rigidbody2D rb;


    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;

    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    private void Awake(){
        Instance = this;
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        //inputVector = inputVector.normalized;
        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed){
            isRunning = true;
        } else {
            isRunning = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Interactive")
        {
            Debug.Log(collision.gameObject);
            SceneManager.LoadScene(2);
        }
    }

}
