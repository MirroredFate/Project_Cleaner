using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehaviour : MonoBehaviour {

    public Text timerText;
    public GameObject gameOverScreen;
    public int startTime = 60;

    private float time;
    private bool gameOver = false;

	// Use this for initialization
	void Start () {
        time = startTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
        {
            time -= Time.deltaTime;
        }

        timerText.text = time.ToString();

        if(time <= 0)
        {
            time = 0.0f;
            gameOver = true;
        }

        if (gameOver)
        {
            gameOverScreen.SetActive(true);
        }
        else
        {
            gameOverScreen.SetActive(false);
        }
	}
}
