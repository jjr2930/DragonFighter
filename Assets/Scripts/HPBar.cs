using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using IngameEventParameters;
[UnityEngine.RequireComponent( typeof( Slider ) )]
public class HPBar : MonoBehaviour
{
    [SerializeField]
    long m_lId = 0L;

    [SerializeField]
    Slider m_slider = null;

    bool m_bisAppQuit = false;

    UnityEvent<object> m_hpEvent;
    public long Id{
        get{
            return m_lId;
        }

        set
        {
            if(value == long.MinValue)
            {
                Debug.LogErrorFormat( "id can not be long.Min({0})" , long.MinValue );
                return;
            }

            m_lId = value;
        }
    }

    protected void Awake()
    {
        m_slider = GetComponent<Slider>();
        m_hpEvent.AddListener( HPChange );
    }

    private void OnDestroy()
    {
        if ( !m_bisAppQuit )
        {
            JLib.GlobalEventQueue.AddListener( m_lId , IngameEventName.HPChange , m_hpEvent );
        }
    }

    private void OnApplicationQuit()
    {
        m_bisAppQuit = true;
    }

    public void HPChange(long m_)
    {
        ChangeHPParameter hpParameter = param as ChangeHPParameter;

        if(hpParameter.m_lMaxHP == 0)
        {
            Debug.LogErrorFormat("Max hp is not be 0");
            return;
        }
        float fCurrentHP = hpParameter.m_lCurrentHP;
        float fMaxHP = hpParameter.m_lMaxHP;
        m_slider.value = fCurrentHP / fMaxHP;
    }


}
