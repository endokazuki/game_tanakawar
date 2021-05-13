using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyattackscript6 : MonoBehaviour {

    public AudioClip explosion;

    AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.clip = explosion;
        audioSource.Play();
        Destroy(this.gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update () {

        this.transform.position += new Vector3(0, 0, 0);
        


    }

    


       

        
       
    }
    



