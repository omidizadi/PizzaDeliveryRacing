using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [SerializeField] private Transform carTransform;
    [SerializeField] private Vector2 modifier;
    [SerializeField] private Vector2 coordinator;
    [SerializeField] private RectTransform miniMapAnchor;
    [SerializeField] private RectTransform miniMap;

    private void Awake()
    {
        
    }

    private void Update()
    {
        miniMapAnchor.rotation = Quaternion.Euler(0, 0, carTransform.rotation.eulerAngles.y - 90);
        
        var position = carTransform.transform.position;
        miniMap.localPosition = new Vector2(position.z * coordinator.x + modifier.x,
            position.x * coordinator.y + modifier.y);
    }
}