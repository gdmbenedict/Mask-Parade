using System.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "Volume", menuName = "Scriptable Objects/Volume")]
public class Volume : ScriptableObject
{
    [Range(-50,0)]
    public float MasterVol;
    [Range(-50,0)]
    public float MusicVol;
    [Range(-50,0)]
    public float SFXVol;
    public void UpdateVoluem(float value, string group)
    {
        switch (group)
        {
            case "MasterVol":
                MasterVol = value;
                break;
            case "MusicVol":
                MusicVol = value;
                break;
            case "SFXVol":
                SFXVol = value;
                break;
        }
    }
}
