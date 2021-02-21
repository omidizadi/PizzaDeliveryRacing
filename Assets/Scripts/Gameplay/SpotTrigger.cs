using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotTrigger : MonoBehaviour
{
    [SerializeField] private Spot spot;

    public void SetSpot(Spot spot)
    {
        this.spot = spot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag($"Player"))
        {
            spot.Disable();
        }
    }
}