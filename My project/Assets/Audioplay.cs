using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Audioplay : MonoBehaviour
{

    private bool triggered; // variavel boolean 
    [SerializeField]
    private string proximafase; // variavel string pra trocar de fase
    public AudioSource audiosource; //vaiavel AudioSource pro audio

    public GameObject Img;
    void Start()
    {
        Img.SetActive(false);
    }

    void Jogar()
    {
        SceneManager.LoadScene(proximafase);
    }
    void PlayAudio() 
    {
        if (audiosource != null)
        {
            Debug.Log("Tocar musica");
            audiosource.Play();
        }
        else
        {  
            audiosource =  gameObject.AddComponent<AudioSource>(); //cria um componente AudioSource
            AudioClip portaClip = Resources.Load<AudioClip>("Porta"); //Pega o audio MP3 chamado "Porta" e o importa
            
            audiosource.clip = portaClip; //Associa o audio "Porta"
            audiosource.Play(); //Toca o audio
        }
    }
     IEnumerator DelayedJogar()
     {
        PlayAudio();
        yield return new WaitForSeconds(3.0f);
        Jogar();
     }
    

     void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player"))
        {
            triggered = true;
        }
     } 
     void OnTriggerExit2D(Collider2D collision){
        triggered = false;

        if(triggered == false)
        {
            Debug.Log("Imagem sumiu");
            Img.SetActive(false);
        }
    }
    void Update()
    {
        if(triggered)
        {
            Passae();
        }
    }
    void Passae()
    {
        Img.SetActive(true);
        Debug.Log("Imagem apareceu");

        if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("Tecla E pressionada");
            StartCoroutine(DelayedJogar());
            
            }
    }
}
