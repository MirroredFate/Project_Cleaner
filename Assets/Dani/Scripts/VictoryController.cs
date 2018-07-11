using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryController : MonoBehaviour {

    public Text victoryText;
    public Text scoreText;

    public ScoreManager scoreManager;
    public TimerBehaviour timer;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (scoreManager.victory)
        {
            victoryText.text = "YOU WON!";
            scoreText.text = "It took you:\n" + Mathf.Round(timer.timeTaken) + " Seconds!\nYour Score: " + scoreManager.score;
        }


	}
}
