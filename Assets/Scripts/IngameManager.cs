using UnityEngine;
using System.Collections;

public class IngameManager : MonoSingle<IngameManager> {

    MonoBehaviour m_inputInstance = null;
    MonoBehaviour m_eventContainer =null;
    // Use this for initialization
    void Awake() {
        if( Application.platform == RuntimePlatform.WindowsPlayer 
            || Application.platform == RuntimePlatform.WindowsEditor
            || Application.platform == RuntimePlatform.WindowsWebPlayer)
        {
            m_inputInstance = this.gameObject.AddComponent<PCInput>();
        }

        m_eventContainer = this.gameObject.AddComponent<JEventSystem>();

        GameObject goPlayer     = GameObject.FindWithTag(Configure.Instance.TAG_PLAYER);
        JPlayerAnimatorController JAC = goPlayer.GetComponent<JPlayerAnimatorController>();
        JCharacterController JCC = goPlayer.GetComponent<JCharacterController>();
        if (null == JAC)
        {
            goPlayer.AddComponent<JPlayerAnimatorController>();
        }

        if (null == JCC)
        {
            goPlayer.AddComponent<JCharacterController>();
        }
    }


    void GetZombieDeathEvent( int score )
    {
        BlackBoard.Instance.UserScore += score;

        JEventSystem.EnqueueEvent(E_EtcEvent.PointUp, BlackBoard.Instance.UserScore);
    }
}
