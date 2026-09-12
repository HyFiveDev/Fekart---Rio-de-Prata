using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private Vector2 checkpointAtual;
    private bool possuiCheckpoint = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector2 posicao)
    {
        checkpointAtual = posicao;
        possuiCheckpoint = true;

        Debug.Log("Checkpoint salvo!");
    }

    public Vector2 GetCheckpoint(Vector2 posicaoInicial)
    {
        if (possuiCheckpoint)
            return checkpointAtual;

        return posicaoInicial;
    }

    public void ResetCheckpoint()
    {
        possuiCheckpoint = false;
    }
}