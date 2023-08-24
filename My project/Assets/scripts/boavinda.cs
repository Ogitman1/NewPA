using UnityEngine;
using UnityEngine.UI;

public class Boavinda : MonoBehaviour
{
    public GameObject Panel;
    public Text dialogText;
    public Button nextButton;

    private string[] dialogMessages = {
        "Bem-vindo ao meu jogo!",
        "Explore o mundo e divirta-se!",
        "Pressione o botão 'Próximo' para começar!"
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
