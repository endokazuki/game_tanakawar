using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cleaerscenemaneger2 : MonoBehaviour {

    public void nextybutton2()
    {
        SceneManager.LoadScene("selectscene");
        Debug.Log("GameClear！");
        PlayerPrefs.SetInt("stage2Clear", 2);
    }

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
