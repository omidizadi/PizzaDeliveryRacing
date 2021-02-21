using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CashSpot))]
public class CashSpotDetector : Editor
{
    private void OnSceneGUI()
    {
        if (Event.current.type == EventType.Repaint)
        {
            //kept this inefficient function just to deliver on time :)

            var cashSpots = FindObjectsOfType<CashSpot>();
            foreach (var obj in cashSpots)
            {
                var transform = obj.transform;

                Handles.color = Color.green;
                Handles.SphereHandleCap(0, transform.position, transform.rotation, 5, EventType.Repaint);
            }
        }
    }
}