using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class endscenemaneger : MonoBehaviour {

    public void retrybutton()
    {
        SceneManager.LoadScene("selectscene");
    }

}

