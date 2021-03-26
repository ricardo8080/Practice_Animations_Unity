using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public AudioSource audioSource;

    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }
    public void QuitGame() 
    {
        Application.Quit();
    }
    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("Volume", volume);
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("volumen",volume);
    }

}
