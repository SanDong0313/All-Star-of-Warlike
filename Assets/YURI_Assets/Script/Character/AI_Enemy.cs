using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemy : MonoBehaviour 
{
    public GameObject[] Target;
    private GameObject Now_Target;
    public GameObject bullet;
    public GameObject[] fire_pos;
    private float Min_Distance = Mathf.Infinity;
    private float Now_Distance = 0;
    private int range = 5;
    private NavMeshAgent agent;

    public Animation anim;
    public AnimationClip[] act;

    public AudioSource aud;
    public AudioClip fire_aud;

    private int fire_time = 0;
	// Use this for initialization
	void Start () 
    {
        Target = GameObject.FindGameObjectsWithTag("we");
        agent = GetComponent<NavMeshAgent>();
	}
	
	void Update () 
    {
        for (int i = 0; i < Target.Length; i++)
        {
            if (Vector3.Distance(transform.position, Target[i].transform.position) < Min_Distance)
            {
                Now_Target = Target[i];
            }
        }

        Now_Distance = Vector3.Distance(transform.position, Now_Target.transform.position);

        if (Now_Distance > range)
        {
            agent.destination = Now_Target.transform.position;
            anim.clip = act[0];
            anim.Play();
        }
        else
        {
            agent.destination = transform.position;
            anim.clip = act[1];
            anim.Play();

            fire_time++;
            if (fire_time > 35)
            {
                Instantiate(bullet, fire_pos[0].transform.position, fire_pos[0].transform.rotation);
                Instantiate(bullet, fire_pos[1].transform.position, fire_pos[1].transform.rotation);
                Instantiate(bullet, fire_pos[2].transform.position, fire_pos[2].transform.rotation);
                aud.clip = fire_aud;
                aud.Play();
                fire_time = 0;
            }
        }
	}
}
