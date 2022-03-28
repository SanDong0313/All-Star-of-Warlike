using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{
        private float angle = 0;
        private float preangle = 0;
		private int MovementRange = 65;        
		private string horizontalAxisName = "Garo";
		private string verticalAxisName = "Seoro";
		private Vector2 m_StartPos;
        private Vector2 newPos;
		private bool m_UseX;
		private bool m_UseY; 
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; 
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		void OnEnable()
		{
            //CrossPlatformInputManager.GetAxis(horizontalAxisName);
            //CrossPlatformInputManager.GetAxis(verticalAxisName);
			CreateVirtualAxes();
		}
        void Start()
        {
            m_StartPos = transform.position;
            newPos = m_StartPos;
        }

        void Update()
        {
            if (newPos != m_StartPos)
            {
                JoyStickCharacter.run_flag = true;
            }
            else
            {
                JoyStickCharacter.run_flag = false;
            }
        }
		void CreateVirtualAxes()
		{
            m_UseX = true;
            m_UseY = true;
			if (m_UseX)
			{
				m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
			}
			if (m_UseY)
			{
				m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
			}
		}
		public void OnDrag(PointerEventData data)
		{
			newPos = Vector2.zero;
			if (m_UseX)
			{
				int delta = (int)(data.position.x - m_StartPos.x);
				delta = Mathf.Clamp(delta, - MovementRange, MovementRange);
				newPos.x = delta;
			}
			if (m_UseY)
			{
				int delta = (int)(data.position.y - m_StartPos.y);
				delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
				newPos.y = delta;
			}
            float now_radius = Mathf.Sqrt(newPos.x * newPos.x + newPos.y * newPos.y);
            if (MovementRange < now_radius)
            {
                newPos.y = MovementRange * newPos.y / now_radius;
                newPos.x = MovementRange * newPos.x / now_radius;
                transform.position = new Vector2(m_StartPos.x + newPos.x, m_StartPos.y + newPos.y);
            }
            else 
            {
                transform.position = new Vector2(m_StartPos.x + newPos.x, m_StartPos.y + newPos.y);
            }

            switch (PlayManager.now_cat)
            {
                case "A_Choose":
                    {
                        JoyStickCharacter.angle[0] = Mathf.Acos(newPos.y / now_radius) * Mathf.Rad2Deg;
                        angle = JoyStickCharacter.angle[0];
                        preangle = JoyStickCharacter.angle[0];
                        
                        break;
                    }
                case "B_Choose":
                    {
                        JoyStickCharacter.angle[1] = Mathf.Acos(newPos.y / now_radius) * Mathf.Rad2Deg;
                        angle = JoyStickCharacter.angle[1];
                        preangle = JoyStickCharacter.angle[1];
                        
                        break;
                    }
                case "AB_Choose":
                    {
                        JoyStickCharacter.angle[2] = Mathf.Acos(newPos.y / now_radius) * Mathf.Rad2Deg;
                        angle = JoyStickCharacter.angle[2];
                        preangle = JoyStickCharacter.angle[2];
                        
                        break;
                    }
                case "O_Choose":
                    {
                        JoyStickCharacter.angle[3] = Mathf.Acos(newPos.y / now_radius) * Mathf.Rad2Deg;
                        angle = JoyStickCharacter.angle[3];
                        preangle = JoyStickCharacter.angle[3];
                        
                        break;
                    }
            }
            
            if (newPos.x > 0)
            {
                if (angle > preangle)
                {
                    switch (PlayManager.now_cat)
                    {
                        case "A_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[0] = true;
                                break;
                            }
                        case "B_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[1] = true;
                                break;
                            }
                        case "AB_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[2] = true;
                                break;
                            }
                        case "O_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[3] = true;
                                break;
                            }
                    }
                    
                }                   
                else
                {
                    switch (PlayManager.now_cat)
                    {
                        case "A_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[0] = false;
                                break;
                            }
                        case "B_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[1] = false;
                                break;
                            }
                        case "AB_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[2] = false;
                                break;
                            }
                        case "O_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[3] = false;
                                break;
                            }
                    }
                }
            }
            else
            {
                if (angle > preangle)
                {
                    switch (PlayManager.now_cat)
                    {
                        case "A_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[0] = false;
                                break;
                            }
                        case "B_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[1] = false;
                                break;
                            }
                        case "AB_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[2] = false;
                                break;
                            }
                        case "O_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[3] = false;
                                break;
                            }
                    }
                }
                else
                {
                    switch (PlayManager.now_cat)
                    {
                        case "A_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[0] = true;
                                break;
                            }
                        case "B_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[1] = true;
                                break;
                            }
                        case "AB_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[2] = true;
                                break;
                            }
                        case "O_Choose":
                            {
                                JoyStickCharacter.angle_clockwise[3] = true;
                                break;
                            }
                    }
                }
            }        
		}
		public void OnPointerUp(PointerEventData data)
		{

			transform.position = m_StartPos;
            newPos = m_StartPos;
            JoyStickTotalCamera.cam_attach_flag = false;
            JoyStickInsideCharacter.inside_cat_rotate = false;

		}
		public void OnPointerDown(PointerEventData data) 
        {
            JoyStickTotalCamera.cam_attach_flag = true;
            JoyStickInsideCharacter.inside_cat_rotate = true;
            PlayManager.move_to_now_cat = false;
        }

		void OnDisable()
		{
			if (m_UseX)
			{
				m_HorizontalVirtualAxis.Remove();
			}
			if (m_UseY)
			{
				m_VerticalVirtualAxis.Remove();
			}
		}
	}
}