using UnityEngine;
using System.Collections;

public class LiquidumTrailEmitter : MonoBehaviour {
	
	public GameObject TrailDropPrefab;
	GameObject TrailDrop;
	public Material DefaultTrialMaterial;
	TrailRenderer trailRender;
	float MyTimer;
    public Color TrailsColor = new Color(0.6f, 0.6f, 0.7f, 0.5f);
    [Range(0f, 50f)]
    public float TrailDistortion = 40f;
    [Range(0.5f, 10f)]
    public float TrailCreationDelay = 2f;
    [Range(0f, 1f)]
    public float TrailMaxDistanceFromCenter = 1f;
    [Range(0f, 1f)]
    public float TrailMinDistanceFromCenter =0.5f;
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
		TrailDropPrefab.GetComponent<Renderer>().material=DefaultTrialMaterial;	
	}

	void Update () 
    {
        MyTimer += Time.deltaTime;
        if (MyTimer >= TrailCreationDelay)
        {
            Vector3 position = new Vector3(Random.Range((-TrailMaxDistanceFromCenter - TrailMinDistanceFromCenter) * 2.2f, (TrailMaxDistanceFromCenter + TrailMinDistanceFromCenter) * 2f),1.2f,2);
            if (position.x > -2 && position.x < 1.5f)
            {
                if (position.magnitude >= (TrailMinDistanceFromCenter) * 4.5f)
                {
                    TrailDrop = (GameObject)GameObject.Instantiate(TrailDropPrefab, transform.position, transform.rotation);
                    TrailDrop.transform.parent = transform;
                    TrailDrop.transform.localPosition = position;
                    MyTimer = 0;
                }
            }
        }
	}
}
