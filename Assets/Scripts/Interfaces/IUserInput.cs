using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserInput
{
   event Action<Vector2> OnMove;
   event Action<float> OnBrake;
   event Action<float> OnDrift;
}
