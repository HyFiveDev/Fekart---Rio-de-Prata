using UnityEngine;
using UnityEngine.UI;

public class Inimigo : MonoBehaviour
{
    public float velocidade = 3f;

    [Header("Referências")]
    public Transform player;
    public PlayerEsconderijo playerScript;

    [Header("Imagens")]
    public GameObject imagem1;
    public GameObject imagem2;

    [Header("Colliders")]
    public Collider2D collider1;
    public Collider2D collider2;

    [Header("Timer")]
    public float tempoTroca = 15f;

    private bool perseguindo = false;

    // Controla qual imagem/collider está ativo
    private bool usandoImagem1 = true;

    private float timer;

    void Start()
    {
        timer = tempoTroca;

        AtualizarEstado();
    }

    void Update()
    {
        // TIMER
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            usandoImagem1 = !usandoImagem1;

            AtualizarEstado();

            timer = tempoTroca;
        }

        // MOVIMENTO
        if (perseguindo)
        {
            Vector3 posicaoDestino = new Vector3(
                player.position.x,
                transform.position.y,
                transform.position.z
            );

            transform.position = Vector3.MoveTowards(
                transform.position,
                posicaoDestino,
                velocidade * Time.deltaTime
            );
        }
    }

    void AtualizarEstado()
    {
        // Alterna imagens
        imagem1.SetActive(usandoImagem1);
        imagem2.SetActive(!usandoImagem1);

        // Alterna colliders
        collider1.enabled = usandoImagem1;
        collider2.enabled = !usandoImagem1;
    }

    // Detecta entrada do player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerScript.protegido == 0)
            {
                perseguindo = true;
            }
        }
    }

    // Enquanto estiver dentro da área
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerScript.protegido == 1)
            {
                perseguindo = false;
            }
            else
            {
                perseguindo = true;
            }
        }
    }

    // Quando sair da área
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            perseguindo = false;
        }
    }
}