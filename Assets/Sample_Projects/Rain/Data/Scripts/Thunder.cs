using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour {

    public GameObject[] Thunders;
    public AudioSource aud;
    public AudioClip thaud;
    public int thundertime = 2000;
    private int tlen = 0;
    private float time;
    private int whichs = 0;
    private float destime = 0;
	void Start () 
    {
        for (int i = 0; i < 4; i++)
        {
            Thunders[i].SetActive(false);
        }
        tlen = Thunders.Length;
	}
	
	void Update () 
    {
        time++;
		if(time > thundertime)
        {  
            Thunders[whichs].SetActive(true);
            if(!aud.isPlaying)
            {
                aud.clip = thaud;
                aud.Play();
            }          
            destime++;
            if(destime > 5)
            {
                Thunders[whichs].SetActive(false);
                whichs = Random.Range(0, tlen);
                time = Random.Range(0, 1500);
                destime = 0;
            }          
        }     
	}
}
