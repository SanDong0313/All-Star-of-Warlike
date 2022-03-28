using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{

    public class JoyStickTotalCamera : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        public static bool cam_attach_flag = false;
        public GameObject[] Cat_List;
        public GameObject Now_Cat;
        public GameObject Cam_Target;
        public GameObject X_Axis;
        public GameObject Y_Axis;
        public GameObject Standard_X_Axis;
        public GameObject Standard_Y_Axis;
        public int movescale = 100;
        private Vector2 FirstPos;
        private float deltax;
        private float deltaz;
        private string horizontalAxisName = "SlideX";
        private string verticalAxisName = "SlideY";

        void OnEnable()
        {
            CrossPlatformInputManager.GetAxis(horizontalAxisName);
            CrossPlatformInputManager.GetAxis(verticalAxisName);
        }

        void Update()
        {

            if (cam_attach_flag == true || PlayManager.move_to_now_cat == true)
            {
                if (PlayManager.Top_Camera_Mode == false)
                {
                    //Y_Axis.transform.rotation = Quaternion.Slerp(Y_Axis.transform.rotation, Standard_Y_Axis.transform.rotation, 0.1f);
                    //X_Axis.transform.rotation = Quaternion.Slerp(X_Axis.transform.rotation, Standard_X_Axis.transform.rotation, 0.1f);
                    Y_Axis.transform.position = Vector3.Slerp(Y_Axis.transform.position, Now_Cat.transform.position, 0.1f);
                }
                else
                {
                    Y_Axis.transform.position = Vector3.Slerp(Y_Axis.transform.position, Now_Cat.transform.position, 0.1f);
                    Cam_Target.transform.position = Vector3.Slerp(Cam_Target.transform.position, Now_Cat.transform.position, 0.1f);
                    Y_Axis.transform.rotation = Quaternion.Slerp(Y_Axis.transform.rotation, Standard_Y_Axis.transform.rotation, 0.1f);
                    X_Axis.transform.rotation = Quaternion.Slerp(X_Axis.transform.rotation, Standard_X_Axis.transform.rotation, 0.1f);
                }
            }
            else
            {
                if (PlayManager.Top_Camera_Mode == true)
                {
                    Y_Axis.transform.rotation = Quaternion.Slerp(Y_Axis.transform.rotation, Standard_Y_Axis.transform.rotation, 0.1f);
                    X_Axis.transform.rotation = Quaternion.Slerp(X_Axis.transform.rotation, Standard_X_Axis.transform.rotation, 0.1f);
                    Y_Axis.transform.position = Vector3.Slerp(Y_Axis.transform.position, Cam_Target.transform.position, 0.1f);
                }
                else
                {
                    Y_Axis.transform.position = Vector3.Slerp(Y_Axis.transform.position, Now_Cat.transform.position, 0.1f);
                    Cam_Target.transform.position = Vector3.Slerp(Cam_Target.transform.position, Now_Cat.transform.position, 0.1f);
                }
            }

            switch (PlayManager.now_cat)
            {
                case "A_Choose":
                    {
                        Now_Cat = Cat_List[0];
                        break;
                    }
                case "B_Choose":
                    {
                        Now_Cat = Cat_List[1];
                        break;
                    }
                case "AB_Choose":
                    {
                        Now_Cat = Cat_List[2];
                        break;
                    }
                case "O_Choose":
                    {
                        Now_Cat = Cat_List[3];
                        break;
                    }
            }
        }

        public void OnDrag(PointerEventData data)
        {
            PlayManager.move_to_now_cat = false;
            Vector3 cam_pos = Cam_Target.transform.position;
            deltax = data.position.x - FirstPos.x;
            deltaz = data.position.y - FirstPos.y;
            if (PlayManager.Top_Camera_Mode == true)
            {
                if (cam_pos.x > -230 && cam_pos.x < 230 && cam_pos.z > -230 && cam_pos.z < 230)
                    Cam_Target.transform.Translate(-deltax / movescale, 0, -deltaz / movescale);
                else
                {
                    if (cam_pos.x < -230)
                    {
                        Cam_Target.transform.Translate(Mathf.Abs(deltax) / movescale, 0, -deltaz / movescale);
                    }
                    if (cam_pos.x > 230)
                    {
                        Cam_Target.transform.Translate(-Mathf.Abs(deltax) / movescale, 0, -deltaz / movescale);
                    }
                    if (cam_pos.z < -230)
                    {
                        Cam_Target.transform.Translate(-deltax / movescale, 0, Mathf.Abs(deltaz) / movescale);
                    }
                    if (cam_pos.z > 230)
                    {
                        Cam_Target.transform.Translate(-deltax / movescale, 0, -Mathf.Abs(deltaz) / movescale);
                    }                       
                }
            }
            else
            {
                Y_Axis.transform.Rotate(0, deltax / movescale*10, 0);
                X_Axis.transform.Rotate(-deltaz / movescale*10, 0, 0);
            }           
        }

        public void OnPointerDown(PointerEventData data)
        {
            FirstPos = data.position;
        }

    }
}