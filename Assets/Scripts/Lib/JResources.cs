using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JResources : Singletone<JResources>
{
    /// <summary>
    /// 이벤트 시스템을 이용함에 있어서 모든 데이터를 object로 넘기는것은 비효율 적이라고 판단되었다.(boxing, unboxing의 이유)
    /// 따라서 모든오브젝트의 InstanceID를 관리하는 클래스를 만들고 게임오브젝트를 인스턴스화 할 때마다 InstanceID를 키값으로 저장하게 하였다.
    /// 또한 객체의 삭제시 Dictionary에서 제거되야하므로 JMonoBehaviour라는 클래스를 만들고 이 곳에 virtual 함수로 OnDestory()함수를 만들었고,
    /// 그안에 자신을 Dictionary목록에서 제거하도록 만들었다. 
    /// *OnDestory함수는 유니티에서 컴포넌트를 삭제할때 호출되는 함수이다.
    /// </summary>
    Dictionary<int, Object> m_instancies = null;


    #region static function for utiltiy

    public static T LoadStreamingAsset<T>(string strPath) where T : class
    {
        return Instance.LoadStreamingAsest<T>(strPath);
    }

    public static Object Load(string strPath)
    {
        return Instance.OnLoad(strPath);
    }

    public static Object Instantiate(Object obj, Vector3 pos , Quaternion rot )
    {
        return Instance.OnInstantiate( obj , pos , rot );
    }

    public static Object GetObject(int id)
    {
        return Instance.OnGetObject(id);
    }

    public static void RemoveObject( Object obj)
    {
        Instance.OnRemoveObject( obj.GetInstanceID() );
    }

    public static void RemoveObject(int id)
    {
        Instance.OnRemoveObject(id);
    }

    #endregion


    public JResources()
    {
        m_instancies = new Dictionary<int , Object>();
    }

    T LoadStreamingAsest<T>(string strPath) where T : class
    {
        string strFullPath = Application.streamingAssetsPath + "/" + strPath;

        WWW www = new WWW(strFullPath);

        while(!www.isDone)
        {

        }

        if(string.IsNullOrEmpty( www.error))
        {
            Debug.Log("Loading Streamingasset is failed");
        }
        else
        {
            T result = www.assetBundle.mainAsset as T;
            return result;
        }

        return null;
    }

    Object OnLoad(string strPath)
    {
        Object obj = Resources.Load(strPath);

        return obj;
    }

    Object OnInstantiate(Object obj, Vector3 pos, Quaternion rot)
    {
        Object instance = Object.Instantiate(obj,pos,rot);

        GameObject go = instance as GameObject;

        if( null == go )
        {
            Debug.LogErrorFormat( "Fatal Error can not convert to GameObject : %s" , obj.name );
        }
        else
        {
            if( null == go.GetComponent<JMonoBehaviour>() )
            {
                go.AddComponent<JMonoBehaviour>();
            }
        } 

        m_instancies.Add(instance.GetInstanceID(), instance);

        return instance;
    }

    public void OnRemoveObject( int id )
    {
        m_instancies.Remove( id );
    }

    public Object OnGetObject(int id)
    {
        if(m_instancies.ContainsKey(id))
        {
            return m_instancies[id];
        }
        else
        {
            Debug.LogErrorFormat("Cannot found Object id : %d", id);
            return null;
        }
    }
}
