using UnityEngine;
using System.Collections;

public class JAnimatorController : MonoBehaviour {

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
        JEventSystem.AddObserver(E_VirtualKey.ButtonB_Down, ProcessBtnADown);
    }

    #region Direction
    void ProcessForwardBtn(GameObject go)
    {
        if (null != m_Fwditer)
        {
            StopCoroutine(m_Fwditer);
            m_Fwditer = null;
        }

        m_fCurSpeed += Configure.Instance.ANIM_FWD_ACCEL * Time.deltaTime;
        m_fCurSpeed = Mathf.Clamp(m_fCurSpeed, 0, Configure.Instance.ANIM_FWDSPEED_LIMIT);

        m_animator.SetFloat(Configure.Instance.ANIM_FORWARD, m_fCurSpeed);
    }

    void ProcessBackBtn(GameObject go)
    {
        Debug.Log("Back Btn");
        if (null != m_Fwditer)
        {
            StopCoroutine(m_Fwditer);
            m_Fwditer = null;
        }

        m_fCurSpeed -= Configure.Instance.ANIM_BACK_ACCEL * Time.deltaTime;
        m_fCurSpeed = Mathf.Clamp(m_fCurSpeed, Configure.Instance.ANIM_BACKSPEED_LIMIT, 0f);

        m_animator.SetFloat(Configure.Instance.ANIM_FORWARD, m_fCurSpeed);
    }

    void ProcessLeftBtn(GameObject go)
    {
        if (null != m_Strafeiter)
        {
            StopCoroutine(m_Strafeiter);
            m_Strafeiter = null;
        }

        m_fCurStrafe += Configure.Instance.ANIM_STRAFE_ACCEL * Time.deltaTime;
        m_fCurStrafe = Mathf.Clamp(m_fCurStrafe, 0f, Configure.Instance.ANIM_STRAFE_LIMIT);

        m_animator.SetFloat(Configure.Instance.ANIM_STRAFE, -m_fCurStrafe);
    }

    void ProcessRightBtn(GameObject go)
    {
        if (null != m_Strafeiter)
        {
            StopCoroutine(m_Strafeiter);
            m_Strafeiter = null;
        }

        m_fCurStrafe += Configure.Instance.ANIM_STRAFE_ACCEL * Time.deltaTime;
        m_fCurStrafe = Mathf.Clamp(m_fCurStrafe, 0f, Configure.Instance.ANIM_STRAFE_LIMIT);

        m_animator.SetFloat(Configure.Instance.ANIM_STRAFE, m_fCurStrafe);
    }

    void ProcessBackBtnUp(GameObject go)
    {
        if (null != m_Fwditer)
        {
            StopCoroutine(m_Fwditer);
            m_Fwditer = null;
        }

        m_Fwditer = StopFwdRoutine();
        StartCoroutine(m_Fwditer);
    }

    void ProcessFwdBtnUp(GameObject go)
    {
        if (null != m_Fwditer)
        {
            StopCoroutine(m_Fwditer);
            m_Fwditer = null;
        }

        m_Fwditer = StopFwdRoutine();
        StartCoroutine(m_Fwditer);
    }

    void ProcessLeftBtnUp(GameObject go)
    {
        if (null != m_Strafeiter)
        {
            StopCoroutine(m_Strafeiter);
            m_Strafeiter = null;
        }

        m_Strafeiter = StopStrafeRoutine();
        StartCoroutine(m_Strafeiter);
    }

    void ProcessRightBtnUp(GameObject go)
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
        float fSign = Mathf.Sign(m_animator.GetFloat(Configure.Instance.ANIM_FORWARD));
        while (true)
        {
            yield return null;

            m_fCurSpeed -= Configure.Instance.ANIM_STOP_SPEED_ACCEL * Time.deltaTime;
            m_animator.SetFloat(Configure.Instance.ANIM_FORWARD, fSign * m_fCurSpeed);

            if (0.01f >= m_fCurSpeed)
            {
                m_fCurSpeed = 0f;
                m_animator.SetFloat(Configure.Instance.ANIM_FORWARD, 0f);
                yield break;
            }
        }
    }

    IEnumerator StopStrafeRoutine()
    {
        float fSign = Mathf.Sign(m_animator.GetFloat(Configure.Instance.ANIM_STRAFE));
        while (true)
        {
            yield return null;

            m_fCurStrafe -= Mathf.Sign(m_fCurStrafe) * Configure.Instance.ANIM_STOP_SPEED_ACCEL * Time.deltaTime;
            m_animator.SetFloat(Configure.Instance.ANIM_STRAFE, fSign * m_fCurStrafe);

            if (0.01f >= m_fCurStrafe)
            {
                m_fCurStrafe = 0f;
                m_animator.SetFloat(Configure.Instance.ANIM_STRAFE, 0f);
                yield break;
            }
        }
    }
    #endregion

    #region Combat Button

    public void ProcessBtnADown(GameObject go)
    {
        ResetAllCombatTrigger();
        m_animator.SetTrigger(Configure.Instance.ANIM_BtnA);
    }

    public void ProcessBtnBDown(GameObject go)
    {
        ResetAllCombatTrigger();
        m_animator.SetTrigger(Configure.Instance.ANIM_BtnB);
    }
    
    public void ResetAllCombatTrigger()
    {
        m_animator.SetTrigger(Configure.Instance.ANIM_BtnA);
        m_animator.SetTrigger(Configure.Instance.ANIM_BtnB);
    }

    #endregion
}



