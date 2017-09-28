using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JLib
{
    /// <summary>
    /// 싱글톤으로 만들거임
    /// </summary>
    public class JObjectPool : MonoBehaviour
    {
        public List<PoolData> data = new List<PoolData>();
        //사용중이지 않은 것들의 목록
        Dictionary<PoolKey, List<JPoolObject>> sleepedObjects = new Dictionary<PoolKey, List<JPoolObject>>();

        public void Awake()
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (!sleepedObjects.ContainsKey( data[i].key ))
                {
                    sleepedObjects.Add( data[i].key, new List<JPoolObject>() );
                }
                for (int j = 0; j < data[i].howMuch; j++)
                {
                    Object loadedObj = Resources.Load( data[i].path );
                    GameObject instanceGO = Instantiate( loadedObj ) as GameObject;
                    JPoolObject poolObject = instanceGO.GetComponent<JPoolObject>();
                    if (null == poolObject) //애러 표시
                    {
                        Debug.LogErrorFormat( "{0} does not have JPoolObject component", data[i].path );
                        continue;
                    }

                    if (null == sleepedObjects[data[i].key])
                    {
                        sleepedObjects[data[i].key] = new List<JPoolObject>();
                    }

                    sleepedObjects[data[i].key].Add( poolObject );
                }
            }
        }

        public T GetPoolObject<T>(PoolKey key) where T : Component
        {
            JPoolObject foundedObj = null;
            T component = null;

            if (TryGetHaveSleepObject( key, out foundedObj ))
            {
                component = foundedObj.GetComponent<T>();
                if (null == component)
                {
                    Debug.LogErrorFormat( "JObjectPool.GetPoolObject=> component is not founded type : {0}, prefabName : {1}",
                        typeof( T ).ToString(), foundedObj.name );
                    return null;
                }
            }

            sleepedObjects[key].Remove( foundedObj );
            return component;
        }

        public JPoolObject GetPoolObject(PoolKey key)
        {
            JPoolObject foundedObj = null;
            if (TryGetHaveSleepObject( key, out foundedObj ))
            {
                return foundedObj;
            }
            //error, error message is already printed by TryGetHaveSleepObject method
            return null;
        }

        public void ReturnToPool(PoolKey key, JPoolObject poolObject)
        {
            poolObject.OnIntoPool();
            sleepedObjects[key].Add( poolObject );
        }

        public bool TryGetHaveSleepObject(PoolKey key, out JPoolObject outValue)
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
        public PoolKey key;
        /// <summary>
        /// 만들 것 프리팹의 이름
        /// </summary>
        public string path;
        /// <summary>
        /// 얼만큼 미리 만들거야?
        /// </summary>
        public int howMuch;
    }

}