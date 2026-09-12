using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCena : MonoBehaviour
{
    [SerializeField] GameObject telaMorte;
    [SerializeField] private GameObject contadorBarraca;
    [SerializeField] private Andar player;
    [SerializeField] private ContagemDeBarracas contagem;
    public void IrParaFase()
    {
        SceneManager.LoadScene("Fase 01");
        Time.timeScale = 1;
    }

    public void Morte()
    {
        telaMorte.SetActive(true);
        contadorBarraca.SetActive(false);
        Time.timeScale = 0;
    }

    public void Reiniciar()
    {
        player.VoltarParaCheckpoint();
        telaMorte.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (contagem.barracasDestruidas == 3)
        {
            SceneManager.LoadScene("Vitoria");
        }
    }
}