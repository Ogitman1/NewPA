using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MMenumanger : MonoBehaviour
{
    [SerializeField]
    private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpçoes;
    
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }
    public void AbrirOpções()
    {
        painelMenuInicial.SetActive(false);
        painelOpçoes.SetActive(true);
    }
    public void FecharOpções()
    {
        painelOpçoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void SairJogo()
    {
        Debug.Log("SairJogo");
        Application.Quit();
    }
}
