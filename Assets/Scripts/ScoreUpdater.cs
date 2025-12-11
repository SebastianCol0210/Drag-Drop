using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    private TMP_Text scoreText;

    public GameObject draggerScore;

    public int score;

    private void Start()
    {
        score = 0;
        scoreText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if(score < 0)
        {
            score = 0;
        }
        scoreText.text = "Puntaje: " + score.ToString();
    }

}
