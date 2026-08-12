using UnityEngine;
using UnityEngine.InputSystem;

public class Transforma : MonoBehaviour
{
    [Header("Transformações")]
    [SerializeField] private GameObject humano;
    [SerializeField] private GameObject arara;
    [SerializeField] private GameObject macaco;
    
    //imagens de transformação
    [SerializeField] private GameObject imagemArara;
    [SerializeField] private GameObject imagemMacaco;
    [SerializeField] private GameObject imagemHumano;
    
    [Header("Estado Atual")]
    // 1 = Humano
    // 2 = Arara
    // 3 = Macaco
    public int transformacaoAtual = 1;

    // NOVO NOME DO INPUT SYSTEM
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
        if (transformacaoAtual == 2) return;
        
        imagemArara.SetActive(true);
        imagemMacaco.SetActive(false);
        imagemHumano.SetActive(false);
        
        humano.SetActive(false);
        macaco.SetActive(false);
        arara.SetActive(true);

        transformacaoAtual = 2;

        Debug.Log("Transformação Atual = ARARA");
    }

    // =========================
    // MACACO
    // =========================

    private void VirarMacaco(InputAction.CallbackContext context)
    {
        if (transformacaoAtual == 3) return;

        imagemArara.SetActive(false);
        imagemMacaco.SetActive(true);
        imagemHumano.SetActive(false);
        
        humano.SetActive(false);
        arara.SetActive(false);
        macaco.SetActive(true);

        transformacaoAtual = 3;

        Debug.Log("Transformação Atual = MACACO");
    }

    // =========================
    // HUMANO
    // =========================

    private void VirarHumano(InputAction.CallbackContext context)
    {
        if (transformacaoAtual == 1) return;

        imagemArara.SetActive(false);
        imagemMacaco.SetActive(false);
        imagemHumano.SetActive(true);
        
        humano.SetActive(true);
        arara.SetActive(false);
        macaco.SetActive(false);

        transformacaoAtual = 1;

        Debug.Log("Transformação Atual = HUMANO");
    }
}