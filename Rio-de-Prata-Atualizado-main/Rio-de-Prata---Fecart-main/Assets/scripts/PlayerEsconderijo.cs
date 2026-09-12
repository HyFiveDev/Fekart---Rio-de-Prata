using UnityEngine;

public class PlayerEsconderijo : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] public bool protegido = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Entrou no esconderijo
        if (other.CompareTag("Esconderijo1"))
        {
            protegido = true;
            Debug.Log("Player protegido");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Saiu do esconderijo
        if (other.CompareTag("Esconderijo1"))
        {
            protegido = false;
            Debug.Log("Player desprotegido");
        }
    }
}