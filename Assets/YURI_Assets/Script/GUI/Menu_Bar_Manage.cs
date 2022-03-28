using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Bar_Manage : MonoBehaviour 
{
    private string btn_name = "";
    private GameObject cam_status;
    private GameObject show_pos;
    private GameObject hide_pos;
	// Use this for initialization
	void Start () 
    {
        btn_name = transform.name;
        if (btn_name == "Menu_Bar")
        {
            show_pos = GameObject.Find("show_pos");
            hide_pos = GameObject.Find("hide_pos");
        }
        if (btn_name == "Cam_Mode_Change")
        {
            cam_status = GameObject.Find("Cam_Status");
        }
	}

    void Update()
    {
        if (btn_name == "Menu_Bar")
        {
            if (PlayManager.menu_show == true)
            {
                if (transform.GetComponent<CanvasGroup>().alpha < 1)
                    transform.GetComponent<CanvasGroup>().alpha = transform.GetComponent<CanvasGroup>().alpha + 0.3f;
                transform.position = Vector3.Slerp(transform.position, show_pos.transform.position, 0.1f);
            }
            else
            {
                if (transform.GetComponent<CanvasGroup>().alpha > 0)
                    transform.GetComponent<CanvasGroup>().alpha = transform.GetComponent<CanvasGroup>().alpha - 0.3f;
                transform.position = Vector3.Slerp(transform.position, hide_pos.transform.position, 0.1f);
            }
        }
    }

    public void On_Menu_Btn()
    {
        switch (btn_name)
        {
            case "A_Choose":
                {
                    PlayManager.now_cat = btn_name;
                    PlayManager.move_to_now_cat = true;
                    break;
                }
            case "B_Choose":
                {
                    PlayManager.now_cat = btn_name;
                    PlayManager.move_to_now_cat = true;
                    break;
                }
            case "AB_Choose":
                {
                    PlayManager.now_cat = btn_name;
                    PlayManager.move_to_now_cat = true;
                    break;
                }
            case "O_Choose":
                {
                    PlayManager.now_cat = btn_name;
                    PlayManager.move_to_now_cat = true;
                    break;
                }
            case "Cam_Mode_Change":
                {
                    if (PlayManager.Top_Camera_Mode == true)
                    {
                        PlayManager.Top_Camera_Mode = false;
                        cam_status.GetComponent<Text>().text = "Rot";
                    }
                    else
                    {
                        PlayManager.Top_Camera_Mode = true;
                        cam_status.GetComponent<Text>().text = "Top";
                    }
                    break;
                }
            case "Home":
                {
                    SMGameEnvironment.Instance.SceneManager.LoadScreen("2_Main_UI");
                    break;
                }
            case "Pause":
                {
                    if (Time.timeScale == 0)
                    {
                        Time.timeScale = 1;
                    }
                    else
                    {
                        Time.timeScale = 0;
                    }
                    break;
                }
            case "Menu_Btn":
                {
                    if (PlayManager.menu_show == false)
                    {
                        PlayManager.menu_show = true;
                    }
                    else
                    {
                        PlayManager.menu_show = false;
                    }
                    break;
                }
        }
    }
}
