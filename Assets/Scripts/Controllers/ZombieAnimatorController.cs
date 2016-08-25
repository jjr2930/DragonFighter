using UnityEngine;
using System.Collections;

public class ZombieAnimatorController : MonoBehaviour
{
    [SerializeField]
    Animator m_animator = null;
    
    ZombieData m_jd = null;

    [SerializeField]
    int     m_iInstanceID = 0;
    public void Awake()
    {
       
    }

    public void Start()
    {
        m_animator = this.GetComponent<Animator>();
        m_iInstanceID = this.GetInstanceID();
        m_jd = this.GetComponent<ZombieData>();
    }
    
    /// <summary>
    /// parameter is damage
    /// </summary>
    /// <param name="iDmg">dmg</param>
    public void GetHitEvent(int iDmg)
    {
        GameObject player = GameObject.FindWithTag(Configure.Instance.TAG_PLAYER);

        Transform t = player.transform;

        float SqrDistance = (t.position - this.transform.position).sqrMagnitude;

        if(SqrDistance <= Mathf.Pow(Configure.Instance.PLAYER_ATTACK_RANGE, 2))
        {
            m_jd.HP -= iDmg;
            m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_HIT);
        }
    }

    public void GetIdleEvent( int number )
    {
        if(m_iInstanceID != number)
        {
            return;
        }
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_IDLE);
    }
    
    public void GetWalkEvent(int number)
    {
        if(m_iInstanceID != number)
        {
            return;
        }
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_WALK);
    }

    public void GetRunEvent(int number)
    {
        if(m_iInstanceID != number)
        {
            return;
        }
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_RUN);
    }

    public void GetScreamEvent(int number)
    {
        if(m_iInstanceID != number)
        {
            return;
        }
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_SCREAM);
    }

    public void GetAttackEvent(int number)
    {
        if(m_iInstanceID != number)
        {
            return;
        }
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMIBE_ATTACK);
    }

    public void GetBiteEvent(int number)
    {
        if(m_iInstanceID != number)
        {
            return;
        }
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_BITE);
    }

    public void GetNeckBiteEvent(int number)
    {
        if(m_iInstanceID != number)
        {
            return;
        }
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_NECKBITE);
    }

    public void GetDeathBackEvent(int number)
    {
        if(m_iInstanceID != number)
        {
            return;
        }
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_DEATH_BCK);
    }

    public void GetDeathFwdEvent(int number)
    {
        if(m_iInstanceID != number)
        {
            return;
        }
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_DEATH_FWD);
    }
}
