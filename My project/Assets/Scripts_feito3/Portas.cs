using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Portas : MonoBehaviour
{
    // Defina a tecla que abrirá a porta
    public KeyCode keyToOpen = KeyCode.E;

    // Verifique se a porta está aberta
    private bool isOpen = false;

    // Update é chamado uma vez por quadro
    public GameObject img;

    void Start()
    {
        img.SetActive(false);
    }
  void Update()
  {
    HandleDoorState();
  }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            img.SetActive(true);
            Debug.Log("Entrou");
            HandleDoorState();
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            img.SetActive(false);
            Debug.Log("Ja foi");
            HandleDoorState();
        }
    }

    // Método para lidar com o estado da porta
    void HandleDoorState()
    {
         if (Input.GetKeyDown(keyToOpen )&& !isOpen)
    {
        
        Debug.Log("Door state: " + isOpen);
        isOpen = !isOpen;
        transform.Rotate(new Vector3(0, 90, 0));
    }
    else if(Input.GetKeyDown(keyToOpen) && !isOpen)
    {
        // Replace this with your specific code for a closed door
        transform.Rotate(new Vector3(0, -90, 0));
    }
    }
}

