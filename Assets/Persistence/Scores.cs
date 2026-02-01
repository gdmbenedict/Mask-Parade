using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(fileName = "Scores", menuName = "Scriptable Objects/Scores")]
public class Scores : ScriptableObject
{
    public List<float> scores;

    public void CheckHighSocres(float newScore)
    {
        for(int i =0; i < scores.Count; i++)
        {
            if(newScore > scores[i])
            {
                scores[i] = newScore;
                break;
            }
        }
    }
}
