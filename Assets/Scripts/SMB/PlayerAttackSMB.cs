using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSMB : StateMachineBehaviour {
    PlayerAIController m_playerAIController = null;
    Animator m_aniAnimator = null;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if (null == m_playerAIController)
        {
            m_playerAIController = animator.GetComponentInParent<PlayerAIController>();
        }

        if(null == m_aniAnimator)
        {
            m_aniAnimator = m_playerAIController.AniAnimator;
        }

        int randomNumber = Random.Range(0, 2);

        m_aniAnimator.SetInteger(INGAMECONST.AnimatorHash.ATTACK_TYPE,randomNumber);
        m_aniAnimator.SetTrigger(INGAMECONST.AnimatorHash.ATTACK);
    }
}
