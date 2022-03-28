//
// Copyright (c) 2013 Ancient Light Studios
// All Rights Reserved
// 
// http://www.ancientlightstudios.com
//

using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// The base class for all level transitions.
/// </summary>
public abstract class SMTransition : MonoBehaviour {
	
	protected SMTransitionState state = SMTransitionState.Out;
	
	public bool loadAsync = false;
	
	/// <summary>
	/// The id of the screen that is being loaded.
	/// </summary>
	[HideInInspector]
	public string screenId;
	
	void Start() {
		StartCoroutine(DoTransition());
	}

	/// <summary>
	/// This method actually does the transition. It is run in a coroutine and therefore needs to do
	/// yield returns to play an animation or do another progress over time. When this method returns
	/// the transition is expected to be finished.
	/// </summary>
	/// <returns>
	/// A <see cref="IEnumerator"/> for showing the transition status. Use yield return statements to keep
	/// the transition running, otherwise simply end the method to stop the transition.
	/// </returns>
	protected virtual IEnumerator DoTransition() {
		state = SMTransitionState.Out;
		Prepare();
		float time = 0;
		
		while(Process(time)) {
			time += Time.deltaTime;
			// wait for the next frame
			yield return 0;
		}
		
		// wait another frame...
		yield return 0;
		
		state = SMTransitionState.Hold;
		DontDestroyOnLoad(gameObject);

		// wait another frame...
		yield return 0;
		
		IEnumerator loadLevel = DoLoadLevel();
		while (loadLevel.MoveNext()) {
			yield return loadLevel.Current;
		}
		 
		// wait another frame...
		yield return 0;

		state = SMTransitionState.In;
		Prepare();
		time = 0;

		while(Process(time)) {
			time += Time.deltaTime;
			// wait for the next frame
			yield return 0;
		}

		// wait another frame...
		yield return 0;
		
		Destroy(gameObject);
	}
	
	/// <summary>
	/// invoked during the <see cref="SMTransitionState.Hold"/> state to load the next scene. 
	/// Override this method to interrupt the transition before or after loading the scene. 
	/// Make sure to call <code>yield return base.LoadLevel()</code> in your implementation.
	/// </summary>
	/// <returns>
	/// A <see cref="IEnumerator"/> 
	/// </returns>
	protected virtual IEnumerator DoLoadLevel() {
		yield return LoadLevel();
	}
	
	/// <summary>
	/// Starts the actual load operation
	/// </summary>
	/// <returns>
	/// The load operation or <code>null</code>
	/// </returns>
	protected virtual YieldInstruction LoadLevel() {
		if (loadAsync) {
			return Application.LoadLevelAsync(screenId);
		} else {
			Application.LoadLevel(screenId);
			return null;
		}
	}
	
	/// <summary>
	/// invoked at the start of the <see cref="SMTransitionState.In"/> and <see cref="SMTransitionState.Out"/> state to 
	/// initialize the transition
	/// </summary>
	protected virtual void Prepare() {
	}
	
	/// <summary>
	/// Invoked once per frame while the transition is in state <see cref="SMTransitionState.In"/> or <see cref="SMTransitionState.Out"/> 
	/// to calculate the progress
	/// </summary>
	/// <param name='elapsedTime'>
	/// the time that has elapsed since the start of current transition state in seconds. 
	/// </param>
	/// <returns>
	/// false if no further calls are necessary for the current state, true otherwise
	/// </returns>
	protected abstract bool Process(float elapsedTime);
}
