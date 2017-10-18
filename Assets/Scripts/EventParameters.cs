using UnityEngine;
using System.Collections;
using UnityEngine.Events;

//it must be pool
namespace IngameEventParameters
{
    /// <summary>
    /// not use localize
    /// </summary>
    public class NoticeEventParameter
    {
        public JLib.LocalizeKey m_eKey;
        public UnityAction m_callback;
    }


    /// <summary>
    /// if monster or player was created, it will be created 
    /// or hp is changed,
    /// </summary>
    public class HPParameter
    {
        public Transform m_tOwnerTransform;
        public long m_lMaxHP;
        public long m_lCurrentHP;

    }
}