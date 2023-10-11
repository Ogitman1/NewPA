using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public string Description { get; set; } // Propriedade da descrição da tarefa
    public bool IsCompleted { get; set; } // Rastrear se a tarefa foi concluida
    
    public Task (string description) // Construtor da tarefa
    {
        this.Description = description; // Inicializa a descrição da tarefa
        IsCompleted = false; // Inicializa com falso
    }

    public void CompleteTask() // Marca a tarefa como concluída
    {
        IsCompleted = true;
    }
}
