using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    [Header("volume")]
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    [Header("difficulty")]
    [SerializeField] Slider difficultySlider;
    [SerializeField] int defaultDifficulty = 1;

	// Use this for initialization
	void Start () {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
        var musicPlayer = FindObjectOfType<MusicPlayer>();

        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);

        }
        else
        {
            Debug.LogWarning("No music player component found... start from splash screen");
        }
	}

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty((int)difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadStarScene();
    }

    public void SetDefaultSettings()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
