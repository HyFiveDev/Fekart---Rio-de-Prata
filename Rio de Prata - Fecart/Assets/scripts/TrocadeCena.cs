using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocadeCena : MonoBehaviour
{
    [SerializeField] GameObject telaMorte;
    [SerializeField] private Andar player;
    public void IrParaFase()
    {
        SceneManager.LoadScene("Fase 01");
    }

    public void Reiniciar()
    {
        player.VoltarParaCheckpoint();
        telaMorte.SetActive(false);
        Time.timeScale = 1;
    }

}