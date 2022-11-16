using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;
    public static event PlayerDelegate OnPlayerScored;
    public static event PlayerDelegate OnPlayerSwing;

    [SerializeField] private float tapForce = 10f;
    [SerializeField] private float tiltSmooth = 5f;
    [SerializeField] AudioManager2 _audio;

    Rigidbody2D rb;
    Quaternion downrotation;
    Quaternion forwardrotation;
    bool isReady;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        downrotation = Quaternion.Euler(0, 0, -90);
        forwardrotation = Quaternion.Euler(0, 0, 35);
        rb.simulated = false;
    }
    private void Update()
    {
        if(isReady)
            TapInput();
    }

    void TapInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _audio.SwingSound();
            OnPlayerSwing?.Invoke();
            rb.simulated = true;
            transform.rotation = forwardrotation;
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }
        if(rb.simulated)
            transform.rotation = Quaternion.Lerp(transform.rotation, downrotation, tiltSmooth * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            _audio.DieSound();
            OnPlayerDied();
        }
        if(collision.CompareTag("Score"))
        {
            _audio.ScoreSound();
            OnPlayerScored();
        }
    }
    private void OnEnable()
    {
        GameManager.OnGameStarted += () => { isReady = true; };
        GameManager.OnGameOverConfirmed += () => { isReady = false; };
        GameManager.OnGamePause += () => { isReady = false; };
        GameManager.OnGameResume += () => { isReady = true; };

    }
    private void OnDisable()
    {
        GameManager.OnGameStarted -= () => { isReady = true; };
        GameManager.OnGameOverConfirmed -= () => { isReady = false; };
        GameManager.OnGamePause -= () => { isReady = false; };
        GameManager.OnGameResume -= () => { isReady = true; };
    }
}
