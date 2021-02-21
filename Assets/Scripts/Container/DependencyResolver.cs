using System;
using System.Collections.Generic;
using UnityEngine;

public class DependencyResolver : MonoBehaviour
{
    private static Dictionary<Type, MonoBehaviour> singletons = new Dictionary<Type, MonoBehaviour>();

    public static GameManager ResolveGameManager()
    {
        if (singletons.ContainsKey(typeof(GameManager)))
        {
            return (GameManager) singletons[typeof(GameManager)];
        }

        var instance = FindObjectOfType<GameManager>();
        return instance;
    }
}