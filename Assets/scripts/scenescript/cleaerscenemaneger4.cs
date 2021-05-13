using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cleaerscenemaneger4: MonoBehaviour {

    public void nextybutton4()
    {
        SceneManager.LoadScene("selectscene");
        Debug.Log("GameClear！");
        PlayerPrefs.SetInt("stage4Clear", 4);
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
