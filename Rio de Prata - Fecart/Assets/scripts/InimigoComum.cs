using UnityEngine;
using UnityEngine.SceneManagement;

public class InimigoComum : MonoBehaviour
{
    public float velocidade = 3f;

    [Header("Referências")]
    public Transform player;

    private bool perseguindo = false;

    [SerializeField] private GameObject telaMorte;

    [SerializeField] private EnemyAnimScripts anim;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (perseguindo)
        {
            // Move apenas no eixo X
            Vector3 posicaoDestino = new Vector3(
                player.position.x,
                transform.position.y,
                transform.position.z
            );
            anim.Flip(posicaoDestino.x, sprite);
            transform.position = Vector3.MoveTowards(
                transform.position,
                posicaoDestino,
                velocidade * Time.deltaTime
            );
            
            anim.CheckWalking(posicaoDestino.x);
            
        }
    }

    // Quando o player entra na área de detecção
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            perseguindo = true;
        }
    }

    // Quando o player sai da área de detecção
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            perseguindo = false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            telaMorte.SetActive(true);
            Time.timeScale = 0;
        }
    }
}