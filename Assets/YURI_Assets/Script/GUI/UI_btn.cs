using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_btn : MonoBehaviour 
{
    private string BtnTag = "";
    public GameObject ExitPanel;
    public GameObject BtnGroup;
    private GameObject MainPanel;
    private AudioSource aud;
    public AudioClip btn_click;
    public static bool exit_panel = false;
    public static int choose_btn = 0;
    public static bool choose_normal_flag = false;
    public static bool return_flag = false;
    public static bool normal_flag = false;
    public static string now_scene;

    void Start()
    {
        MainPanel = GameObject.FindGameObjectWithTag("MainPanel");
        exit_panel = true;
        aud = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public void OnUIBtn()
    {
        BtnTag = transform.tag;
        switch (BtnTag)
        {
            case "MissionBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    choose_btn = 1;
                    break;
                }
            case "CampaignBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    choose_btn = 2;
                    break;
                }
            case "LanBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    choose_btn = 3;
                    break;
                }
            case "LibBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    SMGameEnvironment.Instance.SceneManager.LoadScreen("4_Library");
                    break;
                }
            case "OptionBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    choose_btn = 4;
                    break;
                }
            case "ExitBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    ExitPanel.SetActive(true);
                    MainPanel.SetActive(false);
                    BtnGroup.SetActive(false);
                    break;
                }
            case "RetutnBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    return_flag = true;
                    normal_flag = true;
                    break;
                }
            case "ConfirmBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    Application.Quit();
                    break;
                }
            case "CancelBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    MainPanel.SetActive(true); 
                    ExitPanel.SetActive(false);
                    BtnGroup.SetActive(true);
                    break;
                }
            case "NewBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    SMGameEnvironment.Instance.SceneManager.LoadScreen("3_Story");
                    break;
                }
            case "KoryoBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    now_scene = "a7";
                    SMGameEnvironment.Instance.SceneManager.LoadScreen("10_Loading");
                    break;
                }
            case "BaeJeBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    now_scene = "a8";
                    SMGameEnvironment.Instance.SceneManager.LoadScreen("10_Loading");
                    break;
                }
            case "SinLaBtnTag":
                {
                    aud.clip = btn_click;
                    aud.Play();
                    now_scene = "a9";
                    SMGameEnvironment.Instance.SceneManager.LoadScreen("10_Loading");
                    break;
                }
        }
    }
}
