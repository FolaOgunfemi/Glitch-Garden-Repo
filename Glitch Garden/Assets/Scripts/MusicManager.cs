using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Delegates and events http://www.unitygeek.com/delegates-events-unity/
//In C# we have Delegates. They are reference objects that point to methods. It lets us treat a method as a variable and add and subtract methods to that method These are essentially interfaces since tghey are methods available to other classes outside of family, but  with only  a single method, or possibly multiple if it is a MultiCast Delegate
//These delegate methods can be subscribed to and unsubscribed to when they are no longer being used. It is important for scripts to unsubscribe after the use is complete to avoid memory leaks.
//an example would be subscribing in the start method, performing the logic, and unsubscribing in the later methods of the script after the essential logic has completed
//IF a gameObject is disabled, it will will be subscribed to the delegate . OnDisable is a good place to unsubscribe 
public class MusicManager : MonoBehaviour {
	
	public AudioClip[] levelMusicChangeArray; 
	private AudioSource audioSource;

///	public delegate void OnSceneLoaded();
///	public static OnSceneLoaded onSceneLoaded;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don't Destroy on load:" + name); //name returns name of game object

		audioSource = GetComponent<AudioSource> ();
	}

	///[Beginning] ADDED FOR ONSCENELOADED DELEGATE
	void OnEnable(){  //When GameObject is active (checkmark)
		Debug.Log ("OnEnable called");
		SceneManager.sceneLoaded += OnSceneLoaded;

	}

	void OnDisable(){ 
		Debug.Log ("OnDisable called");
		SceneManager.sceneLoaded -= OnSceneLoaded;

	}
		///[Ending] ADDED FOR ONSCENELOADED DELEGATE


	// Delegates and events http://www.unitygeek.com/delegates-events-unity/
	void OnSceneLoaded(Scene scene,  LoadSceneMode mode) {             //NOTE: this delegate will be loaded before void Start
//	void OnLevelWasLoaded(int level){  //native Unity method...DEPRECATED
		mode = LoadSceneMode.Single;  //loads a singles scene, closing the current one. Other option, "LoadSceneMode.Additive" would add it to another scene without closing anything

		int level = scene.buildIndex;
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
			
		Debug.Log("Playing clip:" + thisLevelMusic);

		if (thisLevelMusic) { //if there is an audioclip assigned to this level in the Music Manager Inspector
			audioSource.clip = thisLevelMusic;
			if (level != 0) { //loop eveerything but the Splash Screen
				audioSource.loop = true;
			}
			audioSource.Play ();
		} else {
			Debug.LogError("No Music assigned to this level");
		}
	}


	void Start () { //NOTE: the delegate OnSceneLoaded will be loaded before void Start
		///BUG-FIX - moved the below audioSource assignment to AWAKE. REASON-Every Scene, the delegate is called before Start meaning that the audiosources in each level are operated on before we set them equal to anything in the code
		//audioSource = GetComponent<AudioSource> ();

	}
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
