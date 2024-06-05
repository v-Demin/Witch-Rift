﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Graybox.Core.EventSystem
{
    public class EventBus
    {
        private List<EventBus> _otherSubscribers = new();
        private Dictionary<Type, SubscribersList<ISubscriber>> _events = new();

        //TODO: to review
        private void Subscribe(EventBus eventBus)
        {
            _otherSubscribers.Add(eventBus);
        }

        public void Subscribe(ISubscriber subscriber)
        {
            var subscriberTypes = EventBusHelper.GetSubscriberTypes(subscriber);

            foreach (var type in subscriberTypes)
            {
                if (!_events.ContainsKey(type))
                    _events[type] = new SubscribersList<ISubscriber>();

                _events[type].Add(subscriber);
            }
        }

        //TODO: to review
        public void UnSubscribe(EventBus eventBus)
        {
            _otherSubscribers.Remove(eventBus);
        }
        
        public void Unsubscribe(ISubscriber subscriber)
        {
            var subscriberTypes = EventBusHelper.GetSubscriberTypes(subscriber);
            foreach (Type t in subscriberTypes)
            {
                if (_events.ContainsKey(t))
                    _events[t].Remove(subscriber);
            }
        }

        public void RaiseEvent<TSubscriber>(Action<TSubscriber> action)
            where TSubscriber : ISubscriber
        {
            if (!_events.ContainsKey(typeof(TSubscriber))) return;

            var subscribers = _events[typeof(TSubscriber)];

            foreach (ISubscriber subscriber in subscribers.List)
            {
                try
                {
                    action.Invoke((TSubscriber)subscriber);
                }
                catch (Exception e)
                {
                    if (Application.isEditor)
                        Debug.Log($"In {subscriber.GetType()} ---- {e}");
                }
            }
            
            _otherSubscribers.ForEach(a => a.RaiseEvent(action));
        }
    }
}
