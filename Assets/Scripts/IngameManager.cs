using UnityEngine;
using UnityEngine.SceneManagement;
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

        else if(Application.platform == RuntimePlatform.Android
            || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            StartCoroutine(CreateVirtualButtonOnEvent());
        }
        m_eventContainer = JEventSystem.Instance;

        Vector3     vSpawnPostion   = GameObject.FindWithTag(Configure.Instance.TAG_RESPAWN).transform.position;
        Object      oPlayer         = JResources.Load(Configure.Instance.PATH_PLAYER);
        GameObject  goPlayer        = JResources.Instantiate(oPlayer,vSpawnPostion,Quaternion.identity) as GameObject;
        
        JPlayerAnimatorController   JAC         = goPlayer.GetComponent<JPlayerAnimatorController>();
        JCharacterController        JCC         = goPlayer.GetComponent<JCharacterController>();

        if (null == JAC)
        {
            goPlayer.AddComponent<JPlayerAnimatorController>();
        }

        if (null == JCC)
        {
            goPlayer.AddComponent<JCharacterController>();
        }

        //Add camera component
        Camera.main.gameObject.AddComponent<TPSCamera>();
        
    }
    


    void GetZombieDeathEvent( int score )
    {
        BlackBoard.Instance.UserScore += score;

        JEventSystem.EnqueueEvent(E_EtcEvent.PointUp, BlackBoard.Instance.UserScore);
    }

    void ListenChangeScene(int num)
    {
        E_SceneNumber eTarget = (E_SceneNumber)num;
        switch(eTarget)
        {
            case E_SceneNumber.Menu:
                SceneManager.LoadSceneAsync(Configure.Instance.SCENENAME_MENU);
                break;

            default:
                Debug.LogFormat("Other case is not supported SceneName %s",((E_SceneNumber)num).ToString());
                break;
        }
    }

    #region On Virtual Button

    IEnumerator CreateVirtualButtonOnEvent()
    {
        yield return null;
        yield return null;
        JEventSystem.EnqueueEvent(E_EtcEvent.VirtualKeyOn);
    }

    #endregion
}
