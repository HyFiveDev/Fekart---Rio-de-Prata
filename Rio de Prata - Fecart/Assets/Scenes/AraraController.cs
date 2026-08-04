using UnityEngine;


public class AraraController : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float jumpForce = 5f;
    private InputSystem_Actions moveAction;
    [SerializeField] private Andar andar;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movimento;

    private void Awake()
    {
        moveAction = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        moveAction.Player.Move.Enable();
    }

    private void OnDisable()
    {
        moveAction.Player.Move.Disable();
    }

    private void Update()
    {
        movimento = moveAction.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (!andar.isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            rb.linearVelocity = movimento.normalized * velocidade;
        }
    }
}
