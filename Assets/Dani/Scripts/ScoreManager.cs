using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text scoreUI;
    public Text gameOverText;
    public int amountOfTrash;

    [HideInInspector]
    public int score;

    [HideInInspector]
    public bool victory = false;

    //[HideInInspector]
    public int cleanedTrash = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(cleanedTrash == amountOfTrash)
        {
            victory = true;
        }

        scoreUI.text = score.ToString();
	}
}
