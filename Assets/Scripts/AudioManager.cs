using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    [Header("Manager Referances")]
    public SystemManager systemManager;
    public Volume volume;
    [Header("Mixer")]
    public AudioMixer mixer;
    [Header("Music")]
    public AudioSource musicSource;
    public List<AudioClip> musicList;
    [Header("SFX")]
    public AudioSource sfxSource;
    public List<AudioClip> sfxList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    #region Unity Core
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    #region SFX Control
    #endregion
    #region Music Control
    #endregion
    #region Volume Control
    /// <summary>
    /// Changes volume based on exposed group, and input value
    /// </summary>
    /// <param name="group"></param>
    /// <param name="value"></param>
    public void ChangeVolume(string group, float value)
    {
        mixer.SetFloat(group,value);
    }

    public void UpdateVoluem(float value, string group)
    {
        volume.UpdateVoluem(value,group);
    }
    #endregion
}
