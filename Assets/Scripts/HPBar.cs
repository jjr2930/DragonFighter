using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using IngameEventParameters;

[UnityEngine.RequireComponent( typeof( Slider ) )]
public class HPBar : JLib.JPoolObject
{
    /// <summary>
    /// for debuging in editor
    /// </summary>
    [SerializeField]
    Transform m_tOwner;

    [SerializeField]
    Slider m_slider = null;

    [SerializeField]
    Text m_txt = null;

    bool m_bisAppQuit = false;

    Camera m_mainCamera = null;

    Transform m_tHPSpawnPoint = null;

    public Transform Owner
    {
        set
        {
            m_tOwner = value;
            m_tHPSpawnPoint = m_tOwner.Find( INGAMECONST.SpecialObjectConst.HP_SPAWN_POINT_NAME );
        }
    }

    public string Text
    {
        get
        {
            return m_txt.text;
        }

        set
        {
            m_txt.text = value;
        }
    }

    public float Percent
    {
        get
        {
            return m_slider.value;
        }

        set
        {
            m_slider.value = value;
        }
    }

    public void OnEnable()
    {
        m_mainCamera = Camera.main;
    }

    public void Update()
    {
        Vector2 vTargetScreenPosition = m_mainCamera.WorldToScreenPoint( m_tHPSpawnPoint.position );
        this.transform.position = vTargetScreenPosition;
    }
}
