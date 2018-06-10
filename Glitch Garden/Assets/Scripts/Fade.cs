using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//

public class Fade : MonoBehaviour {
	//UI Panel was placed in the scene with a 255 alpha transparency and a black color. We will slowly fade it out to show the true background image
	// Panel needs to be below the other elements in the hierarchy. This will mean that buttons can't be clicked while it is present
	private Image fadePanel;

	private Color currentColor = Color.black;
	public float fadeInTime = 4f;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image> ();
			}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) { 
			float alphaChange = Time.deltaTime / fadeInTime; //If the frame lasts 2 seconds and the fade in time is 4 seconds, then it will take 2 seconds to completely fade in 

			currentColor.a -= alphaChange;//currentColor.a is the alpha
			fadePanel.color = currentColor;
		} else {
			gameObject.SetActive (false);   //Deactivate Panel so that buttons can be clicked
		}
		}
	}

