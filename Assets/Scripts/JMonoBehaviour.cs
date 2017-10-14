using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

[System.Serializable]
public class AddEventData
{
    public IngameEventName m_eEventName;
    public ObjectUnityEvent m_method;
}

public class JMonoBehaviour : MonoBehaviour
{
    [SerializeField]
    bool m_bIsGlobal = false;

    [SerializeField]
    List<AddEventData> m_listEventListenerData
        = new List<AddEventData>();

    bool m_bAppQuit = false;
    long m_lID = 0L;
    protected virtual void Awake()
    {
        m_lID = ( m_bIsGlobal ) ? JLib.GlobalEventQueue.GLOBAL_ID : gameObject.GetInstanceID();

        for ( int i = 0 ; i < m_listEventListenerData.Count ;  i++)
        {
            IngameEventName eventName = m_listEventListenerData[ i ].m_eEventName;
            ObjectUnityEvent listenerMethod = m_listEventListenerData[ i ].m_method;
            JLib.GlobalEventQueue.AddListener( m_lID , eventName , listenerMethod );
        }
    }

    protected virtual void OnDestroy()
    {
        if ( m_bAppQuit )
        { return; }

		for ( int i = 0 ; i < m_listEventListenerData.Count ; i++ )
		{
			IngameEventName eventName = m_listEventListenerData[ i ].m_eEventName;
			ObjectUnityEvent listenerMethod = m_listEventListenerData[ i ].m_method;
            JLib.GlobalEventQueue.RemoveListener( m_lID , eventName , listenerMethod );
		}
    }

    private void OnApplicationQuit()
    {
        m_bAppQuit = true;
    }
}
