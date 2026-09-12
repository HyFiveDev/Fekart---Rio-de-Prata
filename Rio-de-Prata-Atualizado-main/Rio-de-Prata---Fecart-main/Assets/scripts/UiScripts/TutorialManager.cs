using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    //public static TutorialManager Instance;

    public GameObject tutorialPanel;
    public TextMeshProUGUI tutorialText;

    [TextArea(2, 4)]
    public List<string> mensagens; // Apenas a lista de textos dos passos

    [SerializeField] private int passoAtual = -1;

    void Awake()
    {
        //Instance = this;
        tutorialPanel.SetActive(false);
    }

    public void IniciarTutorial()
    {
        print("tutorial iniciado!");
        tutorialPanel.SetActive(true);
        MostrarPasso();
    }

    void MostrarPasso()
    {
        passoAtual++;
        print("Passo atual:" + passoAtual);
        tutorialText.text = mensagens[passoAtual];
        print("passo mostrado.");
    }

    public void FinalizarTutorial()
    {
        tutorialText.text = ""; // A frase some ao finalizar
        tutorialPanel.SetActive(false);
    
    }
}
