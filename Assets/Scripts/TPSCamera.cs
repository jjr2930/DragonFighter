using UnityEngine;
using System.Collections;

public class TPSCamera : MonoSingle<TPSCamera> {
    public enum E_CamPos : int
    {
        Idle,
        Walk,
        Run
    }

    [SerializeField] Transform m_tPlayer = null;

    float m_fCamMoveDuration = 1f;

    IEnumerator m_Itor = null;
    // Use this for initialization
    void Start () {
	}
	

    void Awake()
    {
        m_tPlayer = GameObject.FindWithTag("Player").transform;
      
        //JEventSystem.AddObserver(E_UserAnimEvent.Idle, IdlePosObserver);
        //JEventSystem.AddObserver(E_UserAnimEvent.Run, RunPosObserver);
        //JEventSystem.AddObserver(E_UserAnimEvent.Walk, WalkPosObserver);
    }
	// Update is called once per frame
	void Update ()
    {
        Vector3 camPos = Configure.Instance.TPS_CAM_LOCATION;
        Vector3 camLookPos = Configure.Instance.TPS_CAM_LOOKPOS;
        this.transform.position = m_tPlayer.position + camPos;
        this.transform.LookAt(m_tPlayer.position + camLookPos);
    }

    //IEnumerator JobMoveCamPos(E_CamPos ePosition, Transform LookTarget, float fDuration)
    //{
    //    Vector3 vStartPos = this.transform.position;
    //    Vector3 vEndPos = (E_CamPos.Idle == ePosition) ? Configure.Instance.TPS_CAM_IDLE_POS :
    //                        (E_CamPos.Walk == ePosition) ? Configure.Instance.TPS_CAM_WALK_POS:
    //                                                        Configure.Instance.TPS_CAM_RUN_POS;
    //    vEndPos += LookTarget.position;

    //    Vector3 vLookPos = Configure.Instance.TPS_CAM_LOOKPOS;

    //    float fDuringTime = 0f;

    //    while(fDuringTime < fDuration)
    //    {
    //        this.transform.position = Vector3.Lerp(vStartPos,vEndPos, fDuringTime/fDuration);
    //        this.transform.LookAt(LookTarget.position + vLookPos);
    //        fDuringTime += Time.deltaTime;

    //        yield return null;
    //    }

    //    this.transform.position = vEndPos;
    //    this.transform.LookAt(LookTarget.position + vLookPos);
    //}

    //public void RunPosObserver(int iInstanceID)
    //{
    //    if(null != m_Itor)
    //    {
    //        StopCoroutine(m_Itor);
    //    }

    //    m_Itor = JobMoveCamPos(E_CamPos.Run, m_tPlayer, m_fCamMoveDuration);
    //    StartCoroutine(m_Itor);
    //}

    //public void WalkPosObserver(int iInstanceID)
    //{
    //    if(null != m_Itor)
    //    {
    //        StopCoroutine(m_Itor);
    //    }

    //    m_Itor = JobMoveCamPos(E_CamPos.Walk, m_tPlayer, m_fCamMoveDuration);
    //    StartCoroutine(m_Itor);
    //}

    //public void IdlePosObserver(int iInstanceID)
    //{
    //    if(null != m_Itor)
    //    {
    //        StopCoroutine(m_Itor);
    //    }

    //    m_Itor = JobMoveCamPos( E_CamPos.Idle, m_tPlayer , m_fCamMoveDuration );
    //    StartCoroutine( m_Itor );
    //}


}
