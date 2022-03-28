using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lib_Btn : MonoBehaviour 
{
    private string lib_btn_tag = "";
    public AudioSource aud;
    public AudioClip btn_click;
	// Use this for initialization
	void Start () 
    {
        lib_btn_tag = transform.tag;
	}

    public void OnLibBtn()
    {
        switch (lib_btn_tag)
        {
            case "Menu_Btn":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    Lib_UI.anim_i = 1;
                    Lib_UI.anim_flag = true;
                    break;
                }
            case "AllStar_Btn":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    Lib_UI.anim_i = 2;
                    Lib_UI.anim_flag = true;
                    break;
                }
            case "Castle_Btn":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    Lib_UI.anim_i = 3;
                    Lib_UI.anim_flag = true;
                    break;
                }
            case "Trace_Btn":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    Lib_UI.anim_i = 4;
                    Lib_UI.anim_flag = true;
                    break;
                }
            case "Credit_Btn":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    SMGameEnvironment.Instance.SceneManager.LoadScreen("a6");
                    break;
                }
        }
    }
}
