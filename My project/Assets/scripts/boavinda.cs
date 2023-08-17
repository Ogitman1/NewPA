using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoasVindas : MonoBehaviour
{
    public Text mensagemTexto;              // Referência ao componente de texto que exibirá a mensagem
    public float delayEntreLetras = 0.1f;   // Atraso entre a exibição de cada letra
    private string mensagemCompleta;        // A mensagem completa a ser exibida
    private string mensagemAtual = "";      // Parte da mensagem que foi exibida até agora
    private bool exibindoMensagem = false;

    private void Start()
    {
        mensagemCompleta = mensagemTexto.text; // Armazena a mensagem original
        mensagemTexto.text = ""; // Limpa o texto inicialmente
        StartCoroutine(ExibirMensagemLetraPorLetra()); // Inicia a exibição letra por letra
    }

    IEnumerator ExibirMensagemLetraPorLetra()
    {
        exibindoMensagem = true;
        // Loop para exibir cada letra da mensagem
        for (int i = 0; i <= mensagemCompleta.Length; i++)
        {
            mensagemAtual = mensagemCompleta.Substring(0, i); // Atualiza a parte da mensagem exibida
            mensagemTexto.text = mensagemAtual; // Atualiza o texto exibido
            yield return new WaitForSeconds(delayEntreLetras); // Aguarda o atraso
        }
        exibindoMensagem = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (exibindoMensagem && Input.GetKey(KeyCode.Q))
        {
            StopCoroutine(ExibirMensagemLetraPorLetra()); // Interrompe a exibição letra por letra
            mensagemTexto.text = mensagemCompleta; // Exibe a mensagem completa
            exibindoMensagem = false; // Define que a mensagem não está mais sendo exibida
        }
    }
}
