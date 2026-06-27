using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }//Easy access to AudioManager

    public AudioMixer audioMixer;//The Audio Mixer asset

    public AudioSource musicSource;//AudioSource for background music

    public AudioSource sfxSource;//AudioSource for sound effects

    public AudioClip buttonClickSound;//Sound for button clicks

    public AudioClip jumpSound;//Sound for player jump

    public AudioClip hurtSound;//Sound for player taking damage

    public AudioClip collectSound;//Sound for collecting items

    public AudioClip checkpointSound;//Sound for checkpoint activation

    public AudioClip victorySound;//Sound for victory screen

    public AudioClip gameOverSound;//Sound for game over screen

    private void Awake()//Runs before Start
    {
        if (Instance == null)//If there is no AudioManager yet
        {
            Instance = this;//This object becomes the AudioManager
        }
        else
        {
            Destroy(gameObject);//Destroy duplicate AudioManager
        }
    }

    public void SetMasterVolume(float volume)//Changes master volume
    {
        audioMixer.SetFloat("MasterVolume", ConvertToDecibel(volume));//Set master volume
    }

    public void SetMusicVolume(float volume)//Changes music volume
    {
        audioMixer.SetFloat("MusicVolume", ConvertToDecibel(volume));//Set music volume
    }

    public void SetSFXVolume(float volume)//Changes SFX volume
    {
        audioMixer.SetFloat("SFXVolume", ConvertToDecibel(volume));//Set SFX volume
    }

    private float ConvertToDecibel(float volume)//Converts slider value to decibels
    {
        if (volume <= 0.0001f)//If slider is at or near zero
        {
            return -80f;//Make audio silent
        }

        return Mathf.Log10(volume) * 20f;//Convert slider value to decibels
    }

    public void PlaySFX(AudioClip clip)//Plays a sound effect
    {
        if (clip == null)//Checks if clip is missing
        {
            return;//Stops code
        }

        if (sfxSource == null)//Checks if SFX source is missing
        {
            return;//Stops code
        }

        sfxSource.PlayOneShot(clip);//Plays sound one time
    }

    public void PlayButtonClick()//Plays button click sound
    {
        PlaySFX(buttonClickSound);//Plays button click clip
    }

    public void PlayJump()//Plays jump sound
    {
        PlaySFX(jumpSound);//Plays jump clip
    }

    public void PlayHurt()//Plays hurt sound
    {
        PlaySFX(hurtSound);//Plays hurt clip
    }

    public void PlayCollect()//Plays collect sound
    {
        PlaySFX(collectSound);//Plays collect clip
    }

    public void PlayCheckpoint()//Plays checkpoint sound
    {
        PlaySFX(checkpointSound);//Plays checkpoint clip
    }

    public void PlayVictory()//Plays victory sound
    {
        PlaySFX(victorySound);//Plays victory clip
    }

    public void PlayGameOver()//Plays game over sound
    {
        PlaySFX(gameOverSound);//Plays game over clip
    }
}
