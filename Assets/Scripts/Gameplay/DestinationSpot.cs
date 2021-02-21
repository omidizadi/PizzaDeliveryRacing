using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationSpot : Spot
{
    public override void Disable()
    {
        base.Disable();
        gameManager.DestinationReached();
        gameManager.AddCash(Random.Range(50, 150));
        gameManager.ActivateRandomPizzaPickup();
    }
}