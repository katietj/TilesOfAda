using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {



    public void VeryBegining()
    {
        var oldGame = FindObjectOfType<GameSession>();
        Destroy(oldGame);
        SceneManager.LoadScene(0);

        
       

    }

    public void StartScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void StartFirstScene()
    {
        SceneManager.LoadScene(2);
    }

    public void Options()
    {
        SceneManager.LoadScene(6);
    }
}
