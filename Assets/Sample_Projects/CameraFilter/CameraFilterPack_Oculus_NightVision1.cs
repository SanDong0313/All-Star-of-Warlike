////////////////////////////////////////////////////////////////////////////////////
//  CAMERA FILTER PACK - by VETASOFT 2014 //////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[AddComponentMenu ("Camera Filter Pack/Oculus/NightVision1")]
public class CameraFilterPack_Oculus_NightVision1 : MonoBehaviour {
	#region Variables
	public Shader SCShader;
	private float TimeX = 1.0f;

	private float Distortion = 1.0f;
	private Material SCMaterial;
	private Vector4 ScreenResolution;

	[Range(0, 100)]
	public float Vignette = 1.3f;
	[Range(1, 150)]
	public float Linecount = 90.0f;

	public static float ChangeVignette;
	public static float ChangeLinecount;

	#endregion
	
	#region Properties
	Material material
	{
		get
		{
			if(SCMaterial == null)
			{
				SCMaterial = new Material(SCShader);
				SCMaterial.hideFlags = HideFlags.HideAndDontSave;	
			}
			return SCMaterial;
		}
	}
	#endregion
	void Start () 
	{
		ChangeVignette = Vignette;
		ChangeLinecount= Linecount;

		SCShader = Shader.Find("CameraFilterPack/Oculus_NightVision1");

		if(!SystemInfo.supportsImageEffects)
		{
			enabled = false;
			return;
		}
	}
	
	void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if(SCShader != null)
		{
			TimeX+=Time.deltaTime;
			if (TimeX>100)  TimeX=0;
			material.SetFloat("_TimeX", TimeX);
			material.SetFloat("_Distortion", Distortion);
			material.SetVector("_ScreenResolution",new Vector4(sourceTexture.width,sourceTexture.height,0.0f,0.0f));

			material.SetFloat("_Vignette", Vignette);
			material.SetFloat("_Linecount", Linecount);

			Graphics.Blit(sourceTexture, destTexture, material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);	
		}
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Application.isPlaying)
		{
		}
		#if UNITY_EDITOR
		if (Application.isPlaying!=true)
		{
			SCShader = Shader.Find("CameraFilterPack/Oculus_NightVision1");

		}
		#endif

	}
	
	void OnDisable ()
	{
		if(SCMaterial)
		{
			DestroyImmediate(SCMaterial);	
		}
		
	}
	
	
}