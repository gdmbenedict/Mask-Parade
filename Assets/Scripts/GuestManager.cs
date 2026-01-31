using UnityEngine;
using UnityEngine.U2D.Animation;

public class GuestManager : MonoBehaviour
{
    private Guest guest = new Guest();

    [Header("Sprite Resolvers")]
    [SerializeField] private SpriteResolver bodyResolver;
    [SerializeField] private SpriteResolver maskResolver;
    [SerializeField] private SpriteResolver hairResolver;
    [SerializeField] private SpriteResolver armResolver;
    [SerializeField] private SpriteResolver clothesResolver;

    [Header("Sprite Renderers")]
    [SerializeField] private SpriteRenderer bodyRenderer;
    [SerializeField] private SpriteRenderer maskRenderer;
    [SerializeField] private SpriteRenderer hairRenderer;
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private SpriteRenderer clothesRenderer;

    [Header("Colors")]
    [SerializeField] private GuestColours clothesColors;
    [SerializeField] private GuestColours hairColors;
    [SerializeField] private GuestColours skinColors;

    private string bodyCategory = "Body";
    private string maskCategory = "mask";
    private string hairCategory = "hair";
    private string armCategory = "arm";
    private string clothesCategory = "clothes";

    private void SetGuestVisuals()
    {
        SetSprites();
        SetColors();
    }

    private void SetSprites()
    {

    }

    private void SetColors()
    {
        SetClothesColor();
        SetSkinColor();
        SetHairColor();
    }

    private void SetClothesColor()
    {
        clothesRenderer.color = clothesColors.GetColor(GetClothesColorName(guest.clothesColor));
        maskRenderer.color = clothesColors.GetColor(GetClothesColorName(guest.maskColor));
    }

    private string GetClothesColorName(Guest.ClothesColor color)
    {
        string colorName;
        switch (color)
        {
            case Guest.ClothesColor.white:
                colorName = "white";
                break;

            case Guest.ClothesColor.black:
                colorName = "black";
                break;

            case Guest.ClothesColor.red:
                colorName = "red";
                break;

            case Guest.ClothesColor.blue:
                colorName = "blue";
                break;

            case Guest.ClothesColor.yellow:
                colorName = "yellow";
                break;

            default:
                colorName = "white";
                break;
        }

        return colorName;
    }

    private string GetClothesColorName(Guest.MaskColor color)
    {
        string colorName;
        switch (color)
        {
            case Guest.MaskColor.white:
                colorName = "white";
                break;

            case Guest.MaskColor.black:
                colorName = "black";
                break;

            case Guest.MaskColor.red:
                colorName = "red";
                break;

            case Guest.MaskColor.blue:
                colorName = "blue";
                break;

            case Guest.MaskColor.yellow:
                colorName = "yellow";
                break;

            default:
                colorName = "white";
                break;
        }

        return colorName;
    }

    private void SetSkinColor()
    {
        string colorName;
        switch (guest.skinColor)
        {
            case Guest.SkinColor.pale:
                colorName = "pale";
                break;

            case Guest.SkinColor.olive:
                colorName = "olive";
                break;

            case Guest.SkinColor.lightBrown:
                colorName = "light brown";
                break;

            case Guest.SkinColor.brown:
                colorName = "brown";
                break;

            case Guest.SkinColor.blackBrown:
                colorName = "black brown";
                break;

            default:
                colorName = "pale";
                break;
        }

        bodyRenderer.color = skinColors.GetColor(colorName);
    }

    private void SetHairColor()
    {
        string colorName;
        switch (guest.hairColor)
        {
            case Guest.HairColor.white:
                colorName = "white";
                break;

            case Guest.HairColor.black:
                colorName = "black";
                break;

            case Guest.HairColor.brown:
                colorName = "brown";
                break;

            case Guest.HairColor.red:
                colorName = "red";
                break;

            case Guest.HairColor.blonde:
                colorName = "blonde";
                break;

            default:
                colorName = "white";
                break;
        }

        hairRenderer.color = hairColors.GetColor(colorName);
    }
}
