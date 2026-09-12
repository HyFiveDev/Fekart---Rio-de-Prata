using UnityEngine;

public class ContagemDeBarracas : MonoBehaviour
{
    public int barracasDestruidas = 0;
    [Header("sprites")]
    [SerializeField] private GameObject[] spriteBarracaInteira;
    [SerializeField] private GameObject[] spriteBarracaDestuida;
    
    public void DestruirBarracas()
    {
        spriteBarracaInteira[barracasDestruidas].SetActive(false);
        spriteBarracaDestuida[barracasDestruidas].SetActive(true);
        barracasDestruidas++;
        
    }
}
