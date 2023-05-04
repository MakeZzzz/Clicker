using System.Collections;
using System.Collections.Generic;
using SimpleEventBus.Events;
using UnityEngine;

public class GetDecreaseEvent : EventBase
{
    public float Lesion { get; }

    public GetDecreaseEvent(float lesion)
    {
        Lesion = lesion;
    }
}
