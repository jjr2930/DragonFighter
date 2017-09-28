using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAnimatorController : MonoBehaviour
{
    Animator animator = null;
    // Use this for initialization
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetTrigger(string triggerName)
    {
        animator.SetTrigger( triggerName );
    }
}
