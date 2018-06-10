using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <WRAPPER CLASS FOR Unity PlayerPrefs>
/// Purpose:
/// 	//It is impossible to search through previously saved PlayerPrefs without knowing the exact name etc. This script will store all of the keys in one place so that they can be referenced in one place without searching through every script in a project that may or may not reference PlayerPrefs
/// P//// </summary>


public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
		const string LEVEL_KEY = "level_unlocked_"; //underscore saved to provide space before level name


	public static void SetMasterVolume (float volume) {
		if (volume >= 0f && volume <= 1f) { // make sure the input is valid
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("volume out of range"); //logs message as an error so that it can be easily filtered for in the editor
		}
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);

	}

	public static void UnlockLevel (int level) {
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			//	if (level <= Application.levelCount - 1) { this is deprecated 
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); // Use 1 for true since we don't have bools
		} else {
			Debug.LogError ("Trying to unlock level that is not in build order!");
		}
	}



	public static bool IsLevelUnlocked (int level) {
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);		

		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
	//	if (level <= Application.levelCount - 1) { this is deprecated 
			return isLevelUnlocked;
		} else {
			Debug.LogError ("Trying to query level not in build order");
			return false;
		}
	}

    //Difficulty must be an integer between 1 and 3. This is set in the difficulty Slider in the editor
	public static void SetDifficulty (float difficulty) {
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Difficulty out of range");
		}
	}

	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
}


