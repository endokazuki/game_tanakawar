﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogleftattackscript : MonoBehaviour {

    float speed = 12.0f;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 10.0f);
        

    }
	
	// Update is called once per frame
	void Update () {

        

        this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
       
         
        //this.transform.position += this.transform.forward * speed * Time.deltaTime;
    
	}

    private void OnTriggerEnter(Collider collider)
    {
        

        if (collider.gameObject.tag == "hit")
        {
           
           
        }

        if (collider.gameObject.tag == "enemy")
        {          
           
        }
    }
    


}
