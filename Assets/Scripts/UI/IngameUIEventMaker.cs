using UnityEngine;
using System.Collections;

public class IngameUIEventMaker : MonoBehaviour {

    [SerializeField]
    E_VirtualKey m_eVirtualBtnEvent = E_VirtualKey.Max;

    [SerializeField]
    E_UIEvent m_eUIEvent= E_UIEvent.MAX;
    
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateKeyEvent()
    {
        Debug.LogFormat("Create Key Event {0}", m_eVirtualBtnEvent);
        JEventSystem.EnqueueEvent( m_eVirtualBtnEvent , GetInstanceID() );
    }

    public void CreateUIEvent(string strSceneName)
    {
        Debug.LogFormat("Create UI Event {0}", m_eUIEvent);
        int iParam = 0;
        switch(strSceneName)
        {
            case "Intro":
                iParam = (int)E_SceneNumber.Intro;
                break;

            case "Menu":
                iParam = (int)E_SceneNumber.Menu;
                break;

            case "Ingame":
                iParam = (int)E_SceneNumber.Ingame;
                break;

            case "Exit":
                iParam = (int)E_SceneNumber.Exit;
                break;
        }

        JEventSystem.EnqueueEvent(m_eUIEvent, iParam);
    }
}
