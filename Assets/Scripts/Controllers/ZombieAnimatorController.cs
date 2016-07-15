using UnityEngine;
using System.Collections;

public class ZombieAnimatorController : MonoBehaviour
{
    [SerializeField]
    Animator m_animator = null;

    public void Awake()
    {
        m_animator = this.GetComponent<Animator>();
    }

    
    public void GetIdleEvent( int number )
    {
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_IDLE);
    }
    
    public void GetWalkEvent(int num)
    {
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_WALK);
    }

    public void GetRunEvent(int number)
    {
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_RUN);
    }

    public void GetScreamEvent(int number)
    {
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_SCREAM);
    }

    public void GetAttackEvent(int number)
    {
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMIBE_ATTACK);
    }

    public void GetBiteEvent(int Number)
    {
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_BITE);
    }

    public void GetNeckBiteEvent(int number)
    {
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_NECKBITE);
    }

    public void GetDeathBackEvent(int number)
    {
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_DEATH_BCK);
    }

    public void GetDeathFwdEvent(int number)
    {
        m_animator.SetTrigger(Configure.Instance.ANIM_ZOMBIE_DEATH_FWD);
    }
}
