using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerUnitList 
{
    static List<GameObject> unitList = new List<GameObject>();

    public static void AddUnit(GameObject unit)
    {
        unitList.Add(unit);
    }

    public static void RemoveUnit(GameObject unit)
    {
        unitList.Remove(unit);
    }
    
}
