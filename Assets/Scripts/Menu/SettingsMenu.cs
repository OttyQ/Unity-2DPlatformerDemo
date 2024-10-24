using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMix;

    private const float minVolumeDB = -80f;
    private const float maxVolumeDB = 0f;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

     
    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("sfxVolume"))
        {
            Debug.Log("PlayerPrefs!!!!!!!!!");
            LoadVolume();
        }
        else
        {
            Debug.Log("No PlayerPrefs:(");
            SetMusic();
            SetSFX();
        }
             
        
    }

    public void SetMusic()
    {
        // invert slider values from 0-10 to min - max
        Debug.Log("SetMusic!");
        float volume = musicSlider.value;
        float dB = Mathf.Lerp(minVolumeDB, maxVolumeDB, volume/10f);
        audioMix.SetFloat("music", dB);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFX()
    {
        float sfx = sfxSlider.value;
        Debug.Log("SetSFX!");
        // invert slider values from 0-10 to min - max
        float dBsfx = Mathf.Lerp(minVolumeDB, maxVolumeDB, sfx/10f);
        audioMix.SetFloat("sfx", dBsfx);
        PlayerPrefs.SetFloat("sfxVolume", sfx);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetMusic();
        SetSFX();
    }
}