using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyscript6 : MonoBehaviour {

    float currentHP = 1;

    public GameObject player;
    public GameObject enemyattack5;
    public GameObject enemydead;
    

    public AudioClip enemyhit;
   

   
    private Vector3 distance1;

    float timer;
    float mutekitimer;

    AudioSource audioSource;
    SpriteRenderer spriterenderer;

    // Use this for initialization
    void Start () {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        spriterenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {

       
       

        timer += Time.deltaTime;
        mutekitimer += Time.deltaTime;

        if (mutekitimer >= 2.0f)
        { spriterenderer.color = Color.white; }

        if ( timer >5.0f)
        {
            Instantiate(enemyattack5, this.transform.position, Quaternion.identity);
            timer = 0;
        };

        if (currentHP <= 0)
        {
            Instantiate(enemydead, this.transform.position, Quaternion.identity);         
           
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "attack1" && mutekitimer >= 2.0f)
        {
            currentHP -= 1;
            mutekitimer = 0;
            audioSource.clip = enemyhit;
            audioSource.Play();
            spriterenderer.color = Color.red;
        }

        if (collider.gameObject.tag == "attack2" && mutekitimer >= 2.0f)
        {
            currentHP -= 4;
            mutekitimer = 0;
            audioSource.clip = enemyhit;
            audioSource.Play();
            spriterenderer.color = Color.red;
        }

        if (collider.gameObject.tag == "attack3" )
        {
            currentHP -= 6;
           
        }
    }

}
