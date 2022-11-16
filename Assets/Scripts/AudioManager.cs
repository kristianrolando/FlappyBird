using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource die;
    [SerializeField] AudioSource score;
    [SerializeField] AudioSource swing;

    private void OnEnable()
    {
        TapController.OnPlayerDied += DieSound;
        TapController.OnPlayerScored += ScoreSound;
        TapController.OnPlayerSwing += SwingSound;
    }
    private void OnDisable()
    {
        TapController.OnPlayerDied += DieSound;
        TapController.OnPlayerScored += ScoreSound;
        TapController.OnPlayerSwing += SwingSound;
    }
    void DieSound()
    {
        die.Play();
    }
    void ScoreSound()
    {
        score.Play();
    }
    void SwingSound()
    {
        swing.Play();
    }
}
