using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickCharacter : MonoBehaviour 
{
    public static int skill_point = 0;
    public static bool run_flag = false;
    public static bool attack_flag = false;
    public static bool aud_flag = true;
    public static bool[] angle_clockwise = new bool[4];
    public static float[] angle = new float[4];
    public float delta_angle = 45;
    public float Cat_between_InCat = 0;
    public float speed = 0.3f;
    public string cat_name = "";
    public Animation anim;
    public AnimationClip[] act;
    public GameObject InCat;
    public AudioSource aud;
    public AudioClip[] aud_clip;

	void Start () {
		
	}

	void Update () 
    {
        Cat_between_InCat = Mathf.Abs(transform.rotation.y - InCat.transform.rotation.y);

        if (PlayManager.now_cat == cat_name)
        {
            if (skill_point == 1)
            {
                if (anim.isPlaying)
                {
                    anim.clip = act[5];
                    anim.Play();
                    return;
                }
                else
                {
                    skill_point = 0;
                }
            }
            if (skill_point == 2 && PlayManager.now_cat == "A_Choose")
            {
                if (anim.isPlaying)
                {
                    anim.clip = act[5];
                    anim.Play();
                    if (aud_flag == true)
                    {
                        aud.clip = aud_clip[1];
                        aud.Play();
                        aud_flag = false;
                        PlayManager.Cat1[3] = PlayManager.Cat1[3] - (PlayManager.Cat1[2] - PlayManager.Cat1[1]);
                        PlayManager.Cat1[1] = PlayManager.Cat1[2];
                    }
                    return;
                }
                else
                {
                    skill_point = 0;
                }
            }
            if (skill_point == 2 && PlayManager.now_cat == "B_Choose")
            {
                JoyStickInsideCharacter.Ray.SetActive(false);
                if (anim.isPlaying)
                {
                    anim.clip = act[5];
                    anim.Play();
                    JoyStickInsideCharacter.sniper_flag = false;

                    if (aud_flag == true)
                    {
                        aud.clip = aud_clip[1];
                        aud.Play();
                        aud_flag = false;
                        
                        PlayManager.Cat2[3] = PlayManager.Cat2[3] - (PlayManager.Cat2[2] - PlayManager.Cat2[1]);
                        PlayManager.Cat2[1] = PlayManager.Cat2[2];
                    }
                    return;
                }
                else
                {
                    skill_point = 0;
                }
            }
            if (skill_point == 2 && PlayManager.now_cat == "AB_Choose")
            {
                if (anim.isPlaying)
                {
                    anim.clip = act[5];
                    anim.Play();
                    
                    if (aud_flag == true)
                    {
                        aud.clip = aud_clip[1];
                        aud.Play();
                        aud_flag = false;
                        JoyStickInsideCharacter.time = 0;
                        PlayManager.Cat3[3] = PlayManager.Cat3[3] - (PlayManager.Cat3[2] - PlayManager.Cat3[1]);
                        PlayManager.Cat3[1] = PlayManager.Cat3[2];
                    }
                    return;
                }
                else
                {
                    skill_point = 0;
                }
            }
            if (skill_point == 2 && PlayManager.now_cat == "O_Choose")
            {
                if (anim.isPlaying)
                {
                    anim.clip = act[5];
                    anim.Play();
                    if (aud_flag == true)
                    {
                        aud.clip = aud_clip[1];
                        aud.Play();
                        aud_flag = false;
                        PlayManager.Cat4[3] = PlayManager.Cat4[3] - (PlayManager.Cat4[2] - PlayManager.Cat4[1]);
                        PlayManager.Cat4[1] = PlayManager.Cat4[2];
                    }
                    return;
                }
                else
                {
                    skill_point = 0;
                }
            }

            if (run_flag == true && skill_point == 0)
            {
                if (!aud.isPlaying)
                {
                    aud.clip = aud_clip[0];
                    aud.Play();
                }
                transform.Translate(0, 0, -speed);

                if (attack_flag == false)
                {
                    anim.clip = act[1];
                    anim.Play();
                }
                else
                {
                    if (Cat_between_InCat < 0.25)
                    {
                        anim.clip = act[3];
                        anim.Play();
                    }
                    else
                    {
                        if (Cat_between_InCat < 0.75)
                        {
                            anim.clip = act[4];
                            anim.Play();
                        }
                        else
                        {
                            anim.clip = act[3];
                            anim.Play();
                        }
                    }
                }
            }
            else
            {
                if (attack_flag == false)
                {
                    anim.clip = act[0];
                    anim.Play();
                }
                else
                {
                    anim.clip = act[2];
                    anim.Play();
                }
            }

            switch (cat_name)
            {
                case "A_Choose":
                    {
                        if (angle_clockwise[0] == true)
                        {
                            switch (cat_name)
                            {
                                case "A_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[0] + delta_angle, 0));
                                        break;
                                    }
                                case "B_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[1] + delta_angle, 0));
                                        break;
                                    }
                                case "AB_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[2] + delta_angle, 0));
                                        break;
                                    }
                                case "O_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[3] + delta_angle, 0));
                                        break;
                                    }
                            }

                        }
                        else
                        {
                            switch (cat_name)
                            {
                                case "A_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[0] + delta_angle, 0));
                                        break;
                                    }
                                case "B_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[1] + delta_angle, 0));
                                        break;
                                    }
                                case "AB_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[2] + delta_angle, 0));
                                        break;
                                    }
                                case "O_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[3] + delta_angle, 0));
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "B_Choose":
                    {
                        if (angle_clockwise[1] == true)
                        {
                            switch (cat_name)
                            {
                                case "A_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[0] + delta_angle, 0));
                                        break;
                                    }
                                case "B_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[1] + delta_angle, 0));
                                        break;
                                    }
                                case "AB_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[2] + delta_angle, 0));
                                        break;
                                    }
                                case "O_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[3] + delta_angle, 0));
                                        break;
                                    }
                            }

                        }
                        else
                        {
                            switch (cat_name)
                            {
                                case "A_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[0] + delta_angle, 0));
                                        break;
                                    }
                                case "B_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[1] + delta_angle, 0));
                                        break;
                                    }
                                case "AB_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[2] + delta_angle, 0));
                                        break;
                                    }
                                case "O_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[3] + delta_angle, 0));
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "AB_Choose":
                    {
                        if (angle_clockwise[2] == true)
                        {
                            switch (cat_name)
                            {
                                case "A_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[0] + delta_angle, 0));
                                        break;
                                    }
                                case "B_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[1] + delta_angle, 0));
                                        break;
                                    }
                                case "AB_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[2] + delta_angle, 0));
                                        break;
                                    }
                                case "O_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[3] + delta_angle, 0));
                                        break;
                                    }
                            }

                        }
                        else
                        {
                            switch (cat_name)
                            {
                                case "A_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[0] + delta_angle, 0));
                                        break;
                                    }
                                case "B_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[1] + delta_angle, 0));
                                        break;
                                    }
                                case "AB_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[2] + delta_angle, 0));
                                        break;
                                    }
                                case "O_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[3] + delta_angle, 0));
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "O_Choose":
                    {
                        if (angle_clockwise[3] == true)
                        {
                            switch (cat_name)
                            {
                                case "A_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[0] + delta_angle, 0));
                                        break;
                                    }
                                case "B_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[1] + delta_angle, 0));
                                        break;
                                    }
                                case "AB_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[2] + delta_angle, 0));
                                        break;
                                    }
                                case "O_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, -angle[3] + delta_angle, 0));
                                        break;
                                    }
                            }

                        }
                        else
                        {
                            switch (cat_name)
                            {
                                case "A_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[0] + delta_angle, 0));
                                        break;
                                    }
                                case "B_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[1] + delta_angle, 0));
                                        break;
                                    }
                                case "AB_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[2] + delta_angle, 0));
                                        break;
                                    }
                                case "O_Choose":
                                    {
                                        transform.rotation = Quaternion.Euler(new Vector3(0, angle[3] + delta_angle, 0));
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }

        }
        else
        {
            anim.clip = act[0];
            anim.Play();
        }
	}
}
