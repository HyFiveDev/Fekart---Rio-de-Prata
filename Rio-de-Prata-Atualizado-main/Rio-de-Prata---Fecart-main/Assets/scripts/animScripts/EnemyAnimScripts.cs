using UnityEngine;

public class EnemyAnimScripts : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void CheckWalking(float moviment)
    {
        anim.SetBool("Walking", moviment != 0);
    }

    public void Flip(float moviment, SpriteRenderer sprite)
    {
        if (moviment < 0) Debug.Log("menor que 0"); sprite.flipX = true;
        if (moviment > 0) Debug.Log("maior que 0"); sprite.flipX = false;

    }

    public void Atordoar(bool atordoado)
    {
        anim.SetBool("Nocauteado", atordoado);
    }
}
