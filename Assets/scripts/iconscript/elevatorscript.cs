using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorscript : MonoBehaviour {

    float movetime;
    float speed = 5.0f;
	
	// Update is called once per frame
	void Update () {
        if (movetime > 0 )
       { this.transform.position += new Vector3(0, speed * Time.deltaTime, 0); }

       if(this.transform.position.y >= 125)
        {
            this.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        movetime = 0f;

        if (collision.gameObject.tag == "player")
        {
            movetime += Time.deltaTime;
           
        }
    }

}
