using UnityEngine;

public class Guest 
{
    [Header("Checked Attributes")]
    public MaskShape maskShape;
    public ClothesColor maskColor;
    public ClothesType clothesType;
    public ClothesColor clothesColor;
    public Handedness handedness;
    public Height guestHeight;
    public Weight guestWeight;


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

    public enum ClothesType
    {
        suit,
        dress
    }

    public enum SkinColor
    {
        pale,
        olive,
        lightBrown,
        brown,
        blackBrown
    }

    public enum HairColor
    {
        red,
        blonde,
        black,
        brown
    }
}

