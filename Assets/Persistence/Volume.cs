using System.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "Volume", menuName = "Scriptable Objects/Volume")]
public class Volume : ScriptableObject
{
    [Range(-60,10)]
    public float MasterVol;
    [Range(-60,10)]
    public float MusicVol;
    [Range(-60,10)]
    public float SFXVol;
    public void UpdateVoluem(float value, string group)
    {
        switch (group)
        {
            case "Master":
                MasterVol = value;
                break;
            case "Music":
                MusicVol = value;
                break;
            case "SFX":
                SFXVol = value;
                break;
        }
    }
}
