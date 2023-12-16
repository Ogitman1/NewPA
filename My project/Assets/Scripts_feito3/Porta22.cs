using UnityEngine;

public class Porta22 : MonoBehaviour
{
    public KeyCode keyToOpen = KeyCode.E;
    public float distanciaInteracao = 22f;

    [SerializeField]
    private GameObject img;

    private bool isOpen = false;

    void Start()
    {
        img.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToOpen))
        {
            Debug.Log("E");
            if (IsPlayerNear() && img != null)
            {
                Debug.Log("Its near");
                isOpen = !isOpen;
                img.SetActive(isOpen);
                HandleDoorState();
            }
            else
            {
                Debug.Log("Its not near");
            }
        }
    }

    bool IsPlayerNear()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float distancia = Vector3.Distance(player.transform.position, transform.position);
            if (distancia <= distanciaInteracao)
            {
                Debug.Log("Player is near");
                return true;
            }
            else
            {
                Debug.Log("Player is not near");
                return false;
            }
        }
        else
        {
            Debug.Log("Player object not found");
        }

        return false;
    }

    void HandleDoorState()
    {
        if (isOpen)
        {
            if (transform.rotation.eulerAngles.y != -90)
            {
                Debug.Log("A porta está aberta");
                transform.Rotate(new Vector3(0, -90, 0));
                // Adicione código específico para a porta aberta
            }
        }
        else
        {
            if (transform.rotation.eulerAngles.y != 0)
            {
                Debug.Log("A porta está fechada");
                transform.Rotate(new Vector3(0, 90, 0));
                // Adicione código específico para a porta fechada
            }
        }
    }
}

