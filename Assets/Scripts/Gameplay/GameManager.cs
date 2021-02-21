using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public event Action OnPizzaPicked;
    public event Action OnDestinationReached;
    public event Action OnCashReceived;

    [Header("Camera")][SerializeField]  private GameObject gameCamera;
    [SerializeField] private GameObject menuCamera;
    
    [Header("UI")][SerializeField]  private GameObject menuUI;
    [SerializeField] private GameObject gameUI;

    [Header("Car Controller")] [SerializeField]
    private CarController carController;

    [Header("Spots")] [SerializeField] private CashSpot[] cashSpots;
    [SerializeField] private DestinationSpot[] destinationSpots;
    [SerializeField] private PizzaPickupSpot[] pizzaPickupSpots;

    [Header("Triggers")] [SerializeField] private SpotTrigger destinationTrigger;
    [SerializeField] private SpotTrigger pizzaPickupTrigger;
    [SerializeField] private SpotTrigger[] cashTriggers;

    private DestinationSpot activeDestinationSpot;
    private PizzaPickupSpot activePizzaPickupSpot;
    public int Cash { get; private set; }

    private bool pickedUpPizza;

    private void Start()
    {
        carController.enabled = false;
    }

    public void StartGame()
    {
        carController.enabled = true;
        gameCamera.SetActive(true);
        menuCamera.SetActive(false);
        gameUI.SetActive(true);
        menuUI.SetActive(false);
        ActivateRandomPizzaPickup();
    }

    public void DestinationReached()
    {
        OnDestinationReached?.Invoke();
    }

    public void PizzaPicked()
    {
        OnPizzaPicked?.Invoke();
    }

    public void ActivateRandomDestination()
    {
        var randDestinationSpotIndex = Random.Range(0, destinationSpots.Length);
        destinationSpots[randDestinationSpotIndex].Activate(destinationTrigger);
        activeDestinationSpot = destinationSpots[randDestinationSpotIndex];
        pickedUpPizza = true;
    }

    public void ActivateRandomPizzaPickup()
    {
        var randPizzaSpotIndex = Random.Range(0, pizzaPickupSpots.Length);
        pizzaPickupSpots[randPizzaSpotIndex].Activate(pizzaPickupTrigger);
        activePizzaPickupSpot = pizzaPickupSpots[randPizzaSpotIndex];
        pickedUpPizza = false;
    }


    public bool IsHeadingToPizza()
    {
        return !pickedUpPizza;
    }

    public bool IsHeadingToDestination()
    {
        return pickedUpPizza;
    }

    public DestinationSpot GetActiveDestinationSpot()
    {
        return activeDestinationSpot.IsActive ? activeDestinationSpot : null;
    }

    public PizzaPickupSpot GetActivePizzaPickupSpot()
    {
        return activePizzaPickupSpot.IsActive ? activePizzaPickupSpot : null;
    }

    public void AddCash(int amount)
    {
        Cash += amount;
        OnCashReceived?.Invoke();
    }
}