using UnityEngine;
using System.Collections;

public class ZombieEventMaker : MonoBehaviour {

	// Use this for initialization

    Transform       m_tPlayer   = null;
    NavMeshAgent    m_agent     = null;
    IEnumerator     m_itor      = null;
    ZombieData      m_data      = null;

    [SerializeField]
    float m_fIntervalTime = 1f;
    


    public float IntervalTime
    {
        get
        {
            return m_fIntervalTime;
        }
        set
        {
            m_fIntervalTime = value;
        }
    }

	void Start ()
    {
	    m_tPlayer   = GameObject.FindWithTag(Configure.Instance.TAG_PLAYER).transform;
        m_agent     = this.GetComponent<NavMeshAgent>(); 
        m_data      = this.GetComponent<ZombieData>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch(m_agent.pathStatus)
        {
            case NavMeshPathStatus.PathComplete:
                JStopCoroutine(m_itor);
                m_itor = CreateAttackEvent(m_fIntervalTime);
                StartCoroutine(m_itor);
                break;
                 
            case NavMeshPathStatus.PathPartial:
                JStopCoroutine(m_itor);
                JEventSystem.EnqueueEvent((m_data.Type == E_ZombieType.Walk)
                                            ? E_ZombieAnimEvent.Walk 
                                            : E_ZombieAnimEvent.Run,
                                            GetInstanceID());
                break;

            case NavMeshPathStatus.PathInvalid:
                JStopCoroutine(m_itor);
                JEventSystem.EnqueueEvent(E_ZombieAnimEvent.Idle,GetInstanceID());
                break;
        }
        
	}

    void JStopCoroutine(IEnumerator itor)
    {
        if(null  != m_itor)
        {
            StopCoroutine(m_itor);
        }
    }

    IEnumerator CreateAttackEvent(float fInterval)
    {
        while(true)
        {
            JEventSystem.EnqueueEvent(E_ZombieAnimEvent.Attack, GetInstanceID());
            yield return fInterval;
        }
    }
    

}
