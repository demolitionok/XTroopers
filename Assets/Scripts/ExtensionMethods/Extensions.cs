using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions
{
    public static T RandomElement<T>(this T[] collection)
    {
        if (collection.Length == 0)
        {
            Debug.LogError($"{collection} is empty. Random element does not exist.");
        }

        var randomIndex = Random.Range(0, collection.Length - 1);
        return collection[randomIndex];
    }
}
