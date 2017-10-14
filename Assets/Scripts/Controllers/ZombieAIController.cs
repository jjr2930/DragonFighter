using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAIController : JMonoBehaviour, ITargetInfo
{
    [SerializeField]
    Animator m_zombieAIFSM = null;

    Transform m_tTargetTransform = null;
    RaycastHit m_targetHitInfo;
    JLib.AnimatorParamExtension m_paramContainer = null;
    public Transform TargetTransform
    {
        get { return m_tTargetTransform; }
        set
        {
            m_paramContainer.SetParameter( INGAMECONST.AnimatorHash.TARGET_TRANSFORM , value );
            m_tTargetTransform = value;
            m_zombieAIFSM.SetTrigger( INGAMECONST.AnimatorHash.ATTACK );
        }
    }

    public RaycastHit TargetHitInfo
    {
        get { return m_targetHitInfo; }
        set
        {
            m_paramContainer.SetParameter(INGAMECONST.AnimatorHash.TARGET_RAYCASTHIT, value);
            m_targetHitInfo = value;
            m_zombieAIFSM.SetTrigger( INGAMECONST.AnimatorHash.WANDER );
        }
    }


    protected override void Awake()
    {
        base.Awake();
        m_paramContainer = GetComponent<JLib.AnimatorParamExtension>();
    }

    /// <summary>
    /// when player is out of range, set to move
    /// </summary>
    /// <param name="other">Other.</param>
    public void OnTriggerExit(Collider other)
    {
        if ( INGAMECONST.Tag.PLAYER != other.tag )
        { return; }

        m_zombieAIFSM.SetTrigger( INGAMECONST.AnimatorHash.MOVE );
    }

    /// <summary>
    /// Enters the player.
    /// </summary>
    /// <param name="param">Parameter.</param>
    public void EnterPlayer(object param)
    {
        GameObject goPlayer = param as GameObject;
        if(INGAMECONST.Tag.PLAYER != goPlayer.tag )
        { return; }

        TargetTransform = goPlayer.transform;
    }
}
