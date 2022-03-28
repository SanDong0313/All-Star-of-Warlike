using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickInsideCharacter : MonoBehaviour 
{
    public static int time = 0;
    private bool fire_flag = false;
    public static bool attack_down = false;
    public static bool run_flag = false;
    public static bool angle_clockwise = true;
    public static bool inside_cat_rotate = false;
    public static bool sniper_flag = false;
    public static float angle;
    public float delta_angle = 0;
    public GameObject Cat_Target;
    public GameObject Bullet;
    public GameObject BulletPos;
    public GameObject Info_View_UI;
    public GameObject Info_View_UI_Target;
    public static GameObject Ray;
    public AudioSource aud;
    public AudioClip[] ac;
    public string InCat_name = "";
    public GameObject[] Fume_list;
    public GameObject[] Fume_pos;

    void Start()
    {
        Ray = GameObject.Find("Ray");
    }

    void Update()
    {
        
        Info_View_UI.transform.LookAt(Info_View_UI_Target.transform);

        if (attack_down == true)
        {
            if (PlayManager.now_cat == InCat_name)
            {
                if (angle_clockwise == true)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, -angle + delta_angle, 0));
                }
                else
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, angle + delta_angle, 0));
                }
                if (PlayManager.now_cat == "A_Choose" && JoyStickCharacter.skill_point == 0)
                {

                    time++;
                    if (time > 5)
                    {
                        if (PlayManager.Cat1[1] == 0)
                        {
                            JoyStickCharacter.skill_point = 2;
                            JoyStickCharacter.aud_flag = true;
                        }
                        else
                        {
                            PlayManager.Cat1[1]--;
                            fire_flag = true;
                        }
                        if (fire_flag == true)
                        {
                            Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
                            aud.clip = ac[0];
                            aud.Play();
                            time = 0;
                        }
                    }
                }
                if (PlayManager.now_cat == "B_Choose" && JoyStickCharacter.skill_point == 0)
                {
                    Ray.SetActive(true);
                        if (PlayManager.Cat2[1] == 0)
                        {
                            JoyStickCharacter.skill_point = 2;
                            JoyStickCharacter.aud_flag = true;
                        }
                        else
                        {
                            if (sniper_flag == true)
                            {
                                PlayManager.Cat2[1]--;
                                fire_flag = true;
                            }
                        }
                        if (fire_flag == true)
                        {
                            Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
                            aud.clip = ac[0];
                            aud.Play();
                            sniper_flag = false;
                            attack_down = false;
                            JoyStickCharacter.attack_flag = false;
                            fire_flag = false;
                        }
                }
                if (PlayManager.now_cat == "AB_Choose" && JoyStickCharacter.skill_point == 0)
                {

                    time++;
                    if (time > 30)
                    {
                        if (PlayManager.Cat3[1] <1)
                        {
                            JoyStickCharacter.skill_point = 2;
                            JoyStickCharacter.aud_flag = true;
                        }
                        else
                        {
                            PlayManager.Cat3[1]--;
                            fire_flag = true;
                        }
                        if (fire_flag == true)
                        {
                            Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
                            Instantiate(Fume_list[0], Fume_pos[0].transform.position, Fume_pos[0].transform.rotation);
                            aud.clip = ac[0];
                            aud.Play();
                            time = 0;
                            fire_flag = false;
                        }
                    }
                }
                if (PlayManager.now_cat == "O_Choose" && JoyStickCharacter.skill_point == 0)
                {

                    time++;
                    if (time > 10)
                    {
                        if (PlayManager.Cat4[1] == 0)
                        {
                            JoyStickCharacter.skill_point = 2;
                            JoyStickCharacter.aud_flag = true;
                        }
                        else
                        {
                            PlayManager.Cat4[1]--;
                        }
                        Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
                        aud.clip = ac[0];
                        aud.Play();                        
                        time = 0;
                    }
                }
            }
        }
        else
        {
            Ray.SetActive(false);
        }

        if(inside_cat_rotate == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Cat_Target.transform.rotation, 0.1f);
        }
    }
}
