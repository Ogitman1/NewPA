using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class treinamento : MonoBehaviour
{
    int velocidade;

    void Vele(int velocidade)
    {
        this.velocidade = velocidade;
    }

    public class Inimigo
    {
        public int velocidade;
    }

    public class Orc : Inimigo
    {
        public void Vel(int velocidade)
        {
            base.velocidade = velocidade;
        }
    }

    void Start()
    {
        Orc orc = new Orc(); // Criar uma instância de Orc
        orc.Vel(12); // Chamar o método Vel de Orc
        treinamento trn = new treinamento();
        trn.Vele(11);
        Debug.Log(trn.velocidade);
        Debug.Log(orc.velocidade); // Acessar a velocidade do Orc e exibi-la no console
    }
}

