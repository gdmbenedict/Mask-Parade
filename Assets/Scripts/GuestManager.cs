using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class GuestManager : MonoBehaviour
{
    public Guest guest = new Guest();

    [Header("Guest Visual")]
    [SerializeField] private Transform guestVisual;
    [SerializeField] private CanvasGroup canvasGroup;
    private float startPos;
    private float heightStep = 100;

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

    private float fadeTime = 0.30f;

    private void Start()
    {
        startPos = guestVisual.localPosition.y;
    }

    public void GenerateNewGuest()
    {
        StartCoroutine(GenerateGuest(true));
    }

    public void GenerateFirstGuest()
    {
        StartCoroutine(GenerateGuest(false));
    }

    private IEnumerator GenerateGuest(bool fadeOut)
    {
        float fadeTimer;

        //fade out
        if (fadeOut)
        {
            fadeTimer = fadeTime;

            while (fadeTimer > 0)
            {
                yield return null;
                fadeTimer -= Time.deltaTime;
                SetVisualAlpha(fadeTimer / fadeTime);
            }
        }

        guest.GenerateGuest();
        SetGuestVisuals();

        //sfx
        SystemManager.systemManager.audioManager.PlaySFX(5);

        //fade in
        fadeTimer = 0;

        while (fadeTimer < fadeTime)
        {
            yield return null;
            fadeTimer += Time.deltaTime;
            SetVisualAlpha( fadeTimer / fadeTime );
        }

        SetVisualAlpha(1);

    }

    private void SetVisualAlpha(float alpha)
    {
        bodyRenderer.color = new Color(bodyRenderer.color.r, bodyRenderer.color.g, bodyRenderer.color.b, alpha);
        maskRenderer.color = new Color(maskRenderer.color.r, maskRenderer.color.g, maskRenderer.color.b, alpha);
        hairRenderer.color = new Color(hairRenderer.color.r, hairRenderer.color.g, hairRenderer.color.b, alpha);
        armRenderer.color = new Color(armRenderer.color.r, armRenderer.color.g, armRenderer.color.b, alpha);
        clothesRenderer.color = new Color(clothesRenderer.color.r, clothesRenderer.color.g, clothesRenderer.color.b, alpha);
    }

    private void SetGuestVisuals()
    {
        SetSprites();
        SetColors();
        SetHeight();
        SetHandedness();
    }

    private void SetHandedness()
    {
        if (guest.handedness == Guest.Handedness.right)
        {
            guestVisual.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            guestVisual.localScale = new Vector3(1, 1, 1);
        }
    }

    private void SetHeight()
    {
        float mult;

        switch (guest.guestHeight)
        {
            case Guest.Height.tall:
                mult = 0;
                break;

            case Guest.Height.medium:
                mult = 1;
                break;

            case Guest.Height.small:
                mult = 2;
                break;

            default:
                mult = 0;
                break;
        }

        float newPos = startPos - (heightStep * mult);
        guestVisual.localPosition = new Vector3(guestVisual.localPosition.x, newPos, guestVisual.localPosition.z);
    }

    private void SetSprites()
    {
        SetBodySprite();
        SetClothesSprite();
        SetArmSprite();
        SetHairSprite();
        SetMaskSprite();
    }

    private void SetBodySprite()
    {
        string label = "";

        switch (guest.guestWeight)
        {
            case Guest.Weight.large:
                label = "large";
                break;

            case Guest.Weight.medium:
                label = "medium";
                break;

            case Guest.Weight.thin:
                label = "small";
                break;

            default:
                label = "large";
                break;
        }

        bodyResolver.SetCategoryAndLabel(bodyCategory, label);
    }

    private void SetClothesSprite()
    {
        string label = "";

        if (guest.clothesType == Guest.ClothesType.dress)
        {
            switch (guest.guestWeight)
            {
                case Guest.Weight.large:
                    label = "dress_large";
                    break;

                case Guest.Weight.medium:
                    label = "dress_medium";
                    break;

                case Guest.Weight.thin:
                    label = "dress_small";
                    break;

                default:
                    label = "dress_large";
                    break;
            }
        }
        else
        {
            switch (guest.guestWeight)
            {
                case Guest.Weight.large:
                    label = "suit_large";
                    break;

                case Guest.Weight.medium:
                    label = "suit_medium";
                    break;

                case Guest.Weight.thin:
                    label = "suit_small";
                    break;

                default:
                    label = "suit_large";
                    break;
            }
        }

        clothesResolver.SetCategoryAndLabel(clothesCategory, label);
    }

    private void SetArmSprite()
    {
        string label = "";

        if (guest.clothesType == Guest.ClothesType.dress)
        {
            switch (guest.guestWeight)
            {
                case Guest.Weight.large:
                    label = "dress_large";
                    break;

                case Guest.Weight.medium:
                    label = "dress_medium";
                    break;

                case Guest.Weight.thin:
                    label = "dress_small";
                    break;

                default:
                    label = "dress_large";
                    break;
            }
        }
        else
        {
            switch (guest.guestWeight)
            {
                case Guest.Weight.large:
                    label = "suit_large";
                    break;

                case Guest.Weight.medium:
                    label = "suit_medium";
                    break;

                case Guest.Weight.thin:
                    label = "suit_small";
                    break;

                default:
                    label = "suit_large";
                    break;
            }
        }

        armResolver.SetCategoryAndLabel(armCategory, label);
    }

    private void SetMaskSprite()
    {
        string label = "";

        switch (guest.maskShape)
        {
            case Guest.MaskShape.owl:
                label = "owl";
                break;

            case Guest.MaskShape.cat:
                label = "cat";
                break;

            case Guest.MaskShape.fanged:
                label = "fanged";
                break;

            case Guest.MaskShape.horned:
                label = "horned";
                break;

            case Guest.MaskShape.bunny:
                label = "bunny";
                break;

            case Guest.MaskShape.gilled:
                label = "gilled";
                break;

            default:
                label = "owl";
                break;
        }

        maskResolver.SetCategoryAndLabel(maskCategory, label);
    }

    private void SetHairSprite()
    {
        string label = "";

        switch (guest.hairStyle)
        {
            case Guest.HairStyle.bob:
                label = "bob";
                break;

            case Guest.HairStyle.braided:
                label = "braided";
                break;

            case Guest.HairStyle.flowing:
                label = "flowing";
                break;

            case Guest.HairStyle.coiffed:
                label = "coiffed";
                break;

            case Guest.HairStyle.updo:
                label = "updo";
                break;

            case Guest.HairStyle.hatted:
                label = "hatted";
                break;

            default:
                label = "bob";
                break;
        }

        hairResolver.SetCategoryAndLabel(hairCategory, label);
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
        armRenderer.color = clothesColors.GetColor(GetClothesColorName(guest.clothesColor));
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
