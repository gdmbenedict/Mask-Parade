using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioManager audioManager;
    public UIManager uIManager;
    public string group;
    public Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(audioManager == null)
        {
            audioManager = GameObject.FindFirstObjectByType<AudioManager>();
        }
        if(uIManager == null)
        {
            uIManager = GameObject.FindFirstObjectByType<UIManager>();
        }
        if(slider == null)
        {
            slider = this.GetComponent<Slider>();
        }

        if(group == "MasterVol")
        {
            uIManager.masterVolSlider = slider;
        }
        if(group == "MusicVol")
        {
            uIManager.musicVolSlider = slider;
        }
        if(group == "SFXVol")
        {
            uIManager.sFXVolSlider = slider;
        }
    }

    /// <summary>
    /// Used by slider to pass value to audio manager
    /// </summary>
    public void SliderVolume()
    {
        audioManager.ChangeVolume(group,slider.value);
    }
}
