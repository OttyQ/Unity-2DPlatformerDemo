using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum SoundType
{
    Attack,
    SpecialAttack,
    Alt_Attack,
    Dash,
    Run,
    Jump,
    Land,
    Hurt,
    Die
}

[ExecuteInEditMode]
public class SFX_Hero : MonoBehaviour
{


    [Header("Audio Clip")]

    [SerializeField] private SoundLits[] soundList;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlaySound(SoundType soundType)
    {
        SoundLits soundLits = Array.Find(soundList, s => s.name == soundType.ToString());
        if (soundLits.Sounds != null && soundLits.Sounds.Length > 0)
        {
            AudioClip clipToPlay = soundLits.Sounds[UnityEngine.Random.Range(0, soundLits.Sounds.Length)];
            audioManager.PlaySFX(clipToPlay);
        }
        else
        {
            Debug.LogWarning($"No audio clips found for SoundType: {soundType}");
        }
    }

    public void Hero_jump_start()
    {
        PlaySound(SoundType.Jump);
    }
    public void Hero_jump_end()
    {
        PlaySound(SoundType.Land);
    }
    public void Hero_walk()
    {
        PlaySound(SoundType.Run);
    }
    public void Hero_attack()
    {
        PlaySound(SoundType.Attack);
    }

    public void Hero_throw_knife()
    {
        PlaySound(SoundType.SpecialAttack);
    }

    public void Hero_hurt()
    {
        PlaySound(SoundType.Hurt);
    }

    public void Hero_die()
    {
        PlaySound(SoundType.Die);
    }
    public void Hero_dash()
    {
        PlaySound(SoundType.Dash);
    }
    public void Hero_hit()
    {
        //audioManager.PlaySFX(hero_hit);
    }

    public void Hero_revive()
    {
        //do
        //audioManager.PlaySFX(hero_revive);
    }

    
#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);
        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
#endif

}

[Serializable]
public struct SoundLits
{
    public AudioClip[] Sounds { get => sounds; }
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}
