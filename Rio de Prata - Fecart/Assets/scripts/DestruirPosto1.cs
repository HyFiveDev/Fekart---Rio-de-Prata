using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestruirPosto1 : MonoBehaviour
{
    [Header("Objeto que bloqueia o caminho")]

    private bool jogadorPerto;
    private bool destruida = false;
    private InputSystem_Actions inputSystem;
    private InputAction interact;
    
    // imagens  e colliders
    [SerializeField] private GameObject barracaInteira;
    [SerializeField] private GameObject barracaDestruida;
    [SerializeField] private Collider2D collider;
    [SerializeField] private GameObject InteractiveImg;
    [SerializeField] private InimigoEspecial inimigo;
    
    private void Awake()
    {
        inputSystem = new InputSystem_Actions();
        interact = inputSystem.Player.Interact;
        TrocaSprite();
    }

    private void OnEnable() {interact.Enable();}
    private void OnDisable() {interact.Disable();}


    private void Update()
    {
        if (jogadorPerto && !destruida && interact.WasPressedThisFrame())
        {
            DestruirBarraca();
        }

        if (destruida)
        {
            InteractiveImg.SetActive(false);
        }
    }

    private void DestruirBarraca()
    {
        destruida = true;
        TrocaSprite();
        collider.enabled = false;
        inimigo.AtivarPerseguicao();
        
    }

    private void TrocaSprite()
    {
        barracaDestruida.SetActive(destruida);
        barracaInteira.SetActive(!destruida);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (destruida) return;
            jogadorPerto = true;
            InteractiveImg.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (destruida) return;
            jogadorPerto = false;
            InteractiveImg.SetActive(false);
        }
    }
}