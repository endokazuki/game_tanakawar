using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialattackscript : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        
        

    }
	
	// Update is called once per frame
	void Update () {

        

        this.transform.position += new Vector3(0, 0, 0);
        Destroy(this.gameObject, 1.0f);


        //this.transform.position += this.transform.forward * speed * Time.deltaTime;

    }

    


        private void OnTriggerEnter(Collider collider)
    {
        

        if (collider.gameObject.tag == "hit")
        {
            Destroy(collider.gameObject);
           
        }

        
       
    }
    


}
