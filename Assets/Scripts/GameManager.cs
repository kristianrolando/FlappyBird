using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;
    public static event GameDelegate OnGamePause;
    public static event GameDelegate OnGameResume;

    public GameObject startPage;
	public GameObject gameOverPage;
    public GameObject countDownPage;

    [HideInInspector] public float speedPipe;
    [HideInInspector] public float spawnTime;
    [HideInInspector] public int pipeType;

    [SerializeField] ScoreManager scoreManager;
    [SerializeField] DiffiCult[] difficult;
    int index;

    enum PageState
    {
        None,
        Start,
        GameOver,
        Countdown
    }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        SetPageState(PageState.Countdown);
    }
    private void OnEnable()
    {
        TapController.OnPlayerDied += OnPlayerDied;
        CountDown.OnCountdownFinished += OnCountdownFinished;
    }
    private void OnDisable()
    {
        TapController.OnPlayerDied -= OnPlayerDied;
        CountDown.OnCountdownFinished -= OnCountdownFinished;
    }
    void OnPlayerDied()
    {
        Time.timeScale = 0;
        SetPageState(PageState.GameOver);
        OnGameOverConfirmed?.Invoke();
    }
    void OnCountdownFinished()
    {
        SetPageState(PageState.Start);
        OnGameStarted?.Invoke();
    }

    void SetPageState(PageState state)
    {

        switch (state)
        {

            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countDownPage.SetActive(false);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                countDownPage.SetActive(false);
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                countDownPage.SetActive(false);
                break;
            case PageState.Countdown:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countDownPage.SetActive(true);
                break;

        }
    }
    private void Update()
    {
        SetDifficulty();
    }
    void SetDifficulty()
    {
        if(scoreManager.score >= difficult[index].score)
        {
            var d = difficult[index];
            speedPipe = d.speedPipe;
            spawnTime = d.spawnTime;
            pipeType = d._pipeType;

            if(index < difficult.Length-1)
                index++;
        }
    }
    public void GamePause()
    {
        Time.timeScale = 0f;
        OnGamePause();
    }
    public void GameResume()
    {
        Time.timeScale = 1f;
        OnGameResume();
    }
}
[System.Serializable]
public struct DiffiCult
{
    public int score;
    public float speedPipe;
    public float spawnTime;
    public int _pipeType;
}
