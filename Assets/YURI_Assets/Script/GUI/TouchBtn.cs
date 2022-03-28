using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string touch_btn_tag = "";
    public Image volume_sign;
    private bool flag = false;
    public AudioSource aud;
    public Text volume_txt;

    void Start()
    {
        touch_btn_tag = transform.tag;
    }

    void Update()
    {
        if(flag == true)
        {
            switch(touch_btn_tag)
            { 
                case "volume_up":
                    {
                        if (volume_sign.fillAmount < 1 || volume_sign.fillAmount == 1)
                        {
                            volume_sign.fillAmount = volume_sign.fillAmount + 0.01f;
                            aud.volume = aud.volume + 0.01f;
                            volume_txt.text = ((int)(aud.volume * 100)).ToString();
                        }
                        break;
                    }
                case "volume_down":
                    {
                        if (volume_sign.fillAmount > 0 || volume_sign.fillAmount == 0)
                        {
                            volume_sign.fillAmount = volume_sign.fillAmount - 0.01f;
                            aud.volume = aud.volume - 0.01f;
                            volume_txt.text = ((int)(aud.volume * 100)).ToString();
                        }
                        break;
                    }
            }
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        flag = false;
    }

    public void OnPointerDown(PointerEventData data)
    {
        flag = true;
    }


}
