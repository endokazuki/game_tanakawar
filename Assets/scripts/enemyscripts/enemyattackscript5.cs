using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyattackscript5 : MonoBehaviour
{

    float speed = 20.0f;
    float timer;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
       

        // this.transform.position += this.transform.forward * speed * Time.deltaTime; 
    }

    }

   

