using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IngameEventParameters;
using AssetBundles;
public class HpBarController : JMonoBehaviour
{
    Camera m_camMainCamera = null;
    Dictionary<long , HPBar> m_dicHPBars = new Dictionary<long , HPBar>();

    protected override void Awake()
    {
        base.Awake();
   
        m_camMainCamera = Camera.main; 
    }
        
    public void CreateHPBar(object param)
    {
        HPParameter hpParameter = param as HPParameter;

        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint( Camera.main , hpParameter.m_tOwnerTransform.position );
        HPBar foundedHPbar = JLib.JObjectPool.Instance.GetPoolObject<HPBar>( JLib.JPoolKey.HPBar );

        foundedHPbar.transform.parent = this.transform;
        foundedHPbar.transform.position = screenPoint;
        foundedHPbar.Owner = hpParameter.m_tOwnerTransform;

        m_dicHPBars.Add( hpParameter.m_tOwnerTransform.gameObject.GetInstanceID() , foundedHPbar );

        ChangeHP(param);
    }

    public void ChangeHP(object param)
    {
        HPParameter hpParameter = param as HPParameter;

        long lId = hpParameter.m_tOwnerTransform.gameObject.GetInstanceID();
        long lMaxHP = hpParameter.m_lMaxHP;
        long lCurrentHP = hpParameter.m_lCurrentHP;

        RefreshHPBar( lMaxHP , lCurrentHP , m_dicHPBars[ lId ] );
    }

    private void RefreshHPBar( long _lMaxHP , long _lCurrentHP , HPBar _hpBar )
    {
        _hpBar.Percent = ( float )_lCurrentHP / ( float )_lMaxHP;
        _hpBar.Text = GetHPString( _lMaxHP , _lCurrentHP );
    }

    string GetHPString(long _lMaxHP, long _lCurrentHP)
    {
        return string.Format( "{0}/{1}" , _lCurrentHP , _lMaxHP );
    }

}
