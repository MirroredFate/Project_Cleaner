using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehaviour : MonoBehaviour {

    public Text timerText;
    public GameObject gameOverScreen;
    public int startTime = 60;

    private string timeText;
    private float time;
    private float intTime;
    private bool gameOver = false;

	// Use this for initialization
	void Start () {
        time = startTime;
        intTime = startTime;
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
        {
            time -= Time.deltaTime;
            intTime -= Time.deltaTime;
        }
        if(intTime >= 10)
        {
            timeText = "" + (int)intTime;
        }
        if(intTime < 10)
        {
            timeText = time.ToString();
        }


        if (time <= 0)
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

        timerText.text = timeText;
    }
}
