using UnityEngine;
using System.Collections;

public class JCharacterController : MonoBehaviour {
    CharacterController m_CharCtrl = null;
	// Use this for initialization
	void Awake()
    {
        m_CharCtrl = this.GetComponent<CharacterController>();
	}

    void Start()
    {
        JEventSystem.AddObserver(E_VirtualKey.Forward, GetKeyFwd);
        JEventSystem.AddObserver(E_VirtualKey.Back, GetKeyBack);
        JEventSystem.AddObserver(E_VirtualKey.Left, GetKeyLeft);
        JEventSystem.AddObserver(E_VirtualKey.Right, GetKeyRight);

        JEventSystem.AddObserver(E_VirtualKey.Forward_Down, GetKeyFwd);
        JEventSystem.AddObserver(E_VirtualKey.Back_Down, GetKeyBack);
        JEventSystem.AddObserver(E_VirtualKey.Left_Down, GetKeyLeft);
        JEventSystem.AddObserver(E_VirtualKey.Right_Down, GetKeyRight);

        JEventSystem.AddObserver(E_VirtualKey.Forward_UP, GetKeyUpFwd);
        JEventSystem.AddObserver(E_VirtualKey.Back_UP, GetKeyUpBack);
        JEventSystem.AddObserver(E_VirtualKey.Left_UP, GetKeyUpLeft);
        JEventSystem.AddObserver(E_VirtualKey.Right_UP, GetKeyUpRight);

        //JEventSystem.AddObserver(E_VirtualKey.ButtonA_Down, GetKeyDownA);
        //JEventSystem.AddObserver(E_VirtualKey.ButtonB_Down, GetKeyDownB);
    }
    #region Locomotion
    #region key press
    void GetKeyFwd(GameObject go)
    {
        m_CharCtrl.Move(this.transform.forward * Configure.Instance.MOVE_FWD_LIMIT);
    }

    void GetKeyBack(GameObject go)
    {
        m_CharCtrl.Move(-this.transform.forward * Configure.Instance.MOVE_BACK_LIMIT);
    }

    void GetKeyLeft(GameObject go)
    {
        m_CharCtrl.Move(-this.transform.right * Configure.Instance.MOVE_STRAFE_LIMIT);
    }

    void GetKeyRight(GameObject go)
    {
        m_CharCtrl.Move(this.transform.right * Configure.Instance.MOVE_STRAFE_LIMIT);
    }

    #endregion

    #region key Up
    void GetKeyUpFwd(GameObject go)
    {
        m_CharCtrl.Move(Vector3.zero);
    }

    void GetKeyUpBack(GameObject go)
    {
        m_CharCtrl.Move(Vector3.zero);
    }
    
    void GetKeyUpLeft(GameObject go)
    {
        m_CharCtrl.Move(Vector3.zero);
    }

    void GetKeyUpRight(GameObject go)
    {
        m_CharCtrl.Move(Vector3.zero);
    }
    #endregion
    #endregion

    #region CombatKey
    #region Key Down
    void GetKeyDownA(GameObject go)
    {
        Debug.Log("Not to do GetGKeyDownA");
    }

    void GetKeyDownB(GameObject go)
    {
        Debug.Log("Not to do GetGKeyDownB");
    }

    #endregion
    #region Key Up
    void GetKeyUpA(GameObject go)
    {
        Debug.Log("Not to do GetGKeyUpA");
    }
    void GetKeyUpB(GameObject go)
    {
        Debug.Log("Not to do GetGKeyUpB");
    }
    #endregion
    #endregion


}

