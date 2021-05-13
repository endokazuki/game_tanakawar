using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyscript1 : MonoBehaviour {

    float currentHP = 4;

    public GameObject player;
    public GameObject enemyattack1;
    public GameObject enemydead;
    

    public AudioClip enemyhit;
   

    private Vector3 offset;
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

        offset = transform.position - player.transform.position;
        GameObject target1 = GameObject.Find("player");
       

        Vector3 potision1 = this.transform.position;
        Vector3 potision2 = target1.gameObject.transform.position;
        float distance1 = Vector3.Distance(potision1, potision2);

        timer += Time.deltaTime;
        mutekitimer += Time.deltaTime;

        if (mutekitimer >= 2.0f)
        { spriterenderer.color = Color.white; }

        if (distance1 < 30.0f && timer >3.0f)
        {
            Instantiate(enemyattack1, this.transform.position, Quaternion.identity);
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
