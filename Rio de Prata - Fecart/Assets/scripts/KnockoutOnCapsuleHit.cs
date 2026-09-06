using UnityEngine;

public class KnockoutOnCapsuleHit : MonoBehaviour
{
    [Header("Configuração")]
    public bool nocauteado = false;

    [Header("Componentes")]
    private Rigidbody2D rb;

    [SerializeField] private EnemyAnimScripts anim;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que bateu possui CapsuleCollider2D
        CapsuleCollider2D capsule = collision.collider.GetComponent<CapsuleCollider2D>();

        if (capsule != null)
        {
            EntrarEmNocaute();
        }
    }

    private void EntrarEmNocaute()
    {
        // Evita executar novamente
        if (nocauteado)
            return;

        nocauteado = true;

        // Para completamente o movimento físico
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        // Ativa a animação de nocaute
            anim.Atordoar(nocauteado);
        

        // Desativa os scripts que controlam o personagem
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts)
        {
            if (script != this)
            {
                script.enabled = false;
            }
        }

        Debug.Log("Personagem entrou em estado de NOCAUTEADO!");
    }
}