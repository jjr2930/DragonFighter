using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackSMB : StateMachineBehaviour
{
    ZombieAIController m_zombieAIController = null;
    Transform m_targetTransform = null;
    Animator m_aniAnimator = null;
    JLib.AnimatorParamExtension m_parameterContainer = null;

    public override void OnStateEnter( Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex )
    {
        m_zombieAIController = animator.GetComponentInParent<ZombieAIController>();
        m_aniAnimator = m_zombieAIController.GetComponent<Animator>();
        m_parameterContainer = animator.GetComponentInParent<JLib.AnimatorParamExtension>();
        m_targetTransform = m_parameterContainer.GetParameter<Transform>( INGAMECONST.AnimatorHash.TARGET_TRANSFORM );

        int triggerHash = INGAMECONST.AnimatorHash.ZOMBIE_ATTACK1;
        Debug.Log("Zombie ani animator name : " + m_aniAnimator.name);
        m_aniAnimator.SetTrigger( triggerHash );

    }

    public override void OnStateUpdate( Animator animator , AnimatorStateInfo stateInfo , int layerIndex )
    {
        base.OnStateUpdate( animator , stateInfo , layerIndex );

    }

}
