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
    RaycastHit m_movePoint;

    [SerializeField]
    Transform m_targetTransform;

    public Animator AniAnimator
    {
        get { return m_aniAnimator; }
    }

    public RaycastHit MovePoint
    {
        get { return m_movePoint; }
        set
        {
            m_movePoint = value;
			switch (m_movePoint.transform.tag)
			{
				case INGAMECONST.Tag.MONSTER:
                    Debug.Log("Pick Monster");
					m_aiAnimator.SetTrigger(INGAMECONST.AnimatorHash.ATTACK);
					break;

				default:
                    Debug.Log("Pick Other");
					m_aiAnimator.SetTrigger(INGAMECONST.AnimatorHash.MOVE);
					break;
			}
        }
    }

    public Transform TargetTransform
    {
        get { return m_targetTransform; }
        set 
        {
            m_targetTransform = value;
			switch (m_targetTransform.tag)
			{
				case INGAMECONST.Tag.MONSTER:
                    MonsterAIController monsterAIController = m_targetTransform.GetComponent<MonsterAIController>();
                    if(null == monsterAIController)
                    {
                        Debug.LogErrorFormat("Target does not have MonsterAIController, name : {0}", m_targetTransform.name);
                        return;
                    }

                    MonAIController = monsterAIController;
					break;

				default:
                    MonAIController = null;
					break;
			}
        }
    }

    //public void PickSometing(Transform _something)
    //{
    //    switch (m_targetTransform.tag)
    //    {
    //        case INGAMECONST.Tag.MONSTER:
    //            MonsterAIController monsterAIController = m_targetTransform.GetComponent<MonsterAIController>();
    //            m_aniAnimator.SetTrigger(INGAMECONST.AnimatorHash.ATTACK);
    //            break;

    //        default:
    //            MonAIController = null;
    //            break;
    //    }
    //}

    public MonsterAIController MonAIController { get; set; }
}
