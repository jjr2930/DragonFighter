using UnityEngine;
using System.Collections;

public class JPlayerAnimatorController : MonoBehaviour {

    Animator m_animator = null;

    float m_fCurSpeed = 0f;
    float m_fCurStrafe = 0f;

    IEnumerator m_Fwditer = null;
    IEnumerator m_Strafeiter = null;
    // Use this for initialization
    void Awake() {
        m_animator = this.GetComponent<Animator>();
    }

    void Start()
    {
        JEventSystem.AddObserver(E_VirtualKey.Forward, ProcessForwardBtn);
        JEventSystem.AddObserver(E_VirtualKey.Back, ProcessBackBtn);
        JEventSystem.AddObserver(E_VirtualKey.Left, ProcessLeftBtn);
        JEventSystem.AddObserver(E_VirtualKey.Right, ProcessRightBtn);

        JEventSystem.AddObserver(E_VirtualKey.Forward_Down, ProcessForwardBtn);
        JEventSystem.AddObserver(E_VirtualKey.Back_Down, ProcessBackBtn);
        JEventSystem.AddObserver(E_VirtualKey.Left_Down, ProcessLeftBtn);
        JEventSystem.AddObserver(E_VirtualKey.Right_Down, ProcessRightBtn);

        JEventSystem.AddObserver(E_VirtualKey.Forward_UP, ProcessFwdBtnUp);
        JEventSystem.AddObserver(E_VirtualKey.Back_UP, ProcessBackBtnUp);
        JEventSystem.AddObserver(E_VirtualKey.Left_UP, ProcessLeftBtnUp);
        JEventSystem.AddObserver(E_VirtualKey.Right_UP, ProcessRightBtnUp);


        JEventSystem.AddObserver(E_VirtualKey.ButtonA_Down, ProcessBtnADown);
        JEventSystem.AddObserver(E_VirtualKey.ButtonB_Down, ProcessBtnBDown);
    }

    #region Direction
    void ProcessForwardBtn(int iInstanceID)
    {
        if (null != m_Fwditer)
        {
            StopCoroutine(m_Fwditer);
            m_Fwditer = null;
        }

        m_animator.applyRootMotion = false;

        m_fCurSpeed += Configure.Instance.ANIM_FWD_ACCEL * Time.deltaTime;
        m_fCurSpeed = Mathf.Clamp(m_fCurSpeed, 0, Configure.Instance.ANIM_FWDSPEED_LIMIT);

        m_animator.SetFloat(Configure.Instance.ANIM_USER_FORWARD, m_fCurSpeed);
    }

    void ProcessBackBtn(int iInstanceID)
    {
        //Debug.Log("Back Btn");
        if (null != m_Fwditer)
        {
            StopCoroutine(m_Fwditer);
            m_Fwditer = null;
        }

        m_animator.applyRootMotion = false;

        m_fCurSpeed -= Configure.Instance.ANIM_BACK_ACCEL * Time.deltaTime;
        m_fCurSpeed = Mathf.Clamp(m_fCurSpeed, Configure.Instance.ANIM_BACKSPEED_LIMIT, 0f);

        m_animator.SetFloat(Configure.Instance.ANIM_USER_FORWARD, m_fCurSpeed);
    }

    void ProcessLeftBtn(int iInstanceID)
    {
        if (null != m_Strafeiter)
        {
            StopCoroutine(m_Strafeiter);
            m_Strafeiter = null;
        }

        m_animator.applyRootMotion = false;

        m_fCurStrafe += Configure.Instance.ANIM_STRAFE_ACCEL * Time.deltaTime;
        m_fCurStrafe = Mathf.Clamp(m_fCurStrafe, 0f, Configure.Instance.ANIM_STRAFE_LIMIT);

        m_animator.SetFloat(Configure.Instance.ANIM_USER_STRAFE, -m_fCurStrafe);
    }

    void ProcessRightBtn(int iInstanceID)
    {
        if (null != m_Strafeiter)
        {
            StopCoroutine(m_Strafeiter);
            m_Strafeiter = null;
        }

        m_animator.applyRootMotion = false;

        m_fCurStrafe += Configure.Instance.ANIM_STRAFE_ACCEL * Time.deltaTime;
        m_fCurStrafe = Mathf.Clamp(m_fCurStrafe, 0f, Configure.Instance.ANIM_STRAFE_LIMIT);

        m_animator.SetFloat(Configure.Instance.ANIM_USER_STRAFE, m_fCurStrafe);
    }

    void ProcessBackBtnUp(int iInstanceID)
    {
        if (null != m_Fwditer)
        {
            StopCoroutine(m_Fwditer);
            m_Fwditer = null;
        }



        m_Fwditer = StopFwdRoutine();
        StartCoroutine(m_Fwditer);
    }

    void ProcessFwdBtnUp(int iInstanceID)
    {
        if (null != m_Fwditer)
        {
            StopCoroutine(m_Fwditer);
            m_Fwditer = null;
        }

        m_Fwditer = StopFwdRoutine();
        StartCoroutine(m_Fwditer);
    }

    void ProcessLeftBtnUp(int iInstanceID)
    {
        if (null != m_Strafeiter)
        {
            StopCoroutine(m_Strafeiter);
            m_Strafeiter = null;
        }

        m_Strafeiter = StopStrafeRoutine();
        StartCoroutine(m_Strafeiter);
    }

    void ProcessRightBtnUp(int iInstanceID)
    {
        if (null != m_Strafeiter)
        {
            StopCoroutine(m_Strafeiter);
            m_Strafeiter = null;
        }

        m_Strafeiter = StopStrafeRoutine();
        StartCoroutine(m_Strafeiter);
    }

    IEnumerator StopFwdRoutine()
    {
        float fSign = Mathf.Sign(m_animator.GetFloat(Configure.Instance.ANIM_USER_FORWARD));
        while (true)
        {
            yield return null;

            m_fCurSpeed -= Configure.Instance.ANIM_STOP_SPEED_ACCEL * Time.deltaTime;
            m_animator.SetFloat(Configure.Instance.ANIM_USER_FORWARD, fSign * m_fCurSpeed);

            if (0.01f >= m_fCurSpeed)
            {
                m_fCurSpeed = 0f;
                m_animator.SetFloat(Configure.Instance.ANIM_USER_FORWARD, 0f);
                yield break;
            }
        }
    }

    IEnumerator StopStrafeRoutine()
    {
        float fSign = Mathf.Sign(m_animator.GetFloat(Configure.Instance.ANIM_USER_STRAFE));
        while (true)
        {
            yield return null;

            m_fCurStrafe -= Mathf.Sign(m_fCurStrafe) * Configure.Instance.ANIM_STOP_SPEED_ACCEL * Time.deltaTime;
            m_animator.SetFloat(Configure.Instance.ANIM_USER_STRAFE, fSign * m_fCurStrafe);

            if (0.01f >= m_fCurStrafe)
            {
                m_fCurStrafe = 0f;
                m_animator.SetFloat(Configure.Instance.ANIM_USER_STRAFE, 0f);
                yield break;
            }
        }
    }
    #endregion

    #region Combat Button

    public void ProcessBtnADown(int iInstanceID)
    {
        ResetAllCombatTrigger();
        m_animator.applyRootMotion = true;
        m_animator.SetTrigger(Configure.Instance.ANIM_USER_BtnA);
    }

    public void ProcessBtnBDown(int iInstanceID)
    {
        ResetAllCombatTrigger();
        m_animator.applyRootMotion = true;
        m_animator.SetTrigger(Configure.Instance.ANIM_USER_BtnB);
    }
    
    public void ResetAllCombatTrigger()
    {
        m_animator.ResetTrigger(Configure.Instance.ANIM_USER_BtnA);
        m_animator.ResetTrigger(Configure.Instance.ANIM_USER_BtnB);
    }

    #endregion

    /// <summary>
    /// 애니메이션 클립에서 이 함수를 호출한다 이 함수는 유저가 공격했다는 이벤트를 뿌려준다.
    /// </summary>
    /// <param name="iAddDmg">기술마다 추가되는 대미지를 파라미터로 받는다</param>
    public void CreateAttackEvent(int iAddDmg)
    {
        Debug.Log("CreateAttackEvent called");
        int dmg = UserData.Instance.TotalDmg + iAddDmg;
        JEventSystem.EnqueueEvent(E_UserAnimEvent.Attack, dmg);
    }
    
}



