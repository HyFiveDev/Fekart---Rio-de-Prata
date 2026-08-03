using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Transformacao : MonoBehaviour
{
    [Header("Transformações")]
    [SerializeField] private GameObject humano;
    [SerializeField] private GameObject arara;
    [SerializeField] private GameObject macaco;

    [Header("Configurações")]
    [SerializeField] private float tempoTransformado = 10f;
    [SerializeField] private float cooldownTransformacao = 30f;

    [Header("Estado Atual")]
    
    // 1 = Humano
    // 2 = Arara
    // 3 = Macaco

    public int transformacaoAtual = 1;

    private bool emCooldown = false;

    private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.Arara.performed += VirarArara;
        inputActions.Player.Macaco.performed += VirarMacaco;
        inputActions.Player.Humano.performed += VirarHumano;
    }

    private void OnDisable()
    {
        inputActions.Player.Arara.performed -= VirarArara;
        inputActions.Player.Macaco.performed -= VirarMacaco;
        inputActions.Player.Humano.performed -= VirarHumano;

        inputActions.Disable();
    }
    

    // =========================
    // ARARA
    // =========================

    private void VirarArara(InputAction.CallbackContext context)
    {
        if (emCooldown) return;

        humano.SetActive(false);
        macaco.SetActive(false);
        arara.SetActive(true);

        transformacaoAtual = 2;

        Debug.Log("Transformação Atual = ARARA");

        StartCoroutine(TempoTransformacao());
    }

    // =========================
    // MACACO
    // =========================

    private void VirarMacaco(InputAction.CallbackContext context)
    {
        if (emCooldown) return;

        humano.SetActive(false);
        arara.SetActive(false);
        macaco.SetActive(true);

        transformacaoAtual = 3;

        Debug.Log("Transformação Atual = MACACO");

        StartCoroutine(TempoTransformacao());
    }

    // =========================
    // HUMANO
    // =========================

    private void VirarHumano(InputAction.CallbackContext context)
    {
        if (emCooldown) return;

        VoltarHumano();
    }

    // =========================
    // CORROTINA
    // =========================

    IEnumerator TempoTransformacao()
    {
        emCooldown = true;

        // Espera 10 segundos transformado
        yield return new WaitForSeconds(tempoTransformado);

        // Volta automaticamente
        VoltarHumano();

        // Espera o cooldown
        yield return new WaitForSeconds(cooldownTransformacao);

        emCooldown = false;

        Debug.Log("Cooldown finalizado");
    }

    // =========================
    // VOLTAR HUMANO
    // =========================

    void VoltarHumano()
    {
        arara.SetActive(false);
        macaco.SetActive(false);
        humano.SetActive(true);

        transformacaoAtual = 1;

        Debug.Log("Transformação Atual = HUMANO");
    }
}