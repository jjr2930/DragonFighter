using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IngameUIListener : MonoSingle<IngameUIListener>
{
    [SerializeField]
    Text m_txtScore = null;

    [SerializeField]
    GameObject m_VirtualKey = null;

    void Start()
    {
        JEventSystem.AddObserver(E_EtcEvent.PointUp, ListenPointEvent);
        JEventSystem.AddObserver(E_EtcEvent.VirtualKeyOn, ListenVirtualKeyOnEvent);
    }

    public void ListenPointEvent(int score )
    {
        m_txtScore.text = score.ToString();
    }

    public void ListenVirtualKeyOnEvent(int number)
    {
        m_VirtualKey.SetActive(true);
    }
}
