using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JLib
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T instance = null;
        static object mutex = new object();

        public static T Instance
        {
            get
            {
                if ( null == instance )
                {
                    //find object already...
                    T[] foundedObjs = FindObjectsOfType<T>();
                 
                    if ( foundedObjs.Length > 1 )
                    {
                        Debug.LogError( "Error: Signleton must be only one(unique)" );
                        return null;
                    }

                    if ( 1 == foundedObjs.Length)
                    {
                        instance = foundedObjs[ 0 ];
                    }

                    //this is critical section
                    lock ( mutex )
                    {
                        if ( 0 == foundedObjs.Length )
                        {
                            GameObject newGameobject = new GameObject();

                            //getName
                            string fullTypeName = typeof( T ).ToString();
                            string[] splitedStrings = fullTypeName.Split( '.' );
                            string simpleName = splitedStrings[ splitedStrings.Length - 1 ];

                            newGameobject.name = simpleName;
                            instance = newGameobject.AddComponent<T>();

                            DontDestroyOnLoad( newGameobject );

                        }
                    }
                }
                return instance;
            }
        }
    }
}