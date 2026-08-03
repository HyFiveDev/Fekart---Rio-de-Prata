using UnityEngine;

public class PlayerEsconderijo : MonoBehaviour
{
    [HideInInspector]
    public int protegido = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Entrou no esconderijo
        if (other.CompareTag("Esconderijo1"))
        {
            protegido = 1;
            Debug.Log("Player protegido");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Saiu do esconderijo
        if (other.CompareTag("Esconderijo1"))
        {
            protegido = 0;
            Debug.Log("Player desprotegido");
        }
    }
}