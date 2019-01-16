using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 

public class GameSession : MonoBehaviour {


    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float LevelLoadDelay = 1f;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
           
        }
    }




    public void AddToScore( int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    // Use this for initialization
    void Start () {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();

	}
	
	public void ProcessPlayerDeath()
    {
        if( playerLives > 1)
        {
            TakeLife();
        }

        else
        {
            ResetGameSession(); 

        }
    }

    private void TakeLife()
    {
        playerLives--;
        StartCoroutine(LoadLevel());
        livesText.text = playerLives.ToString();

    }


    IEnumerator LoadLevel()
    {

        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }



    private void Update()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 4)
        {
            Destroy(gameObject);
        }
    }



    private void ResetGameSession()
    {
      
        SceneManager.LoadScene(5); 
        Destroy(gameObject);
    }






}
