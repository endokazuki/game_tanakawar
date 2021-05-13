using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class donscript : MonoBehaviour {

    float currentHP = 15;

    public GameObject player;
    public GameObject bossattack1;
    public GameObject bossattack2;
    public GameObject enemydead;
    public GameObject key;
    public GameObject first;
    public GameObject second;

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

        if (currentHP <= 10)
        {
            this.transform.position += new Vector3(123, 13, 0);
            spriterenderer.flipX = true;
        }

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
        { spriterenderer.color = Color.blue; }

        if (distance1 < 30.0f && timer >3.0f)
        {
            if (this.transform.position.x > 0)
            {
                Instantiate(bossattack1, this.transform.position, Quaternion.identity);
                timer = 0;
            }
            else
            {
                Instantiate(bossattack2, this.transform.position, Quaternion.identity);
                timer = 0;
            }
        };

        if (currentHP <= 0)
        {
            Instantiate(enemydead, this.transform.position, Quaternion.identity);
            Instantiate(key, this.transform.position, Quaternion.identity);


            Destroy(this.gameObject);
        }

        if (currentHP <= 10)
        {
            this.transform.position = new Vector3(-123, 28, 0);
            spriterenderer.flipX = true;
            Instantiate(first, new Vector3(186, 28, 0), Quaternion.identity);
        }

        //if (currentHP <= 4)
       // {
           // this.transform.position = new Vector3(209, 28, 0);
           // spriterenderer.flipX = false;
           // Instantiate(second, new Vector3(-106, 28, 0), Quaternion.identity);
       // }
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
            mutekitimer = 0;
            audioSource.clip = enemyhit;
            audioSource.Play();
            spriterenderer.color = Color.red;
        }
    }

}
