using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cleaerscenemaneger5: MonoBehaviour {

    public void nextybutton5()
    {
        SceneManager.LoadScene("endingscene");
        Debug.Log("GameClear！");
        PlayerPrefs.SetInt("stage5Clear", 5);
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
