using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Boss : MonoBehaviour
{
    [Header("Audio Clip")]
    public AudioClip boss_walk;
    public AudioClip boss_attack;
    public AudioClip boss_special_attack;
    public AudioClip boss_hurt_1;
    public AudioClip boss_hurt_2;
    public AudioClip boss_charge;
    public AudioClip boss_die;


    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Boss_walk()
    {
        audioManager.PlaySFX(boss_walk);
    }
    public void Boss_attack()
    {

        audioManager.PlaySFX(boss_attack);
    }
    public void Boss_special_attack()
    {
        audioManager.PlaySFX(boss_special_attack);
    }
    public void Boss_hurt()
    {
        int randomClip = Random.Range(1, 3);

        string audioName = "boss_hurt_" + randomClip.ToString();
        AudioClip clip = (AudioClip)typeof(SFX_Boss).GetField(audioName).GetValue(this);

        audioManager.PlaySFX(clip);

    }

    public void Boss_die()
    {
        audioManager.PlaySFX(boss_die);
    }

    public void Boss_charge()
    {
        audioManager.PlaySFX(boss_charge);
    }
}
