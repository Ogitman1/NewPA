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
   /* void Update()
{
    HandleDoorState();
}*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            img.SetActive(true);
            HandleDoorState();
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            img.SetActive(false);
        }
    }

    // Método para lidar com o estado da porta
    void HandleDoorState()
    {
         if (Input.GetKeyDown(keyToOpen))
    {
        isOpen = !isOpen;
        Debug.Log("Door state: " + isOpen);
    }

    // Apply the corresponding rotation based on the door state
    if (isOpen)
    {
        // Replace this with your specific code for an open door
        transform.Rotate(new Vector3(0, 90, 0));
    }
    else
    {
        // Replace this with your specific code for a closed door
        transform.Rotate(new Vector3(0, -50, 0));
    }
    }
}

