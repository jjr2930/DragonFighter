using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundles;
namespace JLib
{
    /// <summary>
    /// 싱글톤으로 만들거임
    /// </summary>
    public class JObjectPool : Singleton<JObjectPool>
    {
        public List<PoolData> data = new List<PoolData>();
        //사용중이지 않은 것들의 목록
        Dictionary<JPoolKey, List<JPoolObject>> sleepedObjects = new Dictionary<JPoolKey, List<JPoolObject>>();

        public IEnumerator Start()
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (!sleepedObjects.ContainsKey( data[i].key ))
                {
                    sleepedObjects.Add( data[i].key, new List<JPoolObject>() );
                }
                for (int j = 0; j < data[i].howMuch; j++)
                {
                    string strBundleName = data[ i ].m_strBundleName;
                    string strAssetName = data[ i ].m_strAssetName;

                    AssetBundleLoadAssetOperation operation = AssetBundleManager.LoadAssetAsync(strBundleName,strAssetName,typeof(GameObject));
                    while ( !operation.IsDone() )
                    { yield return null; }

                    GameObject goLoadedObj = operation.GetAsset<GameObject>();
                    GameObject instanceGO = Instantiate( goLoadedObj ) as GameObject;
                    JPoolObject poolObject = instanceGO.GetComponent<JPoolObject>();
                    if (null == poolObject) //애러 표시
                    {
                        Debug.LogErrorFormat( "{0} does not have JPoolObject component", data[i].m_strAssetName );
                        continue;
                    }

                    if (null == sleepedObjects[data[i].key])
                    {
                        sleepedObjects[data[i].key] = new List<JPoolObject>();
                    }

                    poolObject.transform.parent = transform;
                    poolObject.transform.localPosition = Vector3.zero;
                    sleepedObjects[data[i].key].Add( poolObject );
                }
            }
        }

        public T GetPoolObject<T>(JPoolKey key) where T : Component
        {
            JPoolObject foundedObj = GetPoolObject( key );

            T component = foundedObj.GetComponent<T>();

            return component;
        }

        public JPoolObject GetPoolObject(JPoolKey key)
        {
            JPoolObject foundedObj = null;
            if (TryGetHaveSleepObject( key, out foundedObj ))
            {
				sleepedObjects[ key ].Remove( foundedObj );
                foundedObj.gameObject.SetActive( true );
                foundedObj.transform.parent = null;
                return foundedObj;
            }

            //error, error message is already printed by TryGetHaveSleepObject method
            return null;
        }

        public void ReturnToPool(JPoolKey key, JPoolObject poolObject)
        {
            poolObject.OnIntoPool();

            //Test code
            if(!sleepedObjects.ContainsKey(key))
            {
                sleepedObjects.Add( key , new List<JPoolObject>() );
            }
            //end Test code
            poolObject.transform.parent = transform;
            poolObject.transform.localPosition = Vector3.zero;
            sleepedObjects[key].Add( poolObject );
        }

        public bool TryGetHaveSleepObject(JPoolKey key, out JPoolObject outValue)
        {
            if (!sleepedObjects.ContainsKey( key ))
            {
                Debug.LogErrorFormat( "JObjectPool.GetPoolObject=>Key({0})not founded at sleepObjects", key );
                outValue = null;
                return false;
            }

            if (0 == sleepedObjects[key].Count)
            {
                Debug.LogErrorFormat( "JObjectPool.GetPoolObject=>Key({0}) count is zero", key );
                outValue = null;
                return false;
            }

            outValue = sleepedObjects[key][0];
            return true;
        }
    }

    /// <summary>
    /// 어떤것을 얼마나 만들것인지에 대한 정보
    /// </summary>
    [System.Serializable]
    public class PoolData
    {
        public JPoolKey key;
        /// <summary>
        /// 만들 것 프리팹의 이름
        /// </summary>
        public string m_strBundleName;

        public string m_strAssetName;

        /// <summary>
        /// 얼만큼 미리 만들거야?
        /// </summary>
        public int howMuch;
    }

}