using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lib_UI : MonoBehaviour 
{
    private Animation anim;
    public AnimationClip[] anim_clip;
    public static int anim_i = 0;
    public static bool anim_flag = true;

	void Start () 
    {
        anim = transform.GetComponent<Animation>();
	}
	
	void Update () 
    {
        if (!anim.isPlaying)
        {
            if (anim_i == 1 && anim_flag == true)
            {
                anim.clip = anim_clip[0];
                anim.Play();
            }
            if (anim_i == 2 && anim_flag == true)
            {
                anim.clip = anim_clip[1];
                anim.Play();
            }
            if (anim_i == 3 && anim_flag == true)
            {
                anim.clip = anim_clip[2];
                anim.Play();
            }
            if (anim_i == 4 && anim_flag == true)
            {
                anim.clip = anim_clip[3];
                anim.Play();
            }
        }
        else
        {
            anim_flag = false;
        }
	}
}
