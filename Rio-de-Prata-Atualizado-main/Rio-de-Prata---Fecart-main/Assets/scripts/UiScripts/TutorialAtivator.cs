using System.Collections;
using UnityEngine;

public class TutorialAtivator : MonoBehaviour
{
    [SerializeField] TutorialManager tutorial;

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Tutorial"))
        {
            print("trigger ativado no objeto:" + this.gameObject);
            tutorial.IniciarTutorial();
            StartCoroutine(Espera());
 
        }
    }

    private IEnumerator Espera()
    {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(10f);
        tutorial.FinalizarTutorial();
        Debug.Log("2 seconds later!");
    }
}
