using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinThemePlayer : MonoBehaviour {

    AudioSource audioSource; 

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }




    public void SetVolume(float volume)
    {
        audioSource.volume = volume; 
    }


    private void Update()
    {

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {

            Destroy(gameObject);

        }
    }

}
