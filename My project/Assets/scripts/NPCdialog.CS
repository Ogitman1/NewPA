using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCdialog : MonoBehaviour
{
    public string[] dialogueNpc; // lista para guardar os dialogos
    public int dialogueIndex; // index para sabermos em que frase de texto está

    public GameObject dialoguePanel; // variavel para por o painel canvas pelo editor
    public Text dialogueText; // componente texto para aparecer os dialogos
    public Text nameNPC; // nome (string) NPC
    public Image imageNPC; // componente imagem do npc
    public Sprite spriteNPC; // sprite npc

    public bool readytoSpeak; //  variavel bool que verifica se o dialogo pode estar pronto para acontecer
    public bool startDialogue; // variavel bool que começa o dialogo 

    // metodo que vai ser chamado para inicializar os dialogos com seus respectivos valores
    void StartDialogue()
    {
        nameNPC.text = "Marcos";
        imageNPC.sprite = spriteNPC;
        startDialogue = true;
        dialogueIndex = 0;
        dialoguePanel.SetActive(true);
        StartCoroutine(ShowDialogue());
    }

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    // se ele entrar na area do NPC o readytospeak se torna verdadeiro
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readytoSpeak = true;
        }
    }
    // se ele sair da area do NPC o readytospeak se torna falso
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readytoSpeak = false;
        }
    }
void NextDialogue()
    {
        dialogueIndex++; // aumenta o indice do dialogo

        if (dialogueIndex < dialogueNpc.Length) // se o indice do dialogo for menor do que a lista do dialogo, inicia o metodo
        {
            StartCoroutine(ShowDialogue());
        }
        // Se não, fecha o dialogo e volta a velocidade do player normalmente
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
    dialogueText.text = ""; // cada final do dialogo esvazia a string
    
    foreach (char letter in dialogueNpc[dialogueIndex]) //exibe cada letra do dialogo
    {
        dialogueText.text += letter; // texto + cada letra
        yield return new WaitForSeconds(0.05f); // adiciona um delay 
    }
    
    yield return new WaitForSeconds(1.0f); // adiciona o delay
    
    NextDialogue();
}


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && readytoSpeak) // executa caso clique com o botão esquerdo do mouse e readytospeak seja verdadeiro
        {
            if (!startDialogue) 
            {
                Mov playerMov = FindObjectOfType<Mov>(); // instancia nossa classe para pararmos a velocidade do nosso player
                if (playerMov != null) // caso o valor não seja vazio para nosso jogador para o dialogo ocorrer 
                {
                    playerMov.SPEED = 0f; 
                }
                
                StartDialogue(); // chama StartDialogue que configuramos para o dialogo ocorrer
            }
            // Verifica 3 coisas, respectivamente:
            // Se a variavel startDialogue é verdadeiro
            // nega o metodo IsShowingDialogue verificando se o dialogo não está aparecendo
            // verifica o texto atual com seu indice
        else if (startDialogue && !IsShowingDialogue() && dialogueText.text == dialogueNpc[dialogueIndex])
        {
            NextDialogue(); // avança para o próximo dialogo
        }
    }

    bool IsShowingDialogue()
    {
        return dialogueText.text.Length > 0;
    }

    
}
}