using UnityEngine;

public abstract class AbstractCriteria 
{
    public CriteriaType criteriaType;

    public abstract bool CheckCriteria(Guest guest);

    public abstract string GetCriteriaDescription();
}
