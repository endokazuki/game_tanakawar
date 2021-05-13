using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class selectscript : MonoBehaviour {

    public GameObject Selectbutton1;
    public GameObject Selectbutton2;
    public GameObject Selectbutton3;
    public GameObject Selectbutton4;
    public GameObject Selectbutton5;
    public GameObject Endingbutton;

    void Start()
    {
        if (PlayerPrefs.HasKey("stage1Clear") == true)
        { Selectbutton2.SetActive(true); }
        else
        { Selectbutton2.SetActive(false); }

        if (PlayerPrefs.HasKey("stage2Clear") == true)
        { Selectbutton3.SetActive(true); }
        else
        { Selectbutton3.SetActive(false); }

        if (PlayerPrefs.HasKey("stage3Clear") == true)
        { Selectbutton4.SetActive(true); }
        else
        { Selectbutton4.SetActive(false); }

        if (PlayerPrefs.HasKey("stage4Clear") == true)
        { Selectbutton5.SetActive(true); }
        else
        {
            Selectbutton5.SetActive(false);
        }
        if (PlayerPrefs.HasKey("stage5Clear") == true)
        { Endingbutton.SetActive(true); }
        else
        {
            Endingbutton.SetActive(false);
        }


    }
   

    public void selectbutton1()
    {
        SceneManager.LoadScene("explanationscene1");
    }
    public void selectbutton2()
    {
        SceneManager.LoadScene("explanationscene2");
    }
    public void selectbutton3()
    {
        SceneManager.LoadScene("explanationscene3");
    }
    public void selectbutton4()
    {
        SceneManager.LoadScene("explanationscene4");
    }
    public void selectbutton5()
    {
        SceneManager.LoadScene("explanationscene5");
    }
    public void endingbutton()
    {
        SceneManager.LoadScene("endingscene");
    }
}
