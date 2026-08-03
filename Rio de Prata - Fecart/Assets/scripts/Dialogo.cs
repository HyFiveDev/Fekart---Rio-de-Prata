using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Dialogo : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    public GameObject interactText;

    [TextArea(3, 5)]
    public string[] lines;

    private int index;
    private bool playerInRange;
    private bool dialogueStarted;

    void Start()
    {
        dialoguePanel.SetActive(false);
        interactText.SetActive(false);
    }

    void Update()
    {
        // Iniciar diálogo
        if (playerInRange && !dialogueStarted && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }

        // Próxima fala
        if (dialogueStarted && Input.GetKeyDown(KeyCode.Return))
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        dialogueStarted = true;

        dialoguePanel.SetActive(true);
        interactText.SetActive(false);

        index = 0;
        dialogueText.text = lines[index];
    }

    void NextLine()
    {
        index++;

        if (index < lines.Length)
        {
            dialogueText.text = lines[index];
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueStarted = false;

        dialoguePanel.SetActive(false);

        if (playerInRange)
        {
            interactText.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (!dialogueStarted)
            {
                interactText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            interactText.SetActive(false);

            EndDialogue();
        }
    }
}
