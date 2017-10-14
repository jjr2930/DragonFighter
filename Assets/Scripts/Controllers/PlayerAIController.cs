using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class controller only aiAnmator(aifsm)
/// aniAnimator is must be controlled by aiAnimator's state like PlayerMoveSMB or PlayerAttackSMB...
/// </summary>
public class PlayerAIController : MonoBehaviour
{
    [SerializeField]
    Animator m_aniAnimator = null;

    [SerializeField]
    Animator m_aiAnimator = null;

    [SerializeField]
    RaycastHit m_targetRaycastHit;

    [SerializeField]
    Transform m_targetTransform;

    JLib.AnimatorParamExtension m_paramContainer = null;

    public Animator AniAnimator
    {
        get { return m_aniAnimator; }
    }

    public RaycastHit TargetRaycastHit
    {
        get 
        { 
            return m_targetRaycastHit; 
        }

        set
        {
            m_paramContainer.SetParameter( INGAMECONST.AnimatorHash.TARGET_RAYCASTHIT , value );
            m_targetRaycastHit = value;
			switch (m_targetRaycastHit.transform.tag)
			{
				case INGAMECONST.Tag.MONSTER:
                    //Debug.Log("Pick Monster");
					m_aiAnimator.SetTrigger(INGAMECONST.AnimatorHash.ATTACK);
					break;

				default:
                    //Debug.Log("Pick Other");
					m_aiAnimator.SetTrigger(INGAMECONST.AnimatorHash.MOVE);
					break;
			}
        }
    }

    public Transform TargetTransform
    {
        get 
        {
            return m_targetTransform;
        }

        set 
        {
            m_paramContainer.SetParameter( INGAMECONST.AnimatorHash.TARGET_TRANSFORM , value );
            m_targetTransform = value;
			//switch (m_targetTransform.tag)
			//{
			//	case INGAMECONST.Tag.MONSTER:
   //                 MonsterAIController monsterAIController = m_targetTransform.GetComponent<MonsterAIController>();
   //                 if(null == monsterAIController)
   //                 {
   //                     Debug.LogErrorFormat("Target does not have MonsterAIController, name : {0}", m_targetTransform.name);
   //                     return;
   //                 }

   //                 MonAIController = monsterAIController;
			//		break;

			//	default:
   //                 MonAIController = null;
			//		break;
			//}
        }
    }

    public MonsterAIController MonAIController { get; set; }

    private void Awake()
    {
        m_paramContainer = GetComponent<JLib.AnimatorParamExtension>();
    }

    /// <summary>
    /// send message to monster(zombie)
    /// "i reached the your detacting range"
    /// </summary>
    /// <param name="other">Other.</param>
    private void OnTriggerEnter( Collider other )
    {
        if ( INGAMECONST.Tag.MONSTER != other.tag )
        { return; }

        JLib.GlobalEventQueue.SendEvent( other.gameObject.GetInstanceID() , IngameEventName.TriggerEnter, this.gameObject);
    }
}
