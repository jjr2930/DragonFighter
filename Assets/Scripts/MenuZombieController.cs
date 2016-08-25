using UnityEngine;
using System.Collections;

public class MenuZombieController : MonoBehaviour
{
    string[] triggers =
    {
        "Scream",
        "Attack",
        "NeckBite",
        "Idle",
    };

    Animator animator = null;
    IEnumerator itor = null;
	// Use this for initialization
	void Awake()
    {
        animator = this.GetComponent<Animator>();
        itor = CreateAnimTrigger();
        StartCoroutine(itor);
	}   
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDistroy()
    {
        StopCoroutine(itor);
    }

    IEnumerator CreateAnimTrigger()
    {
        while(true)
        {
            int random = Random.Range(0, triggers.Length);
            animator.SetTrigger(triggers[random]);
            yield return new WaitForSeconds(2f);
        }
    }
}
