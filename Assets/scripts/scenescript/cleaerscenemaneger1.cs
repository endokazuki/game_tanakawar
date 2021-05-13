using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cleaerscenemaneger1 : MonoBehaviour {

    public void nextybutton()
    {
        SceneManager.LoadScene("selectscene");
        Debug.Log("GameClear！");
        PlayerPrefs.SetInt("stage1Clear", 1);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
