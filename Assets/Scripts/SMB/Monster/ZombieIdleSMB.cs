using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleSMB : StateMachineBehaviour
{
    const float RAY_START_UP_DISTANCE = 3f;
    [SerializeField]
    LayerMask m_groundLayerMask;

    [SerializeField]
    float m_fMinWanderSec = 0f;

    [SerializeField]
    float m_fMaxWanderSec = 5f;

    [SerializeField]
    float m_fMinWanderDistance = 2f;

    [SerializeField]
    float m_fMaxWanderDistance = 5f;

    ZombieAIController m_zombieAIController = null;
    float m_fStartTime = 0f;
    float m_fDelayTime = 0f;

    Ray         m_ray;
    RaycastHit  m_hitInfo;

    public override void OnStateEnter( Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex )
    {
        m_zombieAIController = animator.GetComponentInParent<ZombieAIController>();

        m_fDelayTime = Random.Range( m_fMinWanderSec, m_fMaxWanderSec );

        m_fStartTime = Time.realtimeSinceStartup;
    }

    public override void OnStateUpdate( Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex )
    {
        if ( Time.realtimeSinceStartup - m_fStartTime >= m_fDelayTime )
        {
            if ( GetRandomWanderPosition( animator.transform ) )
            {
                animator.SetTrigger( INGAMECONST.AnimatorHash.WANDER );
            }
        }
    }

    bool GetRandomWanderPosition( Transform thisTransform )
    {
        float radius = Random.Range(m_fMinWanderDistance,m_fMaxWanderDistance);
        float theta = Random.Range(0f,360f) * Mathf.Deg2Rad;
        float newX = thisTransform.position.x + (radius * Mathf.Cos(theta));
        float newY = thisTransform.position.y;
        float newZ = thisTransform.position.z + (radius * Mathf.Sin(theta));


        m_ray.origin = new Vector3( newX, newY, newZ ) + Vector3.up * RAY_START_UP_DISTANCE;
        m_ray.direction = Vector3.down;

        if ( Physics.Raycast( m_ray, out m_hitInfo, float.MaxValue, m_groundLayerMask.value ) )
        {
            m_zombieAIController.TargetHitInfo = m_hitInfo;
            return true;
        }

        return false;
    }

}
