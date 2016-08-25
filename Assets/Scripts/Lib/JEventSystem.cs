using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class JEventParam
{
    public object       m_oEventName;
    public int          m_iInstanceID;

    public JEventParam(object oEventName, int iInstanceID)
    {
        this.m_oEventName   = oEventName;
        this.m_iInstanceID  = iInstanceID;
    }
    
}


public class JEventSystem : MonoSingle<JEventSystem>
{
    Dictionary<string , Action<int>>     m_dicObservers_go   = null;
    Queue<JEventParam>                   m_queEvent          = null;

    public static void EnqueueEvent( object oEventName , int iInstanceID = 0)
    {

        JEventSystem.Instance.m_queEvent.Enqueue(new JEventParam(oEventName, iInstanceID));
    }

    public static void AddObserver(object oEventName, Action<int> observer)
    {
        if(JEventSystem.Instance.m_dicObservers_go.ContainsKey(oEventName.ToString()))
        {
            JEventSystem.Instance.m_dicObservers_go[oEventName.ToString()] += observer;;
        }

        else
        {
            JEventSystem.Instance.m_dicObservers_go.Add(oEventName.ToString(),observer);
        }
    }

	// Use this for initialization
	void Awake () {
        m_queEvent          = new Queue<JEventParam>();
        m_dicObservers_go   = new Dictionary<string, Action<int>>();
	}
	
	// Update is called once per frame
	void Update () {
        for( ; 0 < m_queEvent.Count ; )
        {
            JEventParam poped = m_queEvent.Dequeue();

            if( m_dicObservers_go.ContainsKey( poped.m_oEventName.ToString() ) )
            {
                m_dicObservers_go[ poped.m_oEventName.ToString() ]( poped.m_iInstanceID );
            }
            else
            {
                Debug.LogFormat( "Event : {0} is not exist" , poped.m_oEventName );
            }
        }
    }
}
