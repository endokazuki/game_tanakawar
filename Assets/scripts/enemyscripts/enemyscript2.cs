using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript2 : MonoBehaviour {

    float currentHP = 1;

    public GameObject player;
    public GameObject enemyattack2;
    public GameObject enemydead;


    private Vector3 offset;
    private Vector3 distance1;

    public float speed = 5;

    float timer;
    float mutekitimer;

    AudioSource audioSource;


    // Use this for initialization
    void Start () {
        audioSource = this.gameObject.GetComponent<AudioSource>();

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

        if (distance1 < 22.0f && timer >2.0f)
        {
            Instantiate(enemyattack2, this.transform.position, Quaternion.identity);
            timer = 0;
        };

        this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

        Destroy(this.gameObject, 5.0f);

        if(currentHP <= 0)
        {
            Instantiate(enemydead, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
            
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "attack1" )
        {
            currentHP -= 1;
            
           
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


