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

    public float StartTime;// { get; set; }
    public float Duration;// { get; set; }
    public float LerpTime;

    [SerializeField]
    Vector3 m_vCamCurPos = Vector3.zero;
    [SerializeField]
    Vector3 m_vCamDestPos = Vector3.zero;
    [SerializeField]
    Vector3 m_vCamNextPos = Vector3.zero;

    Vector3 m_vCamLookPos = Vector3.zero;


    // Use this for initialization
    void Start () {
        JEventSystem.AddObserver(E_VirtualKey.Left_Down, ListenLeftRightDown);
        JEventSystem.AddObserver(E_VirtualKey.Right_Down, ListenLeftRightDown);
    }
	

    void Awake()
    {
        m_tPlayer = GameObject.FindWithTag("Player").transform;
        m_vCamCurPos = Camera.main.transform.position;
        Duration = Configure.Instance.TPS_CAM_DURATION;
    }
	// Update is called once per frame
	void Update ()
    {
        m_vCamDestPos = m_tPlayer.position - m_tPlayer.transform.forward * Configure.Instance.TPS_CAM_ZDISTANCE + Configure.Instance.TPS_CAM_LOCATION;
        m_vCamLookPos = m_tPlayer.position + Configure.Instance.TPS_CAM_LOOKPOS;

        LerpTime = (Time.time - StartTime) / Duration;

        m_vCamNextPos = Vector3.Lerp(m_vCamCurPos, m_vCamDestPos, LerpTime);

        Camera.main.transform.position = m_vCamNextPos;
        this.transform.LookAt(m_vCamLookPos);
    }

    public void ListenLeftRightDown(int num)
    {
        Debug.Log("TPSCamera ==> Left or Right Down");
        m_vCamCurPos = Camera.main.transform.position;
        StartTime = Time.time;
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
