using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPickupSpot : Spot
{
    public override void Disable()
    {
        base.Disable();
        gameManager.PizzaPicked();
        gameManager.ActivateRandomDestination();
    }
}
