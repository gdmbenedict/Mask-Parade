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
    #endregion
    #region SFX Control
    public void PlaySFX(int sfxNum)
    {
        sfxSource.PlayOneShot(sfxList[sfxNum]);
    }
    #endregion
    #region Music Control
    public void PlayMusic(int musicNum)
    {
        musicSource.clip = musicList[musicNum];
        musicSource.loop = true;
        musicSource.Play();
    }
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

    public float GetStartingVol(string group)
    {
        float value = 0;
        switch(group)
        {
            case "Master":
                value = volume.MasterVol;
                break;
            case "Music":
                value = volume.MusicVol;
                break;
            case "SFX":
                value = volume.SFXVol;
                break;
        }
        return value;
    }
    public void UpdateVoluem(float value, string group)
    {
        volume.UpdateVoluem(value,group);
    }
    #endregion
}
