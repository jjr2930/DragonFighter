using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IngameEventParameters;

public class EnterCinemaSMB : StateMachineBehaviour 
{
    Animator m_animator = null;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ZombieSpawner.IsCanSpawn = false;
        m_animator = animator;

        NoticeEventParameter noticeEventParameter = new NoticeEventParameter();
        noticeEventParameter.m_eKey = JLib.LocalizeKey.SurviveFromTheZombie;
        noticeEventParameter.m_callback = OnCinemaCompleteMethod;

        JLib.GlobalEventQueue.SendEvent(JLib.GlobalEventQueue.GLOBAL_ID, IngameEventName.Enter_EnterCinema, noticeEventParameter);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ZombieSpawner.IsCanSpawn = true;
    }

    public void OnCinemaCompleteMethod()
    {
        m_animator.SetTrigger(INGAMECONST.AnimatorHash.LOOP);
    }
}
