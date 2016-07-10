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
        JAnimatorController JAC = goPlayer.GetComponent<JAnimatorController>();

        if (null == JAC)
        {
            goPlayer.AddComponent<JAnimatorController>();
        }
	}
	
}
