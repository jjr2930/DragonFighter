using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCinemaSMB : StateMachineBehaviour 
{
    public string cinemaPath = "";
    public string endTriggerName = "";

    Animator animator = null;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );
        this.animator = animator;
        //loadCinema Prefab

        //Add CinemaComplete Method

        //PlayCinema
    }    

    public void OnExitCinema()
    {
        this.animator.SetTrigger(endTriggerName);
    }
}
