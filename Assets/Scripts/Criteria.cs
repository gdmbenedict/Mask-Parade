using UnityEngine;
using System.Collections.Generic;
using System;

public class Criteria<Main, Secondary>
    where Main : struct, Enum
    where Secondary : struct, Enum
{
    public CriteriaType criteriaType;
    public Main mainCondition;
    public Secondary secondCondition;

    private static float allowChance = 0.25f;
    private static float exceptChance = 0.25f;

    public Criteria()
    {
        //randomly determine criteria type
        bool allowed = UnityEngine.Random.Range(0, 1) < allowChance ? true : false;
        bool except = UnityEngine.Random.Range(0, 1) < exceptChance ? true : false;

        //select correct criteria type
        if (allowed && except) criteriaType = CriteriaType.allowExcept;
        else if (allowed && !except) criteriaType = CriteriaType.allow;
        else if (!allowed && except) criteriaType = CriteriaType.notAllowedExcept;
        else if (!allowed && !except) criteriaType = CriteriaType.notAllowed;

        mainCondition = GetRandomEnumValue<Main>();
        
        if(criteriaType == CriteriaType.allowExcept || criteriaType == CriteriaType.notAllowedExcept)
        {
            secondCondition = GetRandomEnumValue<Secondary>();
        }
    }

    public bool CheckCriteria(Guest guest)
    {
        bool result = false;

        switch (criteriaType)
        {
            case CriteriaType.notAllowed:
                result = !CheckCondition<Main>(mainCondition, guest);
                break;

            case CriteriaType.notAllowedExcept:
                result = !CheckCondition<Main>(mainCondition, guest) || CheckCondition<Secondary>(secondCondition, guest);
                break;

            case CriteriaType.allow:
                result = CheckCondition<Main>(mainCondition, guest);
                break;

            case CriteriaType.allowExcept:
                result = CheckCondition<Main>(mainCondition, guest) && !CheckCondition<Secondary>(secondCondition, guest);
                break;

            default:
                break;
        }
        
        return result;
    }

    public string GetCriteriaDescription()
    {
        string description = "";

        //allow or don't allow text
        if (criteriaType == CriteriaType.notAllowedExcept || criteriaType == CriteriaType.notAllowed)
        {
            description += "Do not allow entry to guests";
        }
        else
        {
            description += "Let guests in";
        }

        //main condition description

        //unless description

        //secondary condition description

        return description;
    }

    private bool CheckCondition<T>(T condition, Guest guest)
    {
        if (typeof(T) == typeof(Guest.MaskShape))
        {
            if (condition.Equals(guest.maskShape))
            {
                return true;
            }
        }
        else if (typeof(T) == typeof(Guest.MaskColor))
        {
            if (condition.Equals(guest.maskColor))
            {
                return true;
            }
        }
        else if (typeof(T) == typeof(Guest.ClothesType))
        {
            if (condition.Equals(guest.clothesType))
            {
                return true;
            }
        }
        else if (typeof(T) == typeof(Guest.ClothesColor))
        {
            if (condition.Equals(guest.clothesColor))
            {
                return true;
            }
        }
        else if (typeof(T) == typeof(Guest.HairStyle))
        {
            if (condition.Equals(guest.hairStyle))
            {
                return true;
            }
        }
        else if (typeof(T) == typeof(Guest.Handedness))
        {
            if (condition.Equals(guest.handedness))
            {
                return true;
            }
        }
        else if (typeof(T) == typeof(Guest.Height))
        {
            if (condition.Equals(guest.guestHeight))
            {
                return true;
            }
        }
        else if (typeof(T) == typeof(Guest.Weight))
        {
            if (condition.Equals(guest.guestWeight))
            {
                return true;
            }
        }

        return false;
    }

    private T GetRandomEnumValue<T>() where T : struct, Enum
    {
        // Get all defined values for the enum type
        Array values = Enum.GetValues(typeof(T));

        // Select a random index
        int randomIndex = UnityEngine.Random.Range(0, values.Length);

        // Return the value at that index, cast back to the enum type
        return (T)values.GetValue(randomIndex);
    }
}

public enum CriteriaType
{
    notAllowed,
    notAllowedExcept,
    allow,
    allowExcept
}

    
