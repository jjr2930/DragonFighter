using UnityEngine;
using System.Collections;

public class IngameUI : MonoBehaviour {

    [SerializeField]
    E_VirtualKey m_eVirtualBtnEvent;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateBtnEvent()
    {
        JEventSystem.EnqueueEvent( m_eVirtualBtnEvent , GetInstanceID() );
    }
}
