using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMoveSMB : StateMachineBehaviour {
    [SerializeField]
    float               m_fStopDistance = 1f;

    PlayerAIController  m_aiController  = null;
    NavMeshAgent        m_navAgent      = null;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if(null == m_aiController)
        {
            m_aiController = animator.GetComponentInParent<PlayerAIController>();
        }

        if(null == m_navAgent)
        {
            m_navAgent = animator.GetComponentInParent<NavMeshAgent>();
        }

		m_navAgent.stoppingDistance = m_fStopDistance;
		m_navAgent.SetDestination(m_aiController.TargetRaycastHit.point);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (m_navAgent.remainingDistance <= m_navAgent.stoppingDistance )
        {
            //Debug.Log("Pathfind and move Complete");
            animator.SetTrigger(INGAMECONST.AnimatorHash.COMPLETE);
        }
    }


}
