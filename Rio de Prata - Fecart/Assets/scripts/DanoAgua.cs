using UnityEngine;

using UnityEngine;
using UnityEngine.SceneManagement;

public class DanoAgua : MonoBehaviour
{
    [Tooltip("Nome exato da cena de Game Over")]
    [SerializeField] GameObject telaMorte;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            telaMorte.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
