using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public float autoLoadNextLevelAfter_Seconds;

	void Start() {
		if (autoLoadNextLevelAfter_Seconds != 0) {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter_Seconds); //invokers this method AFTER the number of seconds specified in autoLoadNextLevelAfter_Seconds
		} else {
			Debug.Log ("Auto-Load Next Level DISABLED!!");
		}
	}
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
		// Application.LoadLevel (name); This is Deprecated
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

			public void LoadNextLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1); /*Application.loadedLevel is deprecated. using SceneMAnager.GetActiveScene() instead*/
			}
}
