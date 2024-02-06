using System;
using System.Collections.Generic;
using UnityEngine;

public class EventHolder : MonoBehaviour
{
    public Dictionary<Type, List<ISubscriber>> _events = new ();

    public void Subscribe<T>(T subscriber)
    {
        if (subscriber is not ISubscriber subscriberInner) return; 
        
        var subscriberTypes = EventBusHelper.GetSubscriberTypes(subscriberInner);

        foreach (var type in subscriberTypes)
        {
            if (!_events.ContainsKey(type))
                _events[type] = new List<ISubscriber>();
            
            _events[type].Add(subscriberInner);
        }
    }

    public void RaiseEvent<TSubscriber>(Action<TSubscriber> action)
        where TSubscriber : class, ISubscriber
    {
        var subscribers = _events[typeof(TSubscriber)];
        foreach (ISubscriber subscriber in subscribers)
        {
            try
            {
                action.Invoke(subscriber as TSubscriber);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
