using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyscript7bomb3 : MonoBehaviour
{



    public GameObject player;
    public GameObject enemyattack6;

    float currentHP = 1;


    private Vector3 distance1;

    public float speed = 5;

    bool moveRight = false;
    bool moveLeft = false;

    SpriteRenderer spriterenderer;

    void Move(int a, int b)
    {
        if (moveRight == true)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            spriterenderer.flipX = true;

            if (this.transform.position.x > a)
            {
                moveRight = false;
                moveLeft = true;

            }
        }

        if (moveLeft == true)
        {
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            spriterenderer.flipX = false;

            if (this.transform.position.x < b)
            {
                moveRight = true;
                moveLeft = false;

            }
        }
    }




    // Use this for initialization
    void Start()
    {
        moveRight = true;
        spriterenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {





        Move(138, 32);



        if (currentHP == 0)
        {
            Instantiate(enemyattack6, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            currentHP -= 1;

        }

        if (collision.gameObject.tag == "dead")
        {
            Destroy(this.gameObject);
        }
    }

  

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "attack1")
        {
            currentHP -= 1;
            Destroy(collider.gameObject);

        }

        if (collider.gameObject.tag == "attack2")
        {
            currentHP -= 1;
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "attack3")
        {
            currentHP -= 1;
            Destroy(collider.gameObject);
        }
    }

    


}


