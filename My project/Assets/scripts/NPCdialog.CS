using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCdialog : MonoBehaviour
{
    public string[] dialogueNpc;
    public int dialogueIndex;

    public GameObject dialoguePanel;
    public Text dialogueText;
    public Text nameNPC;
    public Image imageNPC;
    public Sprite spriteNPC;

    public bool readytoSpeak;
    public bool startDialogue;

    public delegate void MeuDelegate();
    public event MeuDelegate OnEventImportant;

    // Step 1: Method that initializes the dialogues with their respective values
    void StartDialogue()
    {
        nameNPC.text = "Marcos";
        imageNPC.sprite = spriteNPC;
        startDialogue = true;
        dialogueIndex = 0;
        dialoguePanel.SetActive(true);
        StartCoroutine(ShowDialogue());
        AcionarEventoImportante();
    }

    void AcionarEventoImportante()
    {
        OnEventImportant?.Invoke();
    }

    void Start()
    {
        dialoguePanel.SetActive(false);
       // OnEventImportant += SetOpen;
    }

    // Step 2
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readytoSpeak = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readytoSpeak = false;
        }
    }

    // Step 4
    void NextDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex < dialogueNpc.Length)
        {
            StartCoroutine(ShowDialogue());
        }
        else
        {
            dialoguePanel.SetActive(false);
            dialogueIndex = 0;
            startDialogue = false;

            Mov playerMov = FindObjectOfType<Mov>();
            if (playerMov != null)
            {
                playerMov.SPEED = 5f;
            }
        }
    }

    IEnumerator ShowDialogue()
    {
        dialogueText.text = "";

        foreach (char letter in dialogueNpc[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1.0f);

        NextDialogue();
    }

    // Step 3
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && readytoSpeak)
        {
            if (!startDialogue)
            {
                Mov playerMov = FindObjectOfType<Mov>();
                if (playerMov != null)
                {
                    playerMov.SPEED = 0f;
                }

                StartDialogue();
            }
            else if (startDialogue && !IsShowingDialogue() && dialogueText.text == dialogueNpc[dialogueIndex])
            {
                NextDialogue();
            }
        }
    }

    bool IsShowingDialogue()
    {
        return dialogueText.text.Length > 0;
    }

    // Handle the event

}
