using UnityEngine;
using UnityEngine.InputSystem;

public class PegarItens : MonoBehaviour
{
    [SerializeField] private Transform pontoSegurar;
    [SerializeField] private float forcaArremesso = 10f;
    private Rigidbody2D rb;
     private InputSystem_Actions inputSystem;
    private InputAction interact, throwAction;

    private GameObject itemCarregado;

    private void Awake()
    {
       
        inputSystem = new InputSystem_Actions();
  

        interact = inputSystem.Player.Interact;
        throwAction = inputSystem.Player.Attack;
    }
    private void OnEnable()
    {
        interact.Enable();
        throwAction.Enable();
    }

    private void OnDisable()
    {
        interact.Disable();
        throwAction.Disable();
    }

    private void Update()
    {
        if (throwAction.triggered && itemCarregado != null)
        {
            itemCarregado.transform.parent = null;

            rb.simulated = true;
            rb.linearVelocity = transform.right * forcaArremesso;

            itemCarregado = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item") && itemCarregado == null)
        {
                itemCarregado = other.gameObject;
                rb = itemCarregado.GetComponent<Rigidbody2D>();

                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0;
                rb.simulated = false;
                
                itemCarregado.transform.SetParent(pontoSegurar);
                itemCarregado.transform.localPosition = Vector3.zero;
        }
    }
}

