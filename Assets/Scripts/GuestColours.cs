using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GuestColours", menuName = "Scriptable Objects/GuestColours")]
public class GuestColours : ScriptableObject
{
    [SerializeField] private List<Color> colors;
    
    public Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Count)];
    }
}
