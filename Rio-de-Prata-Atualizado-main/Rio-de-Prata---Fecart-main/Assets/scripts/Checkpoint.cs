using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool ativado = false;
    [SerializeField] private CheckpointManager checkpoint;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            checkpoint.SetCheckpoint(transform.position);
            ativado = true;
            CheckAnim();
            Debug.Log("Checkpoint ativado!");
        }
    }

    private void CheckAnim()
    {
        anim.SetBool("Ativado", ativado);
    }
}