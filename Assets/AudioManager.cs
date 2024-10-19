using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip background;


    [SerializeField] PauseMenu pauseMenu;




    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        
    }

    private void Update()
    {
        if (pauseMenu.isPause)
        {
            musicSource.pitch = 0.85f;
        }
        else
        {
            musicSource.pitch = 1f;
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
        
    }
}