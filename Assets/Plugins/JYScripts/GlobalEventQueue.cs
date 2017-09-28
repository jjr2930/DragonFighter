using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using ListenerDictionary = System.Collections.Generic.Dictionary<System.Enum, System.Action<System.Object>>;
namespace JLib
{
    public static class GlobalEventQueue
    {
        static Dictionary<long, ListenerDictionary> listeners = new Dictionary<long, ListenerDictionary>();

        public static void SendEvent(long id, System.Enum eventName, System.Object param)
        {
            if (!listeners.ContainsKey( id ))
            {
                Debug.LogWarningFormat( "id({0}) is not contained id: {1}, eventName : {2}, param : {3}", id, id, eventName, param.ToString() );
                return;
            }

            if (!listeners[id].ContainsKey( eventName ))
            {
                Debug.LogWarningFormat( "event({0}) is not contained id: {1}, eventName : {2}, param : {3}", eventName, id, eventName, param.ToString() );
				return;
            }

            if( null == listeners[id][eventName])
            {
				Debug.LogWarningFormat( "listener is not contained id: {0}, eventName : {1}, param : {2}", id, eventName, param.ToString() );
				return;
            }

            listeners[id][eventName]( param );
        }

        public static void AddListener(long id, Enum eventName, Action<object> listener)
        {
            listeners[id][eventName] += listener;
        }

        public static void RemoveListener(long id, Enum eventName, Action<object> listener)
        {
            listeners[id][eventName] -= listener;
        }
    }
}