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
                    Debug.LogErrorFormat("Fatal Error : singletone object's count can not be over than 1, there is must one object in scene");
                    return null;
                }

                if(1 == foundeds.Length)
                {
                    _instance = foundeds[0];
                }
                else
                {
                    Debug.LogFormat("There is no {0}, Create {1}", 
                        typeof(T).ToString(), typeof(T).ToString());

                    GameObject go = new GameObject(typeof(T).ToString());
                    _instance = go.AddComponent<T>();
                }

                GameObject.DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }

    public static void Initilize()
    {
        _instance = Instance;
    }

}
