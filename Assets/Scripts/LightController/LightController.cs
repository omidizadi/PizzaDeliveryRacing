using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour, ICarLightController
{
  
    [SerializeField] private GameObject brakeLights;

    public void BrakeLights(bool show)
    {
        brakeLights.SetActive(show);
    }
}
