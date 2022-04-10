﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;

    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;


    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + "POINTS";
        highscoreText.text = "HIGHSCORE:" + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Addpoint()
    {
        score += 1;
        scoreText.text = score.ToString() + "POINTS";

        if(highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}