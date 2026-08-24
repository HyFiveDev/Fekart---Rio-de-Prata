using UnityEngine;

public class FormaColisao : MonoBehaviour
{
    [Header("Layers das formas")]
    public string layerHumano = "PlayerHumano";
    public string layerArara = "PlayerArara";
    public string layerMacaco = "PlayerMacaco";

    // Coloca o jogador na forma Humano
    public void FormaHumano()
    {
        gameObject.layer = LayerMask.NameToLayer(layerHumano);
    }

    // Coloca o jogador na forma Arara
    public void FormaArara()
    {
        gameObject.layer = LayerMask.NameToLayer(layerArara);
    }

    // Coloca o jogador na forma Macaco
    public void FormaMacaco()
    {
        gameObject.layer = LayerMask.NameToLayer(layerMacaco);
    }
}