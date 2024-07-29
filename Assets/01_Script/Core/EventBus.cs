using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventBus<TEnum> where TEnum : Enum
{
    private Dictionary<TEnum, Action> eventTable = new Dictionary<TEnum, Action>();
    public void AddListener(TEnum eventType, Action listener)
    {
        if (!eventTable.ContainsKey(eventType))
        {
            eventTable.Add(eventType, listener);
        }
        else
        {
            eventTable[eventType] += listener;
        }
    }
    public void RemoveListener(TEnum eventType, Action listener)
    {
        if (eventTable.ContainsKey(eventType))
        {
            eventTable[eventType] -= listener;
            if (eventTable[eventType] == null)
            {
                eventTable.Remove(eventType);
            }
        }
    }
    public void Publish(TEnum eventType)
    {
        if (eventTable.ContainsKey(eventType))
        {
            eventTable[eventType]?.Invoke();
        }
    }
}
