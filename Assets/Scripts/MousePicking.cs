using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundles;
public class MousePicking : MonoBehaviour
{
    [SerializeField]
    LayerMask layer;

    [SerializeField]
    TransformUnityEvent OnPicking_Transform = null;

    [SerializeField]
    RaycastHitUnityEvent OnPicking_RaycastHit = null;

    Ray ray;
    RaycastHit hit;
    private void Update()
    {
#if !UNITY_EDITOR
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if (TouchPhase.Began == touch.phase)
			{
				ray = Camera.main.ScreenPointToRay(touch.position);
				if (Physics.Raycast(ray, out hit, float.MaxValue, layer.value))
				{
					//Debug.Log("Mouse Pick complete");
		            OnPicking_Transform.Invoke(hit.transform);			
                    OnPicking_RaycastHit.Invoke(hit);                    
				}
			}
		}
#else
        if ( Input.GetButtonDown("Fire1"))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, float.MaxValue, layer.value))
			{
				//Debug.Log("Mouse Pick complete");
                OnPicking_Transform.Invoke(hit.transform);
                OnPicking_RaycastHit.Invoke(hit);
			}
        }
#endif
    }

    public void CreateMovePoint( RaycastHit hitInfo)
    {
        JLib.JPoolObject foundedObj = JLib.JObjectPool.Instance.GetPoolObject( JLib.JPoolKey.MovePoint );
        foundedObj.transform.position = hitInfo.point + Vector3.up * 0.01f;
        foundedObj.transform.rotation = Quaternion.LookRotation( -hitInfo.normal );
    }

}
