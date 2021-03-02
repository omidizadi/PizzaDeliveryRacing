using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [Header("Car In Map")] [SerializeField]
    private Transform carTransform;

    [SerializeField] private Vector2 modifier;
    [SerializeField] private Vector2 coordinator;
    [SerializeField] private RectTransform miniMapAnchor;
    [SerializeField] private RectTransform miniMap;
    [SerializeField] private RectTransform carIndicator;

    [Header("Targets In Map")] [SerializeField]
    private RectTransform pizzaSpot;

    [SerializeField] private RectTransform destinationSpot;
    [SerializeField] private float targetMaxDistanceInMap;
    [SerializeField] private float targetMaxDistanceInMiniMap;

    private float directionMaxDistance;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = DependencyResolver.ResolveSingleton<GameManager>();
    }

    private void Update()
    {
        SetMapPosition();
        SetPizzaSpot();
        SetDestinationSpot();
    }

    private void SetMapPosition()
    {
        miniMapAnchor.rotation = Quaternion.Euler(0, 0, carTransform.rotation.eulerAngles.y - 90);
        var position = carTransform.transform.position;
        miniMap.localPosition = ConvertToMiniMapCoordination(position);
    }

    private void SetPizzaSpot()
    {
        if (gameManager.IsHeadingToPizza())
        {
            var activePizzaSpot = gameManager.GetActivePizzaPickupSpot();
            pizzaSpot.gameObject.SetActive(true);
            pizzaSpot.localPosition = DirectionFromCarToTarget(activePizzaSpot.GetWorldPosition());
        }
        else
        {
            pizzaSpot.gameObject.SetActive(false);
        }
    }

    private void SetDestinationSpot()
    {
        if (gameManager.IsHeadingToDestination())
        {
            var activeDestinationSpot = gameManager.GetActiveDestinationSpot();
            destinationSpot.gameObject.SetActive(true);
            destinationSpot.localPosition = DirectionFromCarToTarget(activeDestinationSpot.GetWorldPosition());
        }
        else
        {
            destinationSpot.gameObject.SetActive(false);
        }
    }

    private Vector2 DirectionFromCarToTarget(Vector3 target)
    {
        var realWorldDirection = target - carTransform.transform.position;
        directionMaxDistance = ClampDistanceToTarget(realWorldDirection.sqrMagnitude);
        var newDirection = new Vector2(-realWorldDirection.normalized.z, realWorldDirection.normalized.x);
        var directionToCarIndicator = (Vector2) carIndicator.localPosition.normalized + newDirection;
        return directionToCarIndicator.normalized * directionMaxDistance;
    }

    private Vector2 ConvertToMiniMapCoordination(Vector3 worldPosition)
    {
        return new Vector2(worldPosition.z * coordinator.x + modifier.x,
            worldPosition.x * coordinator.y + modifier.y);
    }

    private float ClampDistanceToTarget(float value)
    {
        return Mathf.Clamp(value * targetMaxDistanceInMiniMap / targetMaxDistanceInMap, 0, targetMaxDistanceInMiniMap);
    }
}