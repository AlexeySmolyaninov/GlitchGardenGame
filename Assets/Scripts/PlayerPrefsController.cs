using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour {

    //keys
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string GAME_COMPLETE_KEY = "game complete";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const int MIN_DIFFICULTY = 1;
    const int MAX_DIFFICULTY = 10;

    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } 
        else
        {
            Debug.LogError("volume value is not within a range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(int difficulty)
    {
        if(difficulty <= MAX_DIFFICULTY && difficulty >= MIN_DIFFICULTY)
        {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogWarning("difficulty value is not within a range");
        }
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }

    public static void SetLostGame()
    {
        PlayerPrefs.SetInt("game complete", 0);
    }

    public static void SetWonGame()
    {
        PlayerPrefs.SetInt("game complete", 1);
    }
}
