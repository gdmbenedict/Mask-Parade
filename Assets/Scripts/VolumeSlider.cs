using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioManager audioManager;
    public string group;
    public Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(audioManager == null)
        {
            audioManager = GameObject.FindAnyObjectByType<AudioManager>();
        }
        if(slider == null)
        {
            slider = this.GetComponent<Slider>();
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
