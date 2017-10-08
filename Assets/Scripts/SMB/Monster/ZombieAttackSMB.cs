using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackSMB : StateMachineBehaviour
{
    ZombieAIController m_zombieAIController = null;
    Animator m_aniAnimator = null;

    public override void OnStateEnter( Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex )
    {
        m_zombieAIController = animator.GetComponentInParent<ZombieAIController>();
        m_aniAnimator = animator.GetComponentInParent<Animator>();

        int randomIndex = Random.Range(0,3);
        int triggerHash = 0;
        switch ( randomIndex )
        {
            case 0:
                triggerHash = INGAMECONST.AnimatorHash.ZOMBIE_ATTACK1;
                break;

            case 1:
                triggerHash = INGAMECONST.AnimatorHash.ZOMBIE_ATTACK2;
                break;

            case 2:
                triggerHash = INGAMECONST.AnimatorHash.ZOMBIE_ATTACK3;
                break;

            default:
                break;
        }

        m_aniAnimator.SetTrigger( triggerHash );
    }
}
