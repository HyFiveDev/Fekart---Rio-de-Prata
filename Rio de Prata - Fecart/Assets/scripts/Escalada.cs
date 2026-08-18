using UnityEngine;

/*
 * ==============================================================================
 * GUIA DE CONFIGURAÇÃO DO PLAYER (MACACO):
 * 1. Rigidbody 2D: Body Type = Dynamic | Collision Detection = Continuous | Freeze Rotation Z = Marcado.
 * 2. Capsule Collider 2D: Is Trigger = Desmarcado (para não atravessar o chão).
 * 3. Layer: Pode ser "Default" ou "Player".
 * * GUIA DE CONFIGURAÇÃO DA ÁRVORE:
 * 1. Layer: Crie uma Layer chamada "Escalavel" e coloque a árvore nela.
 * 2. Box Collider 2D: Is Trigger = MARCADO (Obrigatório para o macaco entrar na área).
 * 3. Sprite Renderer: Order in Layer = 0 (ou uma camada atrás do Player).
 * * CONFIGURAÇÃO DO UNITY (IMPORTANTE):
 * Vá em Edit > Project Settings > Player > Other Settings > Active Input Handling
 * Mude para "Both" e reinicie o Unity para o erro de Input sumir.
 * ==============================================================================
 */


public class MonkeyClimb : MonoBehaviour
{
    [Header("Configurações de Velocidade")]
    public float climbSpeed = 5f;
    public float moveSpeed = 5f;

    [Header("Detecção da Árvore")]
    [Tooltip("Selecione a Layer 'Escalavel' aqui")]
    public LayerMask climbableLayer;
    [Tooltip("Tamanho do círculo de detecção (verde na Scene)")]
    public float detectionRadius = 1f;

    [Header("Input")]
    private InputSystem_Actions moveAction;

    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    private float inputVertical;
    private float inputHorizontal;
    private bool isTouchingClimbable;
    private bool isClimbing;
    private float defaultGravity;

    void Awake()
    {
        moveAction = new InputSystem_Actions();
        defaultGravity = rb.gravityScale;

        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    private void OnEnable()
    {
        moveAction.Player.Move.Enable();
    }

    private void OnDisable()
    {
        moveAction.Player.Move.Disable();
    }

    void Update()
    {
        movement = moveAction.Player.Move.ReadValue<Vector2>();
        inputHorizontal = movement.x;
        inputVertical = movement.y;

        isTouchingClimbable = Physics2D.OverlapCircle(transform.position, detectionRadius, climbableLayer);

        if (isTouchingClimbable && Mathf.Abs(inputVertical) > 0.1f)
        {
            isClimbing = true;
        }

        if (!isTouchingClimbable)
        {
            isClimbing = false;
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(inputHorizontal * moveSpeed, inputVertical * climbSpeed);
        }
        else
        {
            rb.gravityScale = defaultGravity;
            rb.linearVelocity = new Vector2(inputHorizontal * moveSpeed, rb.linearVelocity.y);
        }
    }

   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}