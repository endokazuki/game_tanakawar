﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightattackscript : MonoBehaviour {

    float speed = 8.5f;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 5.0f);
        

    }
	
	// Update is called once per frame
	void Update () {

        

        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
       
         
        //this.transform.position += this.transform.forward * speed * Time.deltaTime;
    
	}

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("命中");

        if (collider.gameObject.tag == "hit")
        {
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }

        if (collider.gameObject.tag == "enemy")
        {          
            Destroy(this.gameObject);
        }
    }
    


}
