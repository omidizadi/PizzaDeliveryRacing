using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spot : MonoBehaviour
{
    public bool IsActive { get; private set; }

    private SpotTrigger spotTrigger;
    protected GameManager gameManager;
    private Vector3 worldPosition;

    private void Start()
    {
        gameManager = DependencyResolver.ResolveSingleton<GameManager>();
        worldPosition = gameObject.transform.position;
    }

    public void Activate(SpotTrigger trigger)
    {
        IsActive = true;
        spotTrigger = trigger;
        spotTrigger.SetSpot(this);
        spotTrigger.transform.position = worldPosition;
        spotTrigger.gameObject.SetActive(true);
    }

    public virtual void Disable()
    {
        spotTrigger.gameObject.SetActive(false);
        IsActive = false;
    }

    public Vector3 GetWorldPosition()
    {
        return worldPosition;
    }
}