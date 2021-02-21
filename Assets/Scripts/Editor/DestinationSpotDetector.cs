using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DestinationSpot))]
public class DestinationSpotDetector : Editor
{
    private void OnSceneGUI()
    {
        if (Event.current.type == EventType.Repaint)
        {
            //kept this inefficient function just to deliver on time :)
            var destinationSports = FindObjectsOfType<DestinationSpot>();
            foreach (var obj in destinationSports)
            {
                var transform = obj.transform;

                Handles.color = Color.red;
                Handles.SphereHandleCap(0, transform.position, transform.rotation, 5, EventType.Repaint);
            }
        }
    }
}