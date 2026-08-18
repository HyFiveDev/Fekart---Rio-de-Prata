using UnityEngine;

public class PlayerAnimScripts : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private Andar andar;

    private Animator anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipSprite();
        CheckWalking();
        CheckGrounded();
    }

    private void CheckWalking()
    {
        anim.SetBool("isWalking", andar.inputHorizontal != 0f);
    }
    
    private void CheckGrounded()
    {
        anim.SetBool("isGrounded", andar.isGrounded);
    }

    private void FlipSprite()
    {
        if (andar.inputHorizontal < 0)
        {
            sprite.flipX = true;
        }
        else if (andar.inputHorizontal > 0)
        {
            sprite.flipX = false;
        }
    }
}
