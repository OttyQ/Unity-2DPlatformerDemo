using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Shrine : MonoBehaviour
{
    [Header("Audio Clip")]
    public AudioClip shrine_activation;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Shrine_Activate()
    {
        audioManager.PlaySFX(shrine_activation);
    }
}
