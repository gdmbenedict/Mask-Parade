using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GuestColours", menuName = "Scriptable Objects/GuestColours")]
public class GuestColours : ScriptableObject
{
    [SerializeField] private List<Color> colors;
    [SerializeField] private List<string> colorNames;

    public Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Count)];
    }

    public Color GetColor(string colorName)
    {
        int index = colorNames.IndexOf(colorName.ToLower());
        return colors[index];
    }
}
