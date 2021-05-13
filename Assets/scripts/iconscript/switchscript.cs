using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchscript : MonoBehaviour {

    public GameObject elevator;
    public AudioClip playsound;

    AudioSource audioSource;

   
    void Start () {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "player")
        { Instantiate(elevator, new Vector3(591, 109, 0), Quaternion.identity); }
        audioSource.clip = playsound;
        audioSource.Play();
        Destroy(this.gameObject,2.0f);

    }
}
