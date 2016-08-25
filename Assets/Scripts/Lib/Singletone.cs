using UnityEngine;
using System.Collections;
using System.Collections.Generic;   

public class Singletone<T> where T : class, new()
{
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if(null == _instance)
            {
                _instance = new T();
            }

            return _instance;
        }
    }

    public static void Initialize()
    {
        _instance = Instance;
    }
}
