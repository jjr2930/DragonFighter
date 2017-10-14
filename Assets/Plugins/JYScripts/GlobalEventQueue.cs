using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;
//so dirty...... how to make simple
using ListenerDictionary = System.Collections.Generic.Dictionary<System.Enum, System.Collections.Generic.List<UnityEngine.Events.UnityEvent<System.Object>>>;
namespace JLib
{
    public static class GlobalEventQueue
    {
        public const long GLOBAL_ID = long.MinValue;

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

            for ( int i = 0 ; i < listeners[ id ][ eventName ].Count ;  i++)
            {
                listeners[ id ][ eventName ][i].Invoke( param );    
            }

        }

        public static void AddListener(long id, Enum eventName, UnityEvent<object> listener)
        {
            if ( !listeners.ContainsKey( id ) )
            {
                listeners.Add( id , new ListenerDictionary() );
            }

            if ( !listeners[ id ].ContainsKey( eventName ) )
            {
                listeners[ id ].Add( eventName , new List<UnityEvent<object>>() );
            }

            listeners[ id ][ eventName ].Add( listener );
        }

        public static void RemoveListener(long id, Enum eventName, UnityEvent<object> listener)
        {
            listeners[ id ][ eventName ].Remove( listener );
        }
    }
}