using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IngameEventParameters;
using AssetBundles;
public class HpBarController : JLib.Singleton<HpBarController>
{
    Camera m_camMainCamera = null;

    private void Awake()
    {
        m_camMainCamera = Camera.main;    
    }
        
    public CreateHPBar(object param)
    {
        CreateHPBarParameter createParameter = param as CreateHPBarParameter;
        StartCoroutine( CreatedHPBarCoroutine(  createParameter.m_tOwnerTransform , 
                                               createParameter.m_lMaxHP , 
                                               createParameter.m_lCurrentHP ) );
    }

    IEnumerator CreatedHPBarCoroutine( Transform _tOwnerTransform, long _lMaxHP, long _lCurrentHP)
    {
        AssetBundleLoadAssetOperation operation = AssetBundleManager.LoadAssetAsync( INGAMECONST.BundleName.BUNDLE_NAME_UI ,
                                                                                    INGAMECONST.AssetName.ASSET_NAME_HPBAR ,
                                                                                    typeof( GameObject ) );
        while ( !operation.IsDone() )
        {
            yield return null;
        }

        GameObject loadedHpBar = operation.GetAsset<GameObject>();
        GameObject instantiatedhpBar = Instantiate( loadedHpBar ) as GameObject;
        RectTransform rtHPBar = instantiatedhpBar.transform as RectTransform;
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint( Camera.main , _tOwnerTransform.position );

        rtHPBar.parent = this.transform;
        rtHPBar.position = screenPoint;

        HPBar hpBarScript = instantiatedhpBar.GetComponent<HPBar>();
        hpBarScript.Id = _tOwnerTransform.gameObject.GetInstanceID();

    }
}
