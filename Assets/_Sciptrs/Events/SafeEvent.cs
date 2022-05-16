using System;
using System.Collections.Generic;
using UnityEngine;
namespace CommonGame
{
    public class SafeEvent<T>
    {

        private List<Action<T>> _subscribers;
        public void Invoke(T value)
        {
            foreach (Action<T> rec in _subscribers)
            {
                rec.Invoke(value);
            }
        }

        public void Subscribe(Action<T> mDelegate)
        {
            if (_subscribers.Contains(mDelegate) == false)
            {
                _subscribers.Add(mDelegate);
            }
            else
                Debug.Log("Already Subscribed");
        }

        public void Unsubscribe(Action<T> mDelegate)
        {
            if (_subscribers.Contains(mDelegate) == true)
            {
                _subscribers.Remove(mDelegate);
            }
            else
                Debug.Log("not subscribed");
        }
    }
}