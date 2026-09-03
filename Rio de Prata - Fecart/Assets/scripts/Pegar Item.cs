using UnityEngine;
using UnityEngine.InputSystem;

public class PegarItens : MonoBehaviour
{
    [SerializeField] Transform pontoSegurar;
    [SerializeField] float forcaArremesso = 10f;

    InputSystem_Actions input;
    GameObject itemAlcance;
    GameObject itemCarregado;
    Rigidbody2D itemRb;

    Vector3 posicaoOriginal;
    bool direita = true;

    void Awake()
    {
        input = new InputSystem_Actions();

        if (pontoSegurar)
            posicaoOriginal = pontoSegurar.localPosition;
    }

    void OnEnable()
    {
        input.Player.Interact.Enable();
        input.Player.Attack.Enable();
    }

    void OnDisable()
    {
        input.Player.Interact.Disable();
        input.Player.Attack.Disable();
    }

    void Update()
    {
        if (input.Player.Interact.triggered)
        {
            if (itemCarregado)
                Soltar();
            else if (itemAlcance)
                Pegar();
        }

        if (input.Player.Attack.triggered && itemCarregado)
            Arremessar();
    }

    void Pegar()
    {
        itemCarregado = itemAlcance;
        itemRb = itemCarregado.GetComponent<Rigidbody2D>();

        if (!itemRb) return;

        itemRb.simulated = false;
        itemRb.linearVelocity = Vector2.zero;
        itemRb.angularVelocity = 0;

        itemCarregado.transform.SetParent(pontoSegurar);
        itemCarregado.transform.localPosition = Vector3.zero;
    }

    void Soltar()
    {
        itemCarregado.transform.SetParent(null);
        itemRb.simulated = true;

        itemCarregado = null;
        itemRb = null;
    }

    void Arremessar()
    {
        itemCarregado.transform.SetParent(null);
        itemRb.simulated = true;

        float direcao = direita ? 1 : -1;
        itemRb.linearVelocity = Vector2.right * direcao * forcaArremesso;

        itemCarregado = null;
        itemRb = null;
    }

    public void AtualizarFlip(bool paraDireita)
    {
        direita = paraDireita;

        if (!pontoSegurar) return;

        Vector3 pos = posicaoOriginal;
        pos.x = Mathf.Abs(pos.x) * (direita ? 1 : -1);
        pontoSegurar.localPosition = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
            itemAlcance = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == itemAlcance)
            itemAlcance = null;
    }
}