using UnityEngine;
using System.Collections;

public class ParticleNode : MonoBehaviour
{
    ParticleSystem m_pc = null;
    
    public bool IsOutOfPool { get;set;}
    void Start()
    {
        m_pc = this.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(IsBackToPool())
        {
            DoWhenReturnToPool();
            ReturnToPool();
        }
    }

    void ReturnToPool()
    {
        StopParticle();
        IsOutOfPool = false;
    }

    void StopParticle()
    {
        m_pc.Stop(true);
    }
    

    virtual protected bool IsBackToPool()
    {
        return false;
    }

    virtual protected void DoWhenReturnToPool()
    {

    }

    virtual protected void OnStart()
    {

    }

    virtual protected void OnUpdate()
    {


    }
}
