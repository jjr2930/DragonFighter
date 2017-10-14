using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace JLib
{
    /// <summary>
    /// Animator parameter extension. it only support nullable type
    /// ToDo : Will create CustomInspector, Exception
    /// 
    /// </summary>
    public class AnimatorParamExtension : MonoBehaviour
    {
        Dictionary<int , object> m_dicParameters = new Dictionary<int , object>();

        public T GetParameter<T>( string valueName )
        {
            int hash = Animator.StringToHash( valueName );

            T result = GetParameter<T>( hash );

            return result;
        }

        public T GetParameter<T>( int hash ) 
        {
            if ( !m_dicParameters.ContainsKey( hash ) )
            {
                Debug.LogErrorFormat( "{0} is not contained" , hash );
                return default( T );
            }

            object foundedValue = m_dicParameters[ hash ];

            T valueForTypeCheck = (T)foundedValue;

            return valueForTypeCheck;
        }


        public void SetParameter( string valueName , object value )
        {
            int nameHash = Animator.StringToHash( valueName );
            SetParameter( nameHash , value );
        }

        /// <summary>
        /// set parameters data, if value is not class, it will be overhead
        /// </summary>
        /// <param name="hash">name hash it use animatorlayerhash</param>
        /// <param name="value">will be set value</param>
        public void SetParameter( int hash , object value )
        {
            m_dicParameters[ hash ] = value;
        }
    }
}