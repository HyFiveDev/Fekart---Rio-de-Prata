using UnityEngine;

public class InimigoComum : MonoBehaviour
{
    public float velocidade = 3f;

    [Header("Referências")]
    public Transform player;

    private bool perseguindo = false;

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

            transform.position = Vector3.MoveTowards(
                transform.position,
                posicaoDestino,
                velocidade * Time.deltaTime
            );
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
}