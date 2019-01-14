using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    [SerializeField] float LevelLoadDelay = 5f;
    [SerializeField] float LevelExitSlowMoFactor = 0.2f;
    [SerializeField] GameObject blockSparklesVFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
        TriggerSparklesVFX();
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

       
    }

    private void TriggerSparklesVFX()
    {
        {
            GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);

            Destroy(sparkles, 4f);
        }
    }
}