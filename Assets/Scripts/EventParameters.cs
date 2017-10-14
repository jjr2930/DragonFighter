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
    /// Change hp event parameter
    /// </summary>
    public class ChangeHPParameter
    {
        public long m_lMaxHP;
        public long m_lCurrentHP;
    }

    /// <summary>
    /// if monster or player was created, it will be created
    /// </summary>
    public class CreateHPBarParameter
    {
        public Transform m_tOwnerTransform;
        public long m_lMaxHP;
        public long m_lCurrentHP;

    }
}