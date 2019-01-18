using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master volume";

    const float MIN_VOL = 0f;
    const float MAX_VOL = 1f;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOL && volume <= MAX_VOL)
        {
            Debug.Log("Master volume set to" + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }

    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

}
