using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript3 : MonoBehaviour {

    public GameObject player;
    public GameObject enemydead;
    public AudioClip enemyhit;
   

    float currentHP = 2;

    private Vector3 offset;
    private Vector3 distance1;

    public float speed = 7;

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

        mutekitimer += Time.deltaTime;

        if (mutekitimer >= 2.0f)
        { spriterenderer.color = Color.white; }

        if (distance1 < 22.0f )
        {
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

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

        if (collider.gameObject.tag == "attack2" )
        {
            currentHP -= 4;
            
           
        }

        if (collider.gameObject.tag == "attack3" )
        {
            currentHP -= 6;
            
            
        }
    }

}
