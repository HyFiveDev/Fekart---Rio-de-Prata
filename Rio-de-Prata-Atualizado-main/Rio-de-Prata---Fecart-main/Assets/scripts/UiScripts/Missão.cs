using UnityEngine;
using DG.Tweening;

public class AnimacaoDOTween : MonoBehaviour
{
    [Header("Tamanho")]
    public Vector3 tamanhoInicial = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 tamanhoFinal = Vector3.one;

    [Header("Configuração")]
    public float duracao = 1f;

    void Start()
    {
        // Começa pequeno
        transform.localScale = tamanhoInicial;

        // Cresce até o tamanho final
        transform.DOScale(tamanhoFinal, duracao)
            .SetEase(Ease.OutBack);
    }
}