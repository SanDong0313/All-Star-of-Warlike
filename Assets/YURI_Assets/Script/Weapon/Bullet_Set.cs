using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Set : MonoBehaviour 
{
    private float range = 5;
    private GameObject BulletPos;
    private bool bullet = true;
    public GameObject Exp;

    void Start()
    {
        switch (PlayManager.now_cat)
        {
            case "A_Choose":
                {
                    BulletPos = GameObject.Find("FirePos1");
                    bullet = true;
                    range = 5;
                    break;
                }
            case "B_Choose":
                {
                    BulletPos = GameObject.Find("FirePos2");
                    bullet = true;
                    range = 7;
                    break;
                }
            case "AB_Choose":
                {
                    BulletPos = GameObject.Find("FirePos3");
                    bullet = false;
                    range = 8;
                    break;
                }
            case "O_Choose":
                {
                    BulletPos = GameObject.Find("FirePos4");
                    bullet = true;
                    range = 5;
                    break;
                }
        }
    }

	void Update () 
    {
        transform.Translate(0, 0, -0.1f);
        if (Vector3.Distance(transform.position, BulletPos.transform.position) > range)
        {
            if (bullet == true)
            {
                Destroy(gameObject);
            }
            else
            {
                Instantiate(Exp, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
            
	}

    public void OnCollisionEnter(Collision col)
    {
        switch (col.transform.tag)
        {
            case "rock":
                {
                    break;
                }
            case "iron":
                {
                    break;
                }
        }
    }
}
