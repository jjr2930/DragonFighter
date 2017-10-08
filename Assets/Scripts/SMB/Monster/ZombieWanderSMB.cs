using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieWanderSMB : StateMachineBehaviour
{
    [SerializeField]
    float               m_fStopDistance         = 1f;

    NavMeshAgent        m_navAgent              = null;
    ZombieAIController  m_zombieAIController    = null;
    public override void OnStateEnter( Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex )
    {
        m_navAgent = animator.GetComponentInParent<NavMeshAgent>();
        m_zombieAIController = animator.GetComponentInChildren<ZombieAIController>();

        m_navAgent.SetDestination( m_zombieAIController.TargetHitInfo.point );
    }

    public override void OnStateUpdate( Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex )
    {
        if(m_navAgent.remainingDistance <= m_navAgent.stoppingDistance)
        {
            animator.SetTrigger( INGAMECONST.AnimatorHash.COMPLETE );
        }
    }
}
