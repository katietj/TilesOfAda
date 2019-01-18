using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainThemePlayer : MonoBehaviour {

    AudioSource audioSource; 


	void Awake () {
        SetUpSingleton();

	}



    private void SetUpSingleton()
    {
        if(FindObjectsOfType<MainThemePlayer>().Length > 1 )
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = PlayerPrefsController.GetMasterVolume();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume; 
    }

    // Update is called once per frame
     void Update()
    {
       
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 4 || currentSceneIndex == 5)
        {
            Debug.Log("i am here");
            Destroy(gameObject);

        }
    }
}
