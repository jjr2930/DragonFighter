using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuUIEventListener : MonoBehaviour
{
    [SerializeField]
    GameObject m_goRecord;

    [SerializeField]
    Text[] m_txtRecords = null;
    
    public void OnEnable()
    {
        m_txtRecords = m_goRecord.GetComponentsInChildren<Text>();

        JEventSystem.AddObserver(E_MenuEvnet.ExitClick, ListenExitClick);
        JEventSystem.AddObserver(E_MenuEvnet.RecordClick, ListenRecordClick);
        JEventSystem.AddObserver(E_MenuEvnet.StartClick, ListenStartClick);
        JEventSystem.AddObserver(E_MenuEvnet.CloseRecordClick, ListenCloseRecordClick);

        //first, Record ui is not show
        JEventSystem.EnqueueEvent(E_MenuEvnet.CloseRecordClick);
    }

    public void ListenStartClick(int param)
    {
        JEventSystem.EnqueueEvent(E_UIEvent.SceneChange, (int)E_SceneNumber.Ingame);
    }

    public void ListenRecordClick(int param)
    {
        m_goRecord.SetActive(true);
        m_txtRecords = m_goRecord.GetComponentsInChildren<Text>();

        //readRecord
        for(int i = 0; i<m_txtRecords.Length; i++)
        {
            m_txtRecords[i].text = "";
        }
    }

    public void ListenCloseRecordClick(int param)
    {
        m_goRecord.SetActive(false);
    }

    public void ListenExitClick(int param)
    {
        JEventSystem.EnqueueEvent(E_UIEvent.SceneChange, (int)E_SceneNumber.Exit);
    }
}
