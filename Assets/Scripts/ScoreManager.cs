using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    [HideInInspector] public int score;
    [HideInInspector] public int bestScore;

    private void Start()
    {
        scoreText.text = score.ToString();
        bestScore = PlayerPrefs.GetInt("Best Score");
    }
    void AddScore()
    {
        bestScore = PlayerPrefs.GetInt("Best Score");
        score++;
        if (bestScore < score)
        {
            bestScore = score;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
        scoreText.text = score.ToString();
    }
    private void OnEnable()
    {
        TapController.OnPlayerScored += AddScore;
    }
    private void OnDisable()
    {
        TapController.OnPlayerScored -= AddScore;
    }
}
