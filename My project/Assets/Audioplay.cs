using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Audioplay : MonoBehaviour
{

    private bool triggered;
    [SerializeField]
    private string proximafase;
    public AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void Jogar()
    {
        SceneManager.LoadScene(proximafase);
    }
    void PlayAudio() 
    {
        if (audiosource != null)
        {
            audiosource.Play();
        }
    }
     IEnumerator DelayedJogar()
     {
        Jogar();
        yield return new WaitForSeconds(3.0f);
        PlayAudio();
     }
     void OnTriggerEnter2D(Collider2D collision)
     {
        triggered = true;
     }
    void Update()
    {
        if (triggered)
        {
            StartCoroutine(DelayedJogar());
        }
    }
}
