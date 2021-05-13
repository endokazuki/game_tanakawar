using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class trainscript : MonoBehaviour
{

    float speed = 5.0f;
    float starttimer;

    
   

    void Update()
    {


        
        //rigidbody.velocity += new Vector3(speed * Time.deltaTime, 0, 0);
        if (starttimer > 0)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
            
    

        private void OnCollisionEnter(Collision collision)
    {
        GameObject target1 = GameObject.Find("player");
        


        if (collision.gameObject.tag == "player")
        {
            starttimer += Time.deltaTime;                   
        }

        if (gameObject.CompareTag("train"))
        {
            target1.transform.parent = gameObject.transform;
           
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject target1 = GameObject.Find("player");
        

        if (gameObject.CompareTag("train"))
        {
            target1.transform.parent = null;
           
        }
    }



}

   

