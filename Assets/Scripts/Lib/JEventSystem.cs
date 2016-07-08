using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class JEventParam
{
    public object       eventName;
    public GameObject   go;

    public JEventParam(object eventName, GameObject go)
    {
        this.eventName  = eventName;
        this.go         = go;
    }
}


public class JEventSystem : MonoSingle<JEventSystem>{
    Dictionary<string , Action<GameObject>>  m_diObservers   = null;
    Queue<JEventParam>                       m_queEvent      = null;
    
    public static void EnqueueEvent(object oEventName, GameObject go)
    {
        JEventSystem.Instance.m_queEvent.Enqueue(new JEventParam(oEventName,go));
    }

    public static void AddObserver(object oEventName, Action<GameObject> observer)
    {
        if(JEventSystem.Instance.m_diObservers.ContainsKey(oEventName.ToString()))
        {
            JEventSystem.Instance.m_diObservers[oEventName.ToString()] += observer;;
        }

        else
        {
            JEventSystem.Instance.m_diObservers.Add(oEventName.ToString(),observer);
        }
    }

	// Use this for initialization
	void Awake () {
        m_queEvent      = new Queue<JEventParam>();
        m_diObservers   = new Dictionary<string, Action<GameObject>>();
	}
	
	// Update is called once per frame
	void Update () {
        for( ; 0 < m_queEvent.Count ; )
        {
            JEventParam poped = m_queEvent.Dequeue();

            if( m_diObservers.ContainsKey( poped.eventName.ToString() ) )
            {
                m_diObservers[ poped.eventName.ToString() ]( poped.go );
            }
            else
            {
                Debug.LogFormat( "Event : {0} is not exist" , poped.eventName );
            }
        }
    }
}
