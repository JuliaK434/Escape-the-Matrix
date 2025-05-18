using UnityEngine;

public class Player: MonoBehaviour 
{
    public static Player Instance { get; private set; } 
    [SerializeField]private float movingSpeed = 5f;
    private Rigidbody2D rb;
    private bool canMove = true;


    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;
    private void Awake(){
        Instance = this;
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        if (canMove)
        { // Проверяем, можно ли двигаться
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        isRunning = (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed);
    }

    // Метод для внешнего управления движением
    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public Vector3 GetPlayerScreenPosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    public void OnDisable()
    {
        Destroy(Player.Instance);
    }
}

