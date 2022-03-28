using UnityEngine;
using System.Collections;

public class LiquidumTrailDrop : MonoBehaviour {

	float speed;
	float MyTimer;
	float YSpeed,XSpeed,TmpYSpeed;
	float Ran;
	float updateInterval=0.2f;
	TrailRenderer ThisTrailRender;
	TrailRenderer coda;
	TrailRenderer sfondo;
	float scale;
	float RanScale=1;
	float GoYSpeed=1;
	float GoXSpeed=1;
	public bool ChangeAtRunTime =false; 
	public bool UsebackgroundTrial =false;
    public Color TrailsColor = new Color(0.6f, 0.6f, 0.7f, 0.5f);
    [Range(0f, 50f)]
    public float TrailDistortion = 40f;
    [Range(0.5f, 10f)]
    public float TrailCreationDelay = 2f;
    [Range(0f, 1f)]
    public float TrailMaxDistanceFromCenter = 1f;
    [Range(0f, 1f)]
    public float TrailMinDistanceFromCenter = 0.5f;
    [Range(1f, 200f)]
    public float TrailSlipSpeed = 40f;
    [Range(0.1f, 1f)]
    public float TrailDropsFriction = 0.85f;
    [Range(0.1f, 2f)]
    public float TrialTail = 1.5f;
    [Range(-1f, 1f)]
    public float TrailConstantAngle = 0.1f;
    [Range(0.5f, 10f)]
    public float TrailScale = 4f;
	
	void Start () 
    {
		ThisTrailRender=GetComponent<TrailRenderer>();
		scale=TrailScale/100;
		Color MainColor=TrailsColor/5;
		Color sfondoColor=(MainColor/30)+new Color(0.02f,0.02f,0.02f,0.02f);	
		coda=transform.GetChild(0).GetComponentInChildren<TrailRenderer>();
		coda.GetComponent<Renderer>().material.SetColor("_Color",MainColor);
		coda.GetComponent<Renderer>().material.SetFloat("_BumpAmt",TrailDistortion*8f);
		if(sfondo)sfondo=transform.GetChild(1).GetComponentInChildren<TrailRenderer>();
		if(sfondo)sfondo.GetComponent<Renderer>().material.SetColor("_Color",sfondoColor);
		if(sfondo)sfondo.GetComponent<Renderer>().material.SetFloat("_BumpAmt",TrailDistortion*5f);			
		TrialUpdate();
	}
	
	void TrialUpdate()
    {		
	    ThisTrailRender.startWidth=scale*RanScale;
	    coda.startWidth=scale*RanScale*0.6f;
        if(sfondo)sfondo.startWidth=scale*RanScale*3f;
	    ThisTrailRender.time=TrialTail/5f;
	    coda.time=TrialTail*1.5f;
	    if(sfondo)sfondo.time=TrialTail*3f;		 
    }

	void Update () 
    {		
		speed=TrailSlipSpeed;	
		MyTimer+=Time.deltaTime;	
		if(MyTimer>updateInterval)
        {		
		    TmpYSpeed=Random.Range(1f,speed)* Time.deltaTime;		
		    XSpeed=Random.Range(-0.05f,0.05f);
		    Ran=Random.Range(0f,1f);		
			if(YSpeed<0.001)
            {
			    RanScale+=0.5f* Time.deltaTime;
			    XSpeed+=1.5f* Time.deltaTime;
			}
            else
            {		
                RanScale-=0.02f* Time.deltaTime;
			    XSpeed-=1.5f* Time.deltaTime;
			}		
			RanScale=Mathf.Clamp(RanScale,1f,2);
		    if(ChangeAtRunTime)	
                TrialUpdate();		
	        MyTimer=0;
			
	    }		
		YSpeed=Mathf.Lerp(YSpeed,TmpYSpeed, 0.02f* Time.deltaTime);
		if(Ran<TrailDropsFriction)
        {
		    GoYSpeed=YSpeed/2f;
            GoXSpeed=XSpeed* Time.deltaTime;
	    }
        else
        {
		    GoYSpeed=YSpeed*3f;
            GoXSpeed=XSpeed/1.5f* Time.deltaTime;
	    }
		if(Time.timeScale>0.01f)
        {
		    transform.position -= transform.up * GoYSpeed;
		    transform.position += transform.right *(GoXSpeed+TrailConstantAngle/100);
		}		
	    if(transform.localPosition.y<-3f*TrialTail)
	        Destroy(gameObject);	
	}
}