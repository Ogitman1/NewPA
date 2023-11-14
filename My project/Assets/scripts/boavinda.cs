using UnityEngine;
using UnityEngine.UI;

public class Boavinda : MonoBehaviour
{
    public GameObject Panel; // Panel Object
    public Text dialogText; // Text Object
    public Button nextButton; // Button Objecr

    private string[] dialogMessages = {
        "Bem-vindo jogador",
        "Agora essa que é a parte onde eu te ensino sobre os controles do jogo",
        "Mas antes disso te peço um pequeno favor",
        "'A Esperança' é um jogo indie de quests desenvolvido por um pequeno grupo para representar o Brasil no mercado de jogos",
        "Se você gostar do jogo não exite em contribuir com uma pequena quantia para continuar representando o Brasil no jogos",
        "Meu instagram é @santos_matheus18 caso se interesse em saber mais",
        "Voltando no tutorial.",
        "A, W, S, D são os controles de movimento.",
        "Caso queira interagir com um NPC chegue próximo e clique nele.",
        "Caso queira entrar em alguma porta ou pegar algum objeto se aproxime e aperte a tecla 'E'.",
        "Bom, agora vamos praticar."
    };

    private int Index = 0;

    void Start()
    {
        // Inicializar o diálogo
        Panel.SetActive(true);
        dialogText.text = dialogMessages[Index];
        nextButton.onClick.AddListener(ShowNextMessage);
    }

    void ShowNextMessage()
    {
        Index++; // Avançar para a próxima mensagem
        // Verificar se todas as mensagens foram exibidas

        if (Index < dialogMessages.Length)
        {
            dialogText.text = dialogMessages[Index];
        }
        else
        {
            // Todas as mensagens foram exibidas, desativar a UI de diálogo
            Panel.SetActive(false);
            nextButton.interactable = false;
            dialogText.enabled = false;
        }
    }
}
