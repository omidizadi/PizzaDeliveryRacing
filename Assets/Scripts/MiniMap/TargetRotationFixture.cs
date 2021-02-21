using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotationFixture : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform anchorRectTransform;

    void LateUpdate()
    {
        rectTransform.localRotation = Quaternion.Euler(0, 0, -anchorRectTransform.localRotation.eulerAngles.z);
    }
}