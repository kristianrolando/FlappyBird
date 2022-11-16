using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager2 : MonoBehaviour
{
    [SerializeField] AudioSource die;
    [SerializeField] AudioSource score;
    [SerializeField] AudioSource swing;

    public void DieSound()
    {
        die.Play();
    }
    public void ScoreSound()
    {
        score.Play();
    }
    public void SwingSound()
    {
        swing.Play();
    }
}
