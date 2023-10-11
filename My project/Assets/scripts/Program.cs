using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
    static void Main()
    {
        // Criação de personagens
        Character player = new Character("Player");
        Character NPC = new Character("NPC");

        //Adicionar dialógos
        player.AddDialogue("Olá Jerry! Como você tá?");
        NPC.AddDialogue("Oi Dani, suave. E vc?");
        player.AddDialogue("Ótima. Vc se lembra onde era a Lanchonete do Montgory?");     
        NPC.AddDialogue("É na região de Campo Limpo seguindo em frente");
        player.AddDialogue("Obrigada Jerry, salvou muito");
        NPC.AddDialogue("Imagina Dani, qlqr coisa é só chamar");

        player.AssignTask("Continue em frente");

        
    }
    
}
