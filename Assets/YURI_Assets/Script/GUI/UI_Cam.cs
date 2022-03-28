using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace UnityStandardAssets.CrossPlatformInput
{

    public class UI_Cam : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {

        private GameObject X_Axis;
        private GameObject Y_Axis;
        private GameObject StandardPos;
        private GameObject ExitPanel;
        private Animation anim;
        public AnimationClip[] UI_Anim;
        private Text play_mode;
        private bool rot_flag = true;
        private bool normal_flag = false;
        private Vector2 FirstPos;
        private float deltax;
        private float deltaz;      
        private string horizontalAxisName = "SlideX";
        private string verticalAxisName = "SlideY";
        private bool m_UseX;
        private bool m_UseY; 
        private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;
        private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

        void OnEnable()
        {
            CrossPlatformInputManager.GetAxis(horizontalAxisName);
            CrossPlatformInputManager.GetAxis(verticalAxisName);
        }

        void Start()
        {

            ObjectAsign();

            Initial();
         
        }

        void Update()
        {
            Mecellanous();

            UI_Anim_Controll();
        }

        private void UI_Anim_Controll()
        {
            if (UI_btn.choose_btn == 1)
            {
                if (anim.isPlaying && UI_btn.choose_normal_flag == false)
                {
                    anim.clip = UI_Anim[1];
                    anim.Play();
                }
                else
                {
                    UI_btn.choose_normal_flag = true;
                }
                if (UI_btn.choose_normal_flag == true && UI_btn.return_flag == false)
                {
                    anim.clip = UI_Anim[2];
                    anim.Play();

                }
                if (UI_btn.return_flag == true && anim.isPlaying)
                {
                    anim.clip = UI_Anim[3];
                    anim.Play();
                }
                else
                {
                    if (UI_btn.choose_normal_flag == true && UI_btn.normal_flag == true)
                    {
                        UI_btn.choose_btn = 0;
                        UI_btn.choose_normal_flag = false;
                        UI_btn.return_flag = false;
                        UI_btn.normal_flag = false;
                    }
                }
                return;
            }
            if (UI_btn.choose_btn == 2)
            {
                if (anim.isPlaying && UI_btn.choose_normal_flag == false)
                {
                    anim.clip = UI_Anim[4];
                    anim.Play();
                }
                else
                {
                    UI_btn.choose_normal_flag = true;
                }
                if (UI_btn.choose_normal_flag == true && UI_btn.return_flag == false)
                {
                    anim.clip = UI_Anim[5];
                    anim.Play();

                }
                if (UI_btn.return_flag == true && anim.isPlaying)
                {
                    anim.clip = UI_Anim[6];
                    anim.Play();
                }
                else
                {
                    if (UI_btn.choose_normal_flag == true && UI_btn.normal_flag == true)
                    {
                        UI_btn.choose_btn = 0;
                        UI_btn.choose_normal_flag = false;
                        UI_btn.return_flag = false;
                        UI_btn.normal_flag = false;
                    }
                }
                return;
            }
            if (UI_btn.choose_btn == 3)
            {
                if (anim.isPlaying && UI_btn.choose_normal_flag == false)
                {
                    anim.clip = UI_Anim[7];
                    anim.Play();
                }
                else
                {
                    UI_btn.choose_normal_flag = true;
                }
                if (UI_btn.choose_normal_flag == true && UI_btn.return_flag == false)
                {
                    anim.clip = UI_Anim[8];
                    anim.Play();

                }
                if (UI_btn.return_flag == true && anim.isPlaying)
                {
                    anim.clip = UI_Anim[9];
                    anim.Play();
                }
                else
                {
                    if (UI_btn.choose_normal_flag == true && UI_btn.normal_flag == true)
                    {
                        UI_btn.choose_btn = 0;
                        UI_btn.choose_normal_flag = false;
                        UI_btn.return_flag = false;
                        UI_btn.normal_flag = false;
                    }
                }
                return;
            }
            if (UI_btn.choose_btn == 4)
            {
                if (anim.isPlaying && UI_btn.choose_normal_flag == false)
                {
                    anim.clip = UI_Anim[10];
                    anim.Play();
                }
                else
                {
                    UI_btn.choose_normal_flag = true;
                }
                if (UI_btn.choose_normal_flag == true && UI_btn.return_flag == false)
                {
                    anim.clip = UI_Anim[11];
                    anim.Play();

                }
                if (UI_btn.return_flag == true && anim.isPlaying)
                {
                    anim.clip = UI_Anim[12];
                    anim.Play();
                }
                else
                {
                    if (UI_btn.choose_normal_flag == true && UI_btn.normal_flag == true)
                    {
                        UI_btn.choose_btn = 0;
                        UI_btn.choose_normal_flag = false;
                        UI_btn.return_flag = false;
                        UI_btn.normal_flag = false;
                    }
                }
                return;
            }
            if (!anim.isPlaying || UI_btn.normal_flag == true)
            {
                normal_flag = true;
            }
            if (normal_flag == true)
            {
                anim.clip = UI_Anim[0];
                anim.Play();
            }
        }

        private void Mecellanous()
        {
            if (rot_flag == true)
            {
                Y_Axis.transform.rotation = Quaternion.Slerp(Y_Axis.transform.rotation, StandardPos.transform.rotation, 0.05f);
                X_Axis.transform.rotation = Quaternion.Slerp(X_Axis.transform.rotation, StandardPos.transform.rotation, 0.05f);
            }
            if (UI_btn.exit_panel == true)
            {
                ExitPanel.SetActive(false);
                UI_btn.exit_panel = false;
            }
        }

        private void Initial()
        {
            UI_btn.choose_btn = 0;

            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                play_mode.text = "Tablet";
            }
            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                play_mode.text = "PC";
            }
        }

        private void ObjectAsign()
        {
            X_Axis = GameObject.FindGameObjectWithTag("X-Axis");
            Y_Axis = GameObject.FindGameObjectWithTag("Y-Axis");
            StandardPos = GameObject.FindGameObjectWithTag("Standard_Y-Axis");
            ExitPanel = GameObject.FindGameObjectWithTag("ExitPanel");
            anim = GameObject.FindGameObjectWithTag("GameController").GetComponent<Animation>();
            play_mode = GameObject.FindGameObjectWithTag("PlayMode").GetComponent<Text>();
        }

        public void OnDrag(PointerEventData data)
        {
            rot_flag = false;
            deltax = data.position.x - FirstPos.x;
            deltaz = data.position.y - FirstPos.y;
            Y_Axis.transform.Rotate(-deltaz/100, 0, 0);
            X_Axis.transform.Rotate(0, deltax/100, 0);
        }

        public void OnPointerUp(PointerEventData data)
        {
            rot_flag = true;
        }

        public void OnPointerDown(PointerEventData data)
        {
            FirstPos = data.position;
        }

    }
}
