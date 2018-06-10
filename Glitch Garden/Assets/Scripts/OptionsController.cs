using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    //Difficulty must be an integer between 1 and 3. This is set in the difficulty Slider in the editor
    public Slider difficultySlider;
    public LevelManager levelManager;

    //Note: Music Manager only exists when it is instantiated in the Splash Screen. We will need to manipulate via code to grab it.
    private MusicManager musicManager;


    // Use this for initialization
    void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        Debug.Log(musicManager); //Confirm that Persistant Music exists

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }
	
	// Update is called once per frame
	void Update () { //While Sliding, we want to hear the change in music volume w/o having to go Back to Start Menu to hear it.
        musicManager.ChangeVolume(volumeSlider.value);

	}

    //The Options will Save and Exit when the User hits the Back Button. OptionsController will be on the  OnClickEvent For the "Back Button" in "Options"
    public void SaveAndExit()
    { 
        
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);

        //includes LevelManager logic. This will be the new OnClick in "Options", replacing LevelManager.loadLevel()
        levelManager.LoadLevel(name: "01a-Start Menu");

    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2f;
    }
}
