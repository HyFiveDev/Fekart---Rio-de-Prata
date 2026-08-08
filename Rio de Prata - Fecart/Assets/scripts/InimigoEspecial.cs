using UnityEngine;
using UnityEngine.SceneManagement;

public class InimigoEspecial : MonoBehaviour
{
    public float velocidade = 3f;

    [Header("Referências")]
    public Transform player;
    public PlayerEsconderijo playerScript;

    [Header("Posto de Controle")]
    // 0 = não destruído
    // 1 = destruído
    public int postoDestruido = 0;

    [Header("Imagens")]
    public GameObject imagem1;
    public GameObject imagem2;

    [Header("Colliders")] private Collider2D collider;

    [Header("Timer")]
    public float tempoTroca = 15f;

    private bool perseguindo = false;

    // Controla qual imagem/collider está ativo
    private bool usandoImagem1 = true;

    private float timer;

    void Start()
    {
        collider = GetComponent<Collider2D>();
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

        // PERSEGUIÇÃO
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
        collider.enabled = usandoImagem1;
        collider.enabled = !usandoImagem1;
    }

    // Chamado pelo posto de controle quando ele for destruído
    public void AtivarPerseguicao()
    {
        postoDestruido = 1;
        perseguindo = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!playerScript.protegido)
        {
            Debug.Log("GAME OVER");

            // Troque pelo nome da sua cena de Game Over
            SceneManager.LoadScene("GameOver");
        }
    }
}