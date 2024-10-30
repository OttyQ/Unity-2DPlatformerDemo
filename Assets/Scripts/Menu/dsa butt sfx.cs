using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dsa_butt_sfx: MonoBehaviour
{
    [Header("Audio Clip")]
    public AudioClip button_fall;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void button_falling()
    {
        audioManager.PlaySFX(button_fall);
    }
}
