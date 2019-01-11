using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {


    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    public GameObject heart1, heart2, heart3;

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
        HeartCount();
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
        HeartCount();
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();

    }

    public void HeartCount()
    {
        if (playerLives > 3)
            playerLives = 3;

        switch (playerLives)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;

            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;

            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;

            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;

        }
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(5); // change this to go to loooser page
        Destroy(gameObject);
    }
}
