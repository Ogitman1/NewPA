using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    
        public string Name { get; set; } // propriedade nome do personagem
        public List<string> Dialogues { get; set; } // Listas dialogos do personagem
        public List<Task> Tasks { get; set; } // Listas tasks do personagem

    

    public Character(string name) // Construtor da classe
    {
        this.Name = name;
        Dialogues = new List<string>();
        Tasks = new List<Task>();
    }

    public void AddDialogue (string dialogue) //Método para adicionar um dialógo a lista de dialogos
    {
        Dialogues.Add(dialogue);
    }

    public void AssignTask (string taskDescription) //Método para marcar uma tarefa como concluída
    {
        Task task = Tasks.Find( t => t.Description == taskDescription); // Vê se a propriedade Description é igual do parâmetro
        if (task != null)
        {
            task.CompleteTask();
        }
    }
}
