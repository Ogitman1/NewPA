using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colliderporta : MonoBehaviour
{
    private bool triggered = false;
    [SerializeField]
    private string proximafase;
    public AudioSource audiosource;

    private void Start()
    {
          audiosource = GameObject.FindGameObjectWithTag("Sounds").GetComponent<AudioSource>();
          
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
        Debug.LogWarning("Sounds object not found.");
    }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
        Debug.Log(triggered);
        
    }
    private void Update()
    {
        if (triggered)
        {
        StartCoroutine(DelayedJogar());
        }
    }
    private IEnumerator DelayedJogar()
    {
        ReproduzirSom();
        yield return new WaitForSeconds(6.0f); // Change the delay time as needed
        Jogar();
    }
}
