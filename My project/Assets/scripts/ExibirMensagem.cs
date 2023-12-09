using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExibirMensagem : MonoBehaviour
{
    public Text mensagemText;
    public GameObject canva;
    public GameObject img;

    bool dentroDaZonaTrigger = false;

    void Start()
    {
        img.SetActive(false);
        canva.SetActive(false);
    }

    void Update()
    {
        if (dentroDaZonaTrigger)
        {
            Comecar();
        }
    }

    void Comecar()
    {
        Debug.Log("Começou");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Disparou");
            ExibirEsumirMensagem("Pegou: Relatório1");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            img.SetActive(true);
            dentroDaZonaTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            img.SetActive(false);
            canva.SetActive(false);
            dentroDaZonaTrigger = false;
        }
    }

    void ExibirEsumirMensagem(string mensagem)
    {
        Debug.Log("Sucesso!!!");
        canva.SetActive(true);
        // Exiba a mensagem
        mensagemText.text = mensagem;

        // Aguarde 2 segundos antes de esconder a mensagem
        StartCoroutine(EsconderMensagemAposTempo(2f));
    }

    IEnumerator EsconderMensagemAposTempo(float tempo)
    {
        Debug.Log("Sucesso2!!!");
        // Aguarde o tempo especificado
        yield return new WaitForSeconds(tempo);
    
        // Desative o canva e esconda a mensagem
        canva.SetActive(false);
        mensagemText.text = "";
        // Esconda a mensagem
    }
}
