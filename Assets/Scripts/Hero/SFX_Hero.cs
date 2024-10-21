using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SFX_Hero : MonoBehaviour
{
    [Header("Audio Clip")]
    public AudioClip hero_jump_start;
    public AudioClip hero_jump_end;
    public AudioClip hero_walk;
    public AudioClip hero_attack_1;
    public AudioClip hero_attack_2;
    public AudioClip hero_throw_knife;
    public AudioClip hero_hurt;
    public AudioClip hero_die;
    public AudioClip hero_dash;
    public AudioClip hero_hit;
    public AudioClip hero_revive;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Hero_jump_start()
    {
        audioManager.PlaySFX(hero_jump_start);
    }
    public void Hero_jump_end()
    {
        audioManager.PlaySFX(hero_jump_end);
    }
    public void Hero_walk()
    {
        audioManager.PlaySFX(hero_walk);
    }
    public void Hero_attack()
    {
        int randomClip = Random.Range(1, 3);

        string audioName = "hero_attack_" + randomClip.ToString();
        AudioClip clip = (AudioClip)typeof(SFX_Hero).GetField(audioName).GetValue(this);
        audioManager.PlaySFX(clip);
    }

    public void Hero_throw_knife()
    {
        audioManager.PlaySFX(hero_throw_knife);
    }

    public void Hero_hurt()
    {
        audioManager.PlaySFX(hero_hurt);
    }

    public void Hero_die()
    {
        audioManager.PlaySFX(hero_die);
    }
    public void Hero_dash()
    {
        audioManager.PlaySFX(hero_dash);
    }
    public void Hero_hit()
    {
        audioManager.PlaySFX(hero_hit);
    }

    public void Hero_revive()
    {
        //do
        audioManager.PlaySFX(hero_revive);
    }


}
