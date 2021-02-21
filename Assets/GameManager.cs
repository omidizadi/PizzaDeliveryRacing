using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CashSpot[] cashSpots;
    [SerializeField] private DestinationSpot[] destinationSpots;
    [SerializeField] private PizzaPickupSpot[] pizzaPickupSpots;

    [SerializeField] private SpotTrigger destinationTrigger;
    [SerializeField] private SpotTrigger pizzaPickupTrigger;
    [SerializeField] private SpotTrigger[] cashTriggers;



}
