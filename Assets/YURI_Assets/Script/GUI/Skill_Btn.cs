using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Btn : MonoBehaviour 
{
    private string skill_btn_name = "";

	void Start () 
    {
        skill_btn_name = transform.name;
	}

    public void OnSkillBtn()
    {
        switch (skill_btn_name)
        {
            case "Dodge":
                {
                    JoyStickCharacter.skill_point = 1;
                    break;
                }
            case "Charge":
                {
                    JoyStickCharacter.skill_point = 2;
                    JoyStickCharacter.aud_flag = true;
                    break;
                }
        }
    }

}
