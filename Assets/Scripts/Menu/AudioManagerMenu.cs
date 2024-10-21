using UnityEngine;

public class AudioManagerMenu : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicBackSource;
    [SerializeField] AudioSource sfxMMSource;

    [Header("Audio Clip")]
    public AudioClip backgroundMM;
    public AudioClip buttonSelect;
    public AudioClip buttonPress;
    public AudioClip playPress;


    private void Start()
    {
        musicBackSource.clip = backgroundMM;
        musicBackSource.Play();

    }
    public void PlaySFX(AudioClip clip)
    {
        sfxMMSource.PlayOneShot(clip);
    }
}
