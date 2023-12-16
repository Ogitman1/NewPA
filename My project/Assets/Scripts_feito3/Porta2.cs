using UnityEngine;

public class Porta2 : MonoBehaviour
{
    private KeyCode keyToOpen = KeyCode.E;
    public float distanciaInteracao = 0.2f;

    [SerializeField]
    private GameObject img;

    private bool isOpen = false;

    void Start()
    {
        img.SetActive(false);
    }

    void OnTriggerEnter2D(){
        img.SetActive(true);
        Debug.Log("Its near");
        isOpen = !isOpen;
        HandleDoorState();
    
            
        }
    void OnTriggerExit2D(){
        img.SetActive(false);
        Debug.Log("Its not near");
        //isOpen = !isOpen;
    }
    
   /* void Update()
    {
        if (Input.GetKeyDown(keyToOpen))
        {
            Debug.Log("E");
            if (IsPlayerNear() )
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
    } */
    //Verifica a distância do GameObject com o player
   /* bool IsPlayerNear()
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
            return false; // Return false when the player is not near
        }
    }
    else
    {
        Debug.Log("Player object not found");
        return false; // Return false when player object is not found
    }
}
*/
    void HandleDoorState()
{
    if (Input.GetKeyDown(keyToOpen))
    {
        Debug.Log("O botão E foi apertado");
        if (isOpen)
        {
            Debug.Log("A porta está fechada");
            transform.Rotate(new Vector3(0, 90, 0));
            // Adicione código específico para a porta fechada
        }
        else
        {
            Debug.Log("A porta está aberta");
            transform.Rotate(new Vector3(0, -90, 0));
            // Adicione código específico para a porta aberta
        }

        isOpen = !isOpen; // Toggle the door state
    }
}
void Update(){
    HandleDoorState();
}
}

