using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {

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

    }

    void ProcessForwardBtn(GameObject go)
    {
        if (null != m_Fwditer)
        {
            StopCoroutine(m_Fwditer);
            m_Fwditer = null;
        }

        m_fCurSpeed += Configure.Instance.PLAYER_FWD_ACCEL * Time.deltaTime;
        m_fCurSpeed = Mathf.Clamp(m_fCurSpeed, 0, Configure.Instance.PLAYER_FWDSPEED_LIMIT);

        m_animator.SetFloat(Configure.Instance.ANIM_FORWARD, m_fCurSpeed);
    }

    void ProcessBackBtn(GameObject go)
    {
        if (null != m_Fwditer)
        {
            StopCoroutine(m_Fwditer);
            m_Fwditer = null;
        }

        m_fCurSpeed += Configure.Instance.PLAYER_BACK_ACCEL * Time.deltaTime;
        m_fCurSpeed = Mathf.Clamp(m_fCurSpeed, 0, Configure.Instance.PLAYER_BACKSPEED_LIMIT);

        m_animator.SetFloat(Configure.Instance.ANIM_FORWARD, -m_fCurSpeed);
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

    void ProcessLeftBtn(GameObject go)
    {
        if(null != m_Strafeiter)
        {
            StopCoroutine(m_Strafeiter);
            m_Strafeiter = null;
        }

        m_fCurStrafe += Configure.Instance.PLAYER_STRAFE_ACCEL * Time.deltaTime;
        m_fCurStrafe = Mathf.Clamp(m_fCurStrafe, Configure.Instance.PLAYER_STRAFE_ACCEL, 0f);

        m_animator.SetFloat(Configure.Instance.ANIM_STRAFE, -m_fCurStrafe);
    }

    void ProcessRightBtn(GameObject go)
    {
        if(null != m_Strafeiter)
        {
            StopCoroutine(m_Strafeiter);
            m_Strafeiter = null;
        }

        m_fCurStrafe += Configure.Instance.PLAYER_STRAFE_ACCEL * Time.deltaTime;
        m_fCurStrafe = Mathf.Clamp(m_fCurStrafe, Configure.Instance.PLAYER_STRAFE_ACCEL, 0f);

        m_animator.SetFloat(Configure.Instance.ANIM_STRAFE, m_fCurStrafe);
    }
    
    void ProcessLeftBtnUp(GameObject go)
    {
        if(null != m_Strafeiter)
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
        while(true)
        {
            yield return null;
            
            m_fCurSpeed -= Configure.Instance.PLAYER_STOP_SPEED_ACCEL * Time.deltaTime;
            m_animator.SetFloat(Configure.Instance.ANIM_FORWARD, fSign * m_fCurSpeed);

            if(0.01f >= m_fCurSpeed)
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
            
            m_fCurStrafe -= Mathf.Sign(m_fCurStrafe) * Configure.Instance.PLAYER_STOP_SPEED_ACCEL * Time.deltaTime;
            m_animator.SetFloat(Configure.Instance.ANIM_FORWARD, fSign * m_fCurStrafe);

            if (0.01f >= m_fCurStrafe)
            {
                m_fCurStrafe = 0f;
                m_animator.SetFloat(Configure.Instance.ANIM_FORWARD, 0f);
                yield break;
            }
        }
    }
}
