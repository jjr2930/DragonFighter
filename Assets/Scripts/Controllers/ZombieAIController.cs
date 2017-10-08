using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAIController : MonsterAIController
{
    [SerializeField]
    Animator m_zombieAIFSM = null;

    Transform m_tTargetTransform = null;
    RaycastHit m_targetHitInfo;
    
    public Transform TargetTransform
    {
        get { return m_tTargetTransform; }
        set
        {
            m_tTargetTransform = value;
            m_zombieAIFSM.SetTrigger( INGAMECONST.AnimatorHash.MOVE );
        }
    }

    public RaycastHit TargetHitInfo
    {
        get { return m_targetHitInfo; }
        set
        {
            m_targetHitInfo = value;
            m_zombieAIFSM.SetTrigger( INGAMECONST.AnimatorHash.WANDER );
        }
    }

    private void OnCollisionEnter( Collision collision )
    {
        switch(collision.transform.tag)
        {
            case INGAMECONST.Tag.PLAYER:
                TargetTransform = collision.transform;
                break;

            default:
                Debug.LogFormat( "{0} is not supported yet", collision.transform.tag );
                break;
        }
    }
}
