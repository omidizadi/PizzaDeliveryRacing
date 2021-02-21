using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spot : MonoBehaviour
{
    
    public Vector3 GetWorldPosition()
    {
        return gameObject.transform.position;
    }

    public virtual void EnableSpot()
    {
        
    }

    public virtual void DisableSpot()
    {
      
    }

    
}
