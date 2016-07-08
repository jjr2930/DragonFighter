using UnityEngine;
using System.Collections.Generic;

public class MonoSingle<T>:MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if(null == _instance)
            {
                //find gameobject at scene
                T[] foundeds = GameObject.FindObjectsOfType<T>();
                if(1 < foundeds.Length)
                {
                    Debug.LogErrorFormat("Fatal Error : singletone object's count is can not over than 1, there is must one object in scene");
                    return null;
                }

                if(1 == foundeds.Length)
                {
                    _instance = foundeds[0];
                }
                else
                {
                    GameObject go = new GameObject(typeof(T).ToString());
                    _instance = go.AddComponent<T>();
                }

                GameObject.DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }
}
