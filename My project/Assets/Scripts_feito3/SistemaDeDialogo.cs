using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeDialogo : MonoBehaviour
{
    public Text caixaDeDialogo;
    public string[] falas;
    private int indice = 0;
    public float tempoEsperaEntreFalas = 2.5f;
    public GameObject Panel;
    void Start()
    {
        // Inicie o diálogo
        IniciarDialogo();
    }

    void IniciarDialogo()
    {
        // Inicialize ou ative a caixa de diálogo (pode ser um objeto Text no seu canvas)
        caixaDeDialogo.gameObject.SetActive(true);
        Panel.SetActive(true);

        // Inicie a exibição do diálogo
        StartCoroutine(ExibirProximaFala());
    }

    IEnumerator ExibirProximaFala()
    {
        while (indice < falas.Length)
        {
            // Exiba a fala atual na caixa de diálogo
            caixaDeDialogo.text = falas[indice];

            // Aguarde o tempo de espera
            yield return new WaitForSeconds(tempoEsperaEntreFalas);

            // Avance para a próxima fala
            indice++;

            // Limpe a caixa de diálogo
            caixaDeDialogo.text = "";
        }

        // Se todas as falas foram exibidas, encerre o diálogo
        EncerrarDialogo();
    }

    void EncerrarDialogo()
    {
        // Desative a caixa de diálogo
        caixaDeDialogo.gameObject.SetActive(false);
        Panel.SetActive(false);
    }
}
