using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuUIEventMaker : EventMakerBase {
 
    [SerializeField]
    E_MenuEvnet m_eEvent = E_MenuEvnet.ExitClick;

    
    public override void CreateEvent()
    {
        JEventSystem.EnqueueEvent(m_eEvent);
    }
}

