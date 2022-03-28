using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif	
using System.Collections;

public class LiquidumRainEmitter : MonoBehaviour {

    public GameObject TheCam;
	 Transform thisTransform;
	 ParticleSystem Ps;
	 public ParticleSystem CollisionPs;
	 AudioSource RainSound;
	 float OrVolume;
	 float RanTurbolence;
	 [HideInInspector]
	 public float RainTimer;	
	 public Material SimpleRain;
	 public Material DistortRain;
	 GameObject RainFogEmitter;
     bool StartFadeInVolume,StartFadeOutVolume=false;
	 Camera cam;

     public bool RainEmit = true;
     public bool UseDistortionRain;
     public GameObject RainEmitterPrefab;
     public AudioClip RainSoundClip;
     [Range(0f, 1f)]
     public float RainSoundVolume = 1;
     [Range(0.01f, 1f)]
     public float RainVolumeFadeSpeed = 0.1f;
     public Color RainColor = new Color(0.6f, 0.6f, 0.7f, 0.5f);
     [Range(1f, 20f)]
     public float RainSpeed = 20f;
     [Range(0.01f, 1f)]
     public float RainSize = 0.1f;
     [Range(0.01f, 5f)]
     public float RainCollisionSpriteSize = 0.1f;
     [Range(0.01f, 5f)]
     public float RainCollisionSplashPower = 0.01f;
     [Range(1f, 10000f)]
     public int EmissionRate = 1000;
     [Range(-40f, 40f)]
     public float ConstantAngle;
     [Range(0f, 3f)]
     public float AddRainTurbolence;
     [Range(1f, 100f)]
     public float RainEmitterHeigth = 10f;
     [Range(0f, 5f)]
     public float RainLifeTime = 2;
     [Range(0.1f, 3f)]
     public float RainGravity = 1;	

	
	
	
	void Awake () 
    {
	    thisTransform=transform;
	    Ps=thisTransform.GetComponent<ParticleSystem>();
	    cam=Camera.main;	
	}
	
    void Start() {		
		
	RainSound = gameObject.AddComponent<AudioSource>() as AudioSource;
	OrVolume = RainSoundVolume;
	RainSound.clip = RainSoundClip;
	RainSound.loop = true;
	RainSound.volume=0;
		
		
			if(UseDistortionRain){
				Ps.GetComponent<Renderer>().material=DistortRain;
			Ps.GetComponent<Renderer>().material.SetColor("_Color", RainColor);}
			else{
				Ps.GetComponent<Renderer>().material=SimpleRain;  
			Ps.GetComponent<Renderer>().material.SetColor("_TintColor", RainColor);
			}	
		
		
    }
	

		public void PlaySound () {
		
		if(!RainSound.isPlaying){
		   StartFadeOutVolume=false;
		   StartFadeInVolume=true;
		   RainSound.Play();}
	}

	
			public void StopSound () {
		
		if(RainSound.isPlaying){
		   StartFadeInVolume=false;
		   StartFadeOutVolume=true;
			
		   }
	}
	
	

			public void SoundFadeIn () {
		
		RainSound.volume=Mathf.Lerp(RainSound.volume,OrVolume,RainVolumeFadeSpeed*Time.deltaTime);
		if(RainSound.volume>=OrVolume/1.05f)StartFadeInVolume=false;
	}

		   public void SoundFadeOut () {
		
		RainSound.volume=Mathf.Lerp(RainSound.volume,0,RainVolumeFadeSpeed*Time.deltaTime*10);
		if(RainSound.volume<=0.01){StartFadeOutVolume=false; RainSound.Stop();}
	}
	
	
	
	
		void NOCurveUse () {
		
		if(StartFadeInVolume) SoundFadeIn ();
		if(StartFadeOutVolume) SoundFadeOut ();
		
		Ps.enableEmission= RainEmit;
		
		
		if(RainEmit)
        {
			RainTimer+=Time.deltaTime;
            PlaySound (); 
		    Ps.startSpeed=RainSpeed/1.5f;
		    Ps.startSize=RainSize/10;		
		    Ps.emissionRate=EmissionRate;
		    Ps.startLifetime=RainLifeTime;
		    Ps.gravityModifier=RainGravity;
		    CollisionPs.startSize=RainCollisionSpriteSize/10;
		    CollisionPs.startSpeed=RainCollisionSplashPower*3;		
		    Ps.startColor=RainColor;
			
		if(AddRainTurbolence>0){
			 RanTurbolence=Random.Range(-AddRainTurbolence*15,AddRainTurbolence*15);
			}else{
			 RanTurbolence=0;
			}
			
			
			
			Vector3 CostRot= new Vector3(90+ConstantAngle+RanTurbolence,ConstantAngle+RanTurbolence,ConstantAngle+RanTurbolence);
		    thisTransform.eulerAngles =CostRot;


	}
		else{
			StopSound ();
		    RainTimer=0;
		
		
		
		}
	}
	
	
	
	
	
	
	
	void CurveUse () 
    {	
		Ps.enableEmission= RainEmit;
		if(RainEmit)
        {
			RainTimer+=Time.deltaTime;//Useful to delay the start of drops on screen after rain start
			
		RainSound.volume=RainSoundVolume;

        PlaySound (); 
		Ps.startSpeed=RainSpeed/1.5f;
		Ps.startSize=RainSize/10;		
		Ps.emissionRate=EmissionRate;
		Ps.startLifetime=RainLifeTime;
		Ps.gravityModifier=RainGravity;
		CollisionPs.startSize=RainCollisionSpriteSize/10;
		CollisionPs.startSpeed=RainCollisionSplashPower*3;
		
		Ps.startColor=RainColor;
			
		if(AddRainTurbolence>0)
        {
			 RanTurbolence=Random.Range(-AddRainTurbolence*10,AddRainTurbolence*10);	
		}
        else
        {
			 AddRainTurbolence=0;	
			 RanTurbolence=0;
		}	
		Vector3 CostRot= new Vector3(90+ConstantAngle+RanTurbolence,ConstantAngle+RanTurbolence,ConstantAngle+RanTurbolence);
		if(CostRot.magnitude<0)
            CostRot=Vector3.zero;
		thisTransform.eulerAngles =CostRot;
	}
	    else
        {
			StopSound ();
		    RainTimer=0;
		}
	}
	
	void Update () 
    {
		NOCurveUse ();
		CurveUse ();
		thisTransform.position=new Vector3(cam.transform.position.x,cam.transform.position.y+RainEmitterHeigth,cam.transform.position.z)+TheCam.transform.forward*1.5f;
	}
}
