using UnityEngine;
using System.Collections.Generic;
using System;
public class CriteriaManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GuestManager guestManager;

    private List<AbstractCriteria> criteriaList = new List<AbstractCriteria>();
    private int criteriaAmount = 5;

    // Start is called once before the first eattributeOneecution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateCriteria();
        SystemManager.systemManager.uIManager.SetRulesText(GenerateCriteriaDescriptions());
    }

    private void GenerateCriteria()
    {
        for (int i=0; i<criteriaAmount; i++)
        {
            criteriaList.Add(GetRandomCriteria());
        }
    }

    public string GenerateCriteriaDescriptions()
    {
        string description = string.Empty;

        for (int i=0; i<criteriaList.Count; i++)
        {
            description += criteriaList[i].GetCriteriaDescription();

            //spacing logic
            if (i < criteriaList.Count - 1) description += "\n\n";
        }

        return description;
    }

    public bool CheckGuest()
    {
        bool guestApproved = true;

        foreach (AbstractCriteria criteria in criteriaList)
        {
            switch (criteria.criteriaType)
            {
                case CriteriaType.allow:
                    if(criteria.CheckCriteria(guestManager.guest)) return true;
                    break;

                case CriteriaType.allowExcept:
                    if (criteria.CheckCriteria(guestManager.guest)) return true;
                    break;

                case CriteriaType.notAllowed:
                    if (!criteria.CheckCriteria(guestManager.guest)) guestApproved = false;
                    break;

                case CriteriaType.notAllowedExcept:
                    if (!criteria.CheckCriteria(guestManager.guest)) guestApproved = false;
                    break;

                default:
                    break;
            }
        }

        return guestApproved;
    }

    private AbstractCriteria GetRandomCriteria()
    {
        AbstractCriteria criteria;

        //select the two conditions
        List<int> attributes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
        int attributeOne = attributes[UnityEngine.Random.Range(0, attributes.Count)];
        attributes.Remove(attributeOne);
        int attributeTwo = attributes[UnityEngine.Random.Range(0, attributes.Count)];

        #region very long if else
        if (attributeOne == 0 && attributeTwo == 1)
        {
            criteria = new Criteria<Guest.MaskShape, Guest.MaskColor>();
        }
        else if (attributeOne == 0 && attributeTwo == 2)
        {
            criteria = new Criteria<Guest.MaskShape, Guest.ClothesType>();
        }
        else if (attributeOne == 0 && attributeTwo == 3)
        {
            criteria = new Criteria<Guest.MaskShape, Guest.ClothesColor>();
        }
        else if (attributeOne == 0 && attributeTwo == 4)
        {
            criteria = new Criteria<Guest.MaskShape, Guest.HairStyle>();
        }
        else if (attributeOne == 0 && attributeTwo == 5)
        {
            criteria = new Criteria<Guest.MaskShape, Guest.Handedness>();
        }
        else if (attributeOne == 0 && attributeTwo == 6)
        {
            criteria = new Criteria<Guest.MaskShape, Guest.Height>();
        }
        else if (attributeOne == 0 && attributeTwo == 7)
        {
            criteria = new Criteria<Guest.MaskShape, Guest.Weight>();
        }
        else if (attributeOne == 1 && attributeTwo == 0)
        {
            criteria = new Criteria<Guest.MaskColor, Guest.MaskShape>();
        }
        else if (attributeOne == 1 && attributeTwo == 2)
        {
            criteria = new Criteria<Guest.MaskColor, Guest.ClothesType>();
        }
        else if (attributeOne == 1 && attributeTwo == 3)
        {
            criteria = new Criteria<Guest.MaskColor, Guest.ClothesColor>();
        }
        else if (attributeOne == 1 && attributeTwo == 4)
        {
            criteria = new Criteria<Guest.MaskColor, Guest.HairStyle>();
        }
        else if (attributeOne == 1 && attributeTwo == 5)
        {
            criteria = new Criteria<Guest.MaskColor, Guest.Handedness>();
        }
        else if (attributeOne == 1 && attributeTwo == 6)
        {
            criteria = new Criteria<Guest.MaskColor, Guest.Height>();
        }
        else if (attributeOne == 1 && attributeTwo == 7)
        {
            criteria = new Criteria<Guest.MaskColor, Guest.Weight>();
        }
        else if (attributeOne == 2 && attributeTwo == 0)
        {
            criteria = new Criteria<Guest.ClothesType, Guest.MaskShape>();
        }
        else if (attributeOne == 2 && attributeTwo == 1)
        {
            criteria = new Criteria<Guest.ClothesType, Guest.MaskColor>();
        }
        else if (attributeOne == 2 && attributeTwo == 3)
        {
            criteria = new Criteria<Guest.ClothesType, Guest.ClothesColor>();
        }
        else if (attributeOne == 2 && attributeTwo == 4)
        {
            criteria = new Criteria<Guest.ClothesType, Guest.HairStyle>();
        }
        else if (attributeOne == 2 && attributeTwo == 5)
        {
            criteria = new Criteria<Guest.ClothesType, Guest.Handedness>();
        }
        else if (attributeOne == 2 && attributeTwo == 6)
        {
            criteria = new Criteria<Guest.ClothesType, Guest.Height>();
        }
        else if (attributeOne == 2 && attributeTwo == 7)
        {
            criteria = new Criteria<Guest.ClothesType, Guest.Weight>();
        }
        else if (attributeOne == 3 && attributeTwo == 0)
        {
            criteria = new Criteria<Guest.ClothesColor, Guest.MaskShape>();
        }
        else if (attributeOne == 3 && attributeTwo == 1)
        {
            criteria = new Criteria<Guest.ClothesColor, Guest.MaskColor>();
        }
        else if (attributeOne == 3 && attributeTwo == 2)
        {
            criteria = new Criteria<Guest.ClothesColor, Guest.ClothesType>();
        }
        else if (attributeOne == 3 && attributeTwo == 4)
        {
            criteria = new Criteria<Guest.ClothesColor, Guest.HairStyle>();
        }
        else if (attributeOne == 3 && attributeTwo == 5)
        {
            criteria = new Criteria<Guest.ClothesColor, Guest.Handedness>();
        }
        else if (attributeOne == 3 && attributeTwo == 6)
        {
            criteria = new Criteria<Guest.ClothesColor, Guest.Height>();
        }
        else if (attributeOne == 3 && attributeTwo == 7)
        {
            criteria = new Criteria<Guest.ClothesColor, Guest.Weight>();
        }
        else if (attributeOne == 4 && attributeTwo == 0)
        {
            criteria = new Criteria<Guest.HairStyle, Guest.MaskShape>();
        }
        else if (attributeOne == 4 && attributeTwo == 1)
        {
            criteria = new Criteria<Guest.HairStyle, Guest.MaskColor>();
        }
        else if (attributeOne == 4 && attributeTwo == 2)
        {
            criteria = new Criteria<Guest.HairStyle, Guest.ClothesType>();
        }
        else if (attributeOne == 4 && attributeTwo == 3)
        {
            criteria = new Criteria<Guest.HairStyle, Guest.ClothesColor>();
        }
        else if (attributeOne == 4 && attributeTwo == 5)
        {
            criteria = new Criteria<Guest.HairStyle, Guest.Handedness>();
        }
        else if (attributeOne == 4 && attributeTwo == 6)
        {
            criteria = new Criteria<Guest.HairStyle, Guest.Height>();
        }
        else if (attributeOne == 4 && attributeTwo == 7)
        {
            criteria = new Criteria<Guest.HairStyle, Guest.Weight>();
        }
        else if (attributeOne == 5 && attributeTwo == 0)
        {
            criteria = new Criteria<Guest.Handedness, Guest.MaskShape>();
        }
        else if (attributeOne == 5 && attributeTwo == 1)
        {
            criteria = new Criteria<Guest.Handedness, Guest.MaskColor>();
        }
        else if (attributeOne == 5 && attributeTwo == 2)
        {
            criteria = new Criteria<Guest.Handedness, Guest.ClothesType>();
        }
        else if (attributeOne == 5 && attributeTwo == 3)
        {
            criteria = new Criteria<Guest.Handedness, Guest.ClothesColor>();
        }
        else if (attributeOne == 5 && attributeTwo == 4)
        {
            criteria = new Criteria<Guest.Handedness, Guest.HairStyle>();
        }
        else if (attributeOne == 5 && attributeTwo == 6)
        {
            criteria = new Criteria<Guest.Handedness, Guest.Height>();
        }
        else if (attributeOne == 5 && attributeTwo == 7)
        {
            criteria = new Criteria<Guest.Handedness, Guest.Weight>();
        }
        else if (attributeOne == 6 && attributeTwo == 0)
        {
            criteria = new Criteria<Guest.Height, Guest.MaskShape>();
        }
        else if (attributeOne == 6 && attributeTwo == 1)
        {
            criteria = new Criteria<Guest.Height, Guest.MaskColor>();
        }
        else if (attributeOne == 6 && attributeTwo == 2)
        {
            criteria = new Criteria<Guest.Height, Guest.ClothesType>();
        }
        else if (attributeOne == 6 && attributeTwo == 3)
        {
            criteria = new Criteria<Guest.Height, Guest.ClothesColor>();
        }
        else if (attributeOne == 6 && attributeTwo == 4)
        {
            criteria = new Criteria<Guest.Height, Guest.HairStyle>();
        }
        else if (attributeOne == 6 && attributeTwo == 5)
        {
            criteria = new Criteria<Guest.Height, Guest.Handedness>();
        }
        else if (attributeOne == 6 && attributeTwo == 7)
        {
            criteria = new Criteria<Guest.Height, Guest.Weight>();
        }
        else if (attributeOne == 7 && attributeTwo == 0)
        {
            criteria = new Criteria<Guest.Weight, Guest.MaskShape>();
        }
        else if (attributeOne == 7 && attributeTwo == 1)
        {
            criteria = new Criteria<Guest.Weight, Guest.MaskColor>();
        }
        else if (attributeOne == 7 && attributeTwo == 2)
        {
            criteria = new Criteria<Guest.Weight, Guest.ClothesType>();
        }
        else if (attributeOne == 7 && attributeTwo == 3)
        {
            criteria = new Criteria<Guest.Weight, Guest.ClothesColor>();
        }
        else if (attributeOne == 7 && attributeTwo == 4)
        {
            criteria = new Criteria<Guest.Weight, Guest.HairStyle>();
        }
        else if (attributeOne == 7 && attributeTwo == 5)
        {
            criteria = new Criteria<Guest.Weight, Guest.Handedness>();
        }
        else
        {
            criteria = new Criteria<Guest.Weight, Guest.Height>();
        }
        #endregion

        return criteria;
    }
}
