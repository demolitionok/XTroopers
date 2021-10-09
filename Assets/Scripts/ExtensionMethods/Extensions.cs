using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions
{
    public static T RandomElement<T>(this T[] collection)
    {
        var randomIndex = Random.Range(0, collection.Count() - 1);
        return collection[randomIndex];
    }
}
