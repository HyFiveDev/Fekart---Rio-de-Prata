using UnityEngine;

using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    public GameObject tutorialPanel;
    public TextMeshProUGUI tutorialText;

    [TextArea(2, 4)]
    public List<string> mensagens; // Apenas a lista de textos dos passos

    private int passoAtual = 0;

    void Awake()
    {
        Instance = this;
        tutorialPanel.SetActive(false);
    }

    public void IniciarTutorial()
    {
        tutorialPanel.SetActive(true);
        MostrarPasso();
        passoAtual++;
    }

    // Chame este método quando o jogador realizar a ação do tutorial atual
    //public void AvancarPasso()
    //{
    //    passoAtual++;

    //    if (passoAtual < mensagens.Count)
    //    {
    //        MostrarPasso();
    //    }
    //    else
    //    {
    //        FinalizarTutorial();
    //    }
    //}

    void MostrarPasso()
    {
        tutorialText.text = mensagens[passoAtual];
    }

    public void FinalizarTutorial()
    {
        tutorialText.text = ""; // A frase some ao finalizar
        tutorialPanel.SetActive(false);
    }
}
