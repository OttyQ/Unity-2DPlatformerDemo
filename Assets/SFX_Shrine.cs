using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Shrine : MonoBehaviour
{
    [Header("Audio Clip")]
    public AudioClip shrine_activation;
    public AudioClip shrine_activation_alt;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Shrine_Activate()
    {
        audioManager.PlaySFX(shrine_activation);
    }
    public void Shrine_Activate_alt()
    {
        audioManager.PlaySFX(shrine_activation_alt);
    }
}
