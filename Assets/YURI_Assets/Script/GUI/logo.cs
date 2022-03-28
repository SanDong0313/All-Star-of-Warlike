using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.CrossPlatformInput
{

    public class logo : MonoBehaviour
    {
        private string scene_name = "2_Main_UI";
        private Animation anim;
        private bool flag = true;

        private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;
        private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;
        private string horizontalAxisName = "SlideX";
        private string verticalAxisName = "SlideY";

        void Start()
        {
            anim = transform.GetComponent<Animation>();
            m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
            CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
            m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
            CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
        }

        void Update()
        {
            if (!anim.isPlaying || Input.anyKeyDown)
            {
                if (flag == true)
                {
                    SMGameEnvironment.Instance.SceneManager.LoadScreen(scene_name);
                    flag = false;
                }
            }
        }
    }
}
