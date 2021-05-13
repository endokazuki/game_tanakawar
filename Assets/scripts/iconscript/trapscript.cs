using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapscript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            Destroy(this.gameObject, 10.0f);
        }
    }
}
