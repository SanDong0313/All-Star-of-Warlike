using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class JoyStickAttack : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        private int MovementRange = 65;
        private float preangle;
        private string horizontalAxisName = "AGaro";
        private string verticalAxisName = "ASeoro";
        private Vector2 m_StartPos;
        private Vector2 newPos;
        private bool m_UseX;
        private bool m_UseY;
        private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;
        private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

        void OnEnable()
        {
            CreateVirtualAxes();
        }
        void Start()
        {
            m_StartPos = transform.position;
            newPos = m_StartPos;
        }

        void Update()
        {

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
                JoyStickInsideCharacter.attack_down = true;          

            newPos = Vector2.zero;
            if (m_UseX)
            {
                int delta = (int)(data.position.x - m_StartPos.x);
                delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
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

            JoyStickInsideCharacter.angle = Mathf.Acos(newPos.y / now_radius) * Mathf.Rad2Deg;

            JoyStickCharacter.attack_flag = true;

            preangle = JoyStickInsideCharacter.angle;

            if (newPos.x > 0)
            {
                if (JoyStickInsideCharacter.angle > preangle)
                {
                    JoyStickInsideCharacter.angle_clockwise = true;
                }
                else
                {
                    JoyStickInsideCharacter.angle_clockwise = false;
                }
            }
            else
            {
                if (JoyStickInsideCharacter.angle > preangle)
                {
                    JoyStickInsideCharacter.angle_clockwise = false;
                }
                else
                {
                    JoyStickInsideCharacter.angle_clockwise = true;
                }
            }
        }
        public void OnPointerUp(PointerEventData data)
        {
            transform.position = m_StartPos;
            newPos = m_StartPos;
            JoyStickInsideCharacter.attack_down = false;
            JoyStickCharacter.attack_flag = false;
            if (PlayManager.now_cat == "B_Choose")
            {
                JoyStickInsideCharacter.sniper_flag = true;
                JoyStickInsideCharacter.attack_down = true;
                JoyStickCharacter.attack_flag = true;
            }
        }
        public void OnPointerDown(PointerEventData data)
        {
            
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