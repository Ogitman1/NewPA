using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Colliderporta : MonoBehaviour
{
    private bool triggered = false;
    [SerializeField] private string proximafase;
    public AudioSource audiosource;
    public GameObject img;

    private void Start()
    {
        img.SetActive(false);
    }

    public void Jogar()
    {
        SceneManager.LoadScene(proximafase);
    }

    public void ReproduzirSom()
    {
        if (audiosource != null)
        {
            audiosource.Play();
            Debug.Log("oi");
        }
        else
        {
           
            audiosource =  gameObject.AddComponent<AudioSource>(); //cria um componente AudioSource
            AudioClip portaClip = Resources.Load<AudioClip>("Porta"); //Pega o audio MP3 chamado "Porta" e o importa
            
            audiosource.clip = portaClip; //Associa o audio "Porta"
            audiosource.Play(); //Toca o audio
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggered = true;
            img.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggered = false;
            img.SetActive(false);
        }
    }

    private void Update()
    {
        if (triggered && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(triggered);
            StartCoroutine(DelayedJogar());
        }
    }

    private IEnumerator DelayedJogar()
    {
        ReproduzirSom();
        yield return new WaitForSeconds(3.0f); // Change the delay time as needed
        Jogar();
    }
}
