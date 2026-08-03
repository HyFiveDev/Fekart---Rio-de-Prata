using UnityEngine;
using UnityEngine.InputSystem;

public class Andar : MonoBehaviour
{
    private InputSystem_Actions inputSystemActions;
    private InputAction move;
    private InputAction jump;

    [SerializeField] private Rigidbody2D rb;
    

    public float speed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded;

    [Range(-1f, 1f)] public float inputHorizontal;
    [Range(-1f, 1f)] public float inputVertical;

    void Awake()
    {
        inputSystemActions = new InputSystem_Actions();
        move = inputSystemActions.Player.Move;
        jump = inputSystemActions.Player.Jump;
        
    }

    private void OnEnable() { move.Enable(); jump.Enable(); }
    private void OnDisable() { move.Disable(); jump.Disable(); }

    void Update()
    {
        Vector2 input = move.ReadValue<Vector2>();
        inputHorizontal = input.x;
        inputVertical = input.y;

        // Movimentação
        rb.linearVelocity = new Vector2(inputHorizontal * speed, rb.linearVelocity.y);
        

        // Pulo
        if (isGrounded && jump.triggered)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = false;
    }
}