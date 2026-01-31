using UnityEngine;
using System.Collections.Generic;
using System;

public class Guest 
{
    [Header("Checked Attributes")]
    public MaskShape maskShape;
    public ClothesColor maskColor;
    public ClothesType clothesType;
    public ClothesColor clothesColor;
    public HairStyle hairStyle;
    public Handedness handedness;
    public Height guestHeight;
    public Weight guestWeight;

    [Header("Cosmetic Attributes")]
    public SkinColor skinColor;
    public HairColor hairColor;

    public void GenerateGuest()
    {
        maskShape = GetRandomEnumValue<MaskShape>();
        maskColor = GetRandomEnumValue<ClothesColor>();
        clothesType = GetRandomEnumValue<ClothesType>();
        clothesColor = GetRandomEnumValue<ClothesColor>();
        hairStyle = GetRandomEnumValue<HairStyle>();
        handedness = GetRandomEnumValue<Handedness>();
        guestHeight = GetRandomEnumValue<Height>();
        guestWeight = GetRandomEnumValue<Weight>();
        skinColor = GetRandomEnumValue<SkinColor>();
        hairColor = GetRandomEnumValue<HairColor>();
    }

    private T GetRandomEnumValue<T>() where T: struct, Enum
    {
        // Get all defined values for the enum type
        Array values = Enum.GetValues(typeof(T));

        // Select a random index
        int randomIndex = UnityEngine.Random.Range(0, values.Length);

        // Return the value at that index, cast back to the enum type
        return (T)values.GetValue(randomIndex);
    }

    [System.Serializable]
    public enum MaskShape
    {
        horns,
        teeth,
        ears,
        beak
    }

    [System.Serializable]
    public enum ClothesColor
    {
        black,
        white,
        yellow,
        red,
        blue
    }

    [System.Serializable]
    public enum HairStyle
    {
        updoo,
        shortHair,
        longHair
    }

    [System.Serializable]
    public enum Height
    {
        small,
        medium,
        tall
    }

    [System.Serializable]
    public enum Weight
    {
        thin,
        medium,
        large
    }

    [System.Serializable]
    public enum Handedness
    {
        left,
        right
    }

    [System.Serializable]
    public enum ClothesType
    {
        suit,
        dress
    }

    [System.Serializable]
    public enum SkinColor
    {
        pale,
        olive,
        lightBrown,
        brown,
        blackBrown
    }

    [System.Serializable]
    public enum HairColor
    {
        red,
        blonde,
        black,
        brown
    }
}

