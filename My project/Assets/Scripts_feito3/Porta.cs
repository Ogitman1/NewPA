using UnityEngine;

public class Porta : MonoBehaviour
{
    private bool isOpen = false;
    private float interacaoDistancia = 33f; // Defina a distância mínima para interação

    public void ToggleDoor(Transform transform)
    {
        isOpen = !isOpen;
        Debug.Log("Door state: " + isOpen);

        if (isOpen)
        {
            // Substitua isso com o código específico para uma porta aberta
            transform.Rotate(new Vector3(0, 90, 0));
        }
        else
        {
            // Substitua isso com o código específico para uma porta fechada
            transform.Rotate(new Vector3(0, -90, 0));
        }
    }

    public bool IsPlayerNear(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(playerPosition, Camera.main.transform.position);
        return distance <= interacaoDistancia;
    }
}
