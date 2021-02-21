using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PizzaPickupSpot))]
public class PizzaPickupSpotDetector : Editor
{
    private void OnSceneGUI()
    {
        if (Event.current.type == EventType.Repaint)
        {
            //kept this inefficient function just to deliver on time :)

            var pizzaPickupSpots = FindObjectsOfType<PizzaPickupSpot>();
            foreach (var obj in pizzaPickupSpots)
            {
                var transform = obj.transform;

                Handles.color = Color.yellow;
                Handles.SphereHandleCap(0, transform.position, transform.rotation, 5, EventType.Repaint);
            }
        }
    }
}