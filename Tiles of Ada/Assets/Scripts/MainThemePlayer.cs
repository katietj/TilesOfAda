using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainThemePlayer : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        SetUpSingleton();
	}

    private void SetUpSingleton()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 4 || currentSceneIndex == 5)
        {
            Destroy(gameObject);
        }
    }
}
