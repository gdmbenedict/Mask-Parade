using UnityEngine;

public class Person : MonoBehaviour
{
    [Header("Checked Attributes")]
    public MaskShape maskShape;

    [Header("Cosmetic Attributes")]
    public SkinColor skinColor;
    public HairColor hairColor;

    public enum MaskShape
    {
        horns,
        teeth,
        ears,
        beak
    }

    public enum ClothesColor
    {
        black,
        white,
        yellow,
        red,
        blue
    }

    public enum HairStyle
    {
        updoo,
        shortHair,
        longHair
    }

    public enum Height
    {
        small,
        medium,
        tall
    }

    public enum Weight
    {
        thin,
        medium,
        large
    }


    public enum Handedness
    {
        left,
        right
    }

    public enum Sex
    {
        male,
        female
    }

    public enum SkinColor
    {

    }

    public enum HairColor
    {
        red,
        blonde,
        black,
        brown
    }
}

