using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public Text gameOverText;
    public Text scoreText;
    public ScoreManager scoreManager;
    public TimerBehaviour timer;


    Scene curScene;

    private void Start()
    {
        curScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (timer.gameOver)
        {
            scoreText.text = "Score: " + scoreManager.score;

            gameOverText.text = "GAME OVER!";
        }

    }


    public void RestartScene()
    {
        SceneManager.LoadScene(curScene.buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
