using System;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class AraraAnim : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private Andar andar;
    private Quaternion rotacaoAtual;
    private Quaternion rotacaoAlvoPos = Quaternion.Euler(0, 0, 30);
    private Quaternion rotacaoAlvoNeg = Quaternion.Euler(0, 0, -30);
    private Quaternion rotacaoZero = Quaternion.Euler(0, 0, 0);
    private Quaternion novaRotacao;
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
        CheckFlying();
        CheckWalking();
    }

    private void FixedUpdate()
    {
        if (andar.isGrounded) transform.rotation = rotacaoAtual;
        if (!sprite.flipX) RotateSprite();
        else if (sprite.flipX) RotateSpriteFlipped();
    }

    private void CheckWalking() => anim.SetBool("isWalking", andar.inputHorizontal != 0f);
    private void CheckFlying() => anim.SetBool("isGrounded", andar.isGrounded);

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

    private void RotateSprite()
    {
        if (andar.inputVertical > 0)
        {
            novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvoPos, 0.01f);
            transform.rotation = novaRotacao;
        }
        else if (andar.inputVertical < 0)
        {
            novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvoNeg, 0.01f);
            transform.rotation = novaRotacao;
        }
        else
        {
            novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoZero, 0.01f);
            transform.rotation = novaRotacao;
        }
    }

    private void RotateSpriteFlipped()
    {
        if (andar.inputVertical > 0)
        {
            novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvoNeg, 0.01f);
            transform.rotation = novaRotacao;
        }
        else if (andar.inputVertical < 0)
        {
            novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvoPos, 0.01f);
            transform.rotation = novaRotacao;
        }
        else
        {
            novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoZero, 0.01f);
            transform.rotation = novaRotacao;
        }


    }
}