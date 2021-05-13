using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysponer1 : MonoBehaviour {

    public GameObject enemy;
    public GameObject enemydead;

    float timer;
    


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;

        if (timer > 5.0f)
        { Instantiate(enemy, this.transform.position, Quaternion.Euler(0, 0, 0));
            timer = 0;

        }



    }

    private void OnTriggerEnter(Collider collider)
    {


        if (collider.gameObject.tag == "attack1" || collider.gameObject.tag == "attack2" || collider.gameObject.tag == "attack3" )
        {
            Instantiate(enemydead, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);

        }

        
    }

}
