using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTriggerSMB : StateMachineBehaviour{
    [SerializeField]
    List<string> triggerNames = new List<string>();

    List<int> triggerHashs = new List<int>();
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if( 0 == triggerHashs.Count )
        {
            for (int i = 0; i < triggerNames.Count; i++)
            {
                triggerHashs.Add(Animator.StringToHash(triggerNames[i]));
            }
        }

        for (int i = 0; i < triggerHashs.Count; i++)
        {
            animator.ResetTrigger(triggerHashs[i]);
        }
    }
}
