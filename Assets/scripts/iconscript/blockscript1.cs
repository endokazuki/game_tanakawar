using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockscript1 : MonoBehaviour {


    
    

    
    private Vector3 distance1;

    

    float timer;

    

    

    // Update is called once per frame
    void Update () {


        GameObject target1 = GameObject.Find("player");
       

        Vector3 potision1 = this.transform.position;
        Vector3 potision2 = target1.gameObject.transform.position;
        float distance1 = Vector3.Distance(potision1, potision2);

        timer += Time.deltaTime;

        if (distance1 < 50.0f  )
        {
            Destroy(this.gameObject);
        };

        

        
    }

   
}


