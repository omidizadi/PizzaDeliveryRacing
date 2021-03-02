using System;
using System.Collections.Generic;
using UnityEngine;

public class DependencyResolver : MonoBehaviour
{
    private static Dictionary<Type, MonoBehaviour> singletons = new Dictionary<Type, MonoBehaviour>();

    public static T ResolveSingleton<T>() where T : MonoBehaviour
    {
        if (singletons.ContainsKey(typeof(T)))
            return (T) singletons[typeof(T)];
        var instance = FindObjectOfType<T>();
        singletons.Add(typeof(T), instance);
        return instance;
    }
}