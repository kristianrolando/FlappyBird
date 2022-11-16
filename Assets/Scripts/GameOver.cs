using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField] Button startButton;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] GameObject _goldMedal, _silverMedal;
    [SerializeField] int scoreGold, scoreSilver;

    private void Awake()
    {
        startButton.onClick.RemoveAllListeners();
        startButton.onClick.AddListener(StartButton);
    }
    private void OnDestroy()
    {
        startButton.onClick.RemoveAllListeners();
    }
    private void OnEnable()
    {
        _silverMedal.SetActive(false);
        _goldMedal.SetActive(false);
        if (scoreSilver <= scoreManager.score)
        {
            _silverMedal.SetActive(true);
            _goldMedal.SetActive(false);
        }
        if (scoreGold <= scoreManager.score)
        {
            _silverMedal.SetActive(false);
            _goldMedal.SetActive(true);
        }
        scoreText.text = scoreManager.score.ToString();
        bestScoreText.text = scoreManager.bestScore.ToString();
    }

    void StartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
