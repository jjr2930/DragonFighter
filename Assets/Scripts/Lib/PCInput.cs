using UnityEngine;
using System.Collections;

public class PCInput : MonoBehaviour {
    Configure m_config = null;
	// Use this for initialization
	void Start () {
        m_config = Configure.Instance;	
	}
	
	// Update is called once per frame
	void Update () {

        #region Up Arrow
        if(Input.GetKeyUp(m_config.FWD_KEY))
        {
            JEventSystem.EnqueueEvent(E_VirtualKey.Forward_UP,null);
        }

        if(Input.GetKey(m_config.FWD_KEY))
        {
            JEventSystem.EnqueueEvent(E_VirtualKey.Forward,null);
        }

        if(Input.GetKeyDown(m_config.FWD_KEY))
        {
            JEventSystem.EnqueueEvent(E_VirtualKey.Forward_Down,null);
        }
        #endregion

        #region Down Arrow
        if(Input.GetKeyUp(m_config.BACK_KEY))
        {
            JEventSystem.EnqueueEvent(E_VirtualKey.Down_UP,null);
        }

        if(Input.GetKey(m_config.BACK_KEY))
        {
            JEventSystem.EnqueueEvent(E_VirtualKey.Down,null);
        }

        if(Input.GetKeyDown(m_config.BACK_KEY))
        {
            JEventSystem.EnqueueEvent(E_VirtualKey.Down_Down,null);
        }
        #endregion

        #region Left Arrow
        if( Input.GetKeyUp(m_config.LEFT_KEY))
        {
            JEventSystem.EnqueueEvent(E_VirtualKey.Left_UP,null);
        }

        if(Input.GetKey(m_config.LEFT_KEY))
        {
            JEventSystem.EnqueueEvent(E_VirtualKey.Left,null);
        }

        if(Input.GetKeyDown(m_config.LEFT_KEY))
        {
            JEventSystem.EnqueueEvent(E_VirtualKey.Left_Down,null);
        }
        #endregion

        #region Right Arrow
        if( Input.GetKeyUp( m_config.RIGHT_KEY) )
        {
            JEventSystem.EnqueueEvent( E_VirtualKey.Right_UP, null );
        }

        if( Input.GetKey( m_config.RIGHT_KEY) )
        {
            JEventSystem.EnqueueEvent( E_VirtualKey.Right, null );
        }

        if( Input.GetKeyDown( m_config.RIGHT_KEY ) )
        {
            JEventSystem.EnqueueEvent( E_VirtualKey.Right_Down, null );
        }
        #endregion

        #region A Button

        if( Input.GetKeyUp( m_config.KEY_A) )
        {
            JEventSystem.EnqueueEvent( E_VirtualKey.ButtonA_Up, null );
        }

        if( Input.GetKey( m_config.KEY_A) )
        {
            JEventSystem.EnqueueEvent( E_VirtualKey.ButtonA, null );
        }

        if( Input.GetKeyDown( m_config.KEY_A ) )
        {
            JEventSystem.EnqueueEvent( E_VirtualKey.ButtonA_Down, null );
        }

        #endregion

        #region B Button
          if( Input.GetKeyUp( m_config.KEY_B) )
        {
            JEventSystem.EnqueueEvent( E_VirtualKey.ButtonB_Up, null );
        }

        if( Input.GetKey( m_config.KEY_B) )
        {
            JEventSystem.EnqueueEvent( E_VirtualKey.ButtonB, null );
        }

        if( Input.GetKeyDown( m_config.KEY_B ) )
        {
            JEventSystem.EnqueueEvent( E_VirtualKey.ButtonB_Down, null );
        }
        #endregion 
    }
}
