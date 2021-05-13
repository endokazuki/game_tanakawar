using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cleaerscenemaneger3: MonoBehaviour {

    public void nextybutton3()
    {
        SceneManager.LoadScene("selectscene");
        Debug.Log("GameClear！");
        PlayerPrefs.SetInt("stage3Clear", 3);
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
