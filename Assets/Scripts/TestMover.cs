using UnityEngine;
using System.Collections;

public class TestMover : MonoBehaviour {

    [SerializeField]
    float m_fAccel = 0.5f;
    [SerializeField]
    float m_fReduceAccel = 1f;

    float m_fFwdSpeed = 0f;
    float m_fFwdLimit = 1f;
    
    IEnumerator m_itor = null;

    Animator m_anim = null;


	// Use this for initialization
	void Start () {
	    //get anim
        if( null == m_anim )
        {
            m_anim = GameObject.FindWithTag( "Player" ).GetComponent<Animator>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.UpArrow))
        {
            //if decrease speed, stop coroutine   
            if(null != m_itor)
            {
                StopCoroutine(m_itor);
            }
            
            m_fFwdSpeed += m_fAccel * Time.deltaTime;
            m_fFwdSpeed = Mathf.Clamp( m_fFwdSpeed , 0f , 1f );

            m_anim.SetFloat("Speed",m_fFwdSpeed);
        }

        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            m_itor = DecreseSpeed();
            StartCoroutine(m_itor);
        }
	}

    IEnumerator DecreseSpeed()
    {
        while( true )
        {
            yield return null;
            m_fFwdSpeed -= m_fReduceAccel * Time.deltaTime ;
            
            m_anim.SetFloat("Speed",m_fFwdSpeed);

            if(0f>= m_fFwdSpeed)
            {
                m_fFwdSpeed = 0f;
                yield break;
            }
        }
    }
}
