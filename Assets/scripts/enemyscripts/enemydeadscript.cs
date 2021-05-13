using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydeadscript : MonoBehaviour {

    public AudioClip enemydead;

    AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update () {

        this.transform.position += new Vector3(0, 0, 0);
        audioSource.clip = enemydead;
        audioSource.Play();
        Destroy(this.gameObject, 0.2f);

    }

    


       

        
       
    }
    



