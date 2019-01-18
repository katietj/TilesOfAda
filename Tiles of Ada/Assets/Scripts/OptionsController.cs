using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class OptionsController : MonoBehaviour {

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f; 
	// Use this for initialization
	void Start () {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
        var mainPlayer = FindObjectOfType<MainThemePlayer>();
        var winPlayer = FindObjectOfType<WinThemePlayer>();
        var losePlayer = FindObjectOfType<LoseThemePlayer>();

       
            mainPlayer.SetVolume(volumeSlider.value);
            winPlayer.SetVolume(volumeSlider.value);
            losePlayer.SetVolume(volumeSlider.value);


    }
    
    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<Menu>().StartScreen();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
    }
}
