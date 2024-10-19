using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Ememy : MonoBehaviour
{
    [Header("Audio Clip")]
    public AudioClip goblin_walk;
    public AudioClip goblin_attack;
    public AudioClip goblin_hurt;
    public AudioClip goblin_die;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Goblin_walk()
    {
        audioManager.PlaySFX(goblin_walk);
    }
    public void Goblin_attack()
    {
       
        audioManager.PlaySFX(goblin_attack);
    }
    public void Goblin_hurt()
    {
        audioManager.PlaySFX(goblin_hurt);
    }

    public void Goblin_die()
    {
        audioManager.PlaySFX(goblin_die);
    }
 
}
