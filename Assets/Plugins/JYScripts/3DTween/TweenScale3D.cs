using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JLib
{
    public class TweenScale3D : TweenBase<Vector3>
    {
        [SerializeField]
        UnityEvent m_onCompleteCallback = null;

        Transform m_tCachedTransform = null;

        private void Awake()
        {
            m_tCachedTransform = transform;
        }

        public override void AddOnCompleteCallback( UnityAction _callback )
        {
            m_onCompleteCallback.AddListener( _callback );
        }

        public override void RemoveOnCompleteCallback( UnityAction _callback )
        {
            m_onCompleteCallback.RemoveListener( _callback );
        }

        protected override Vector3 Lerp( Vector3 _from , Vector3 _to , float _rate )
        {
            return Vector3.Lerp( _from , _to , _rate );
        }

        protected override void OnTweenComplete()
        {
            m_onCompleteCallback.Invoke();
        }

        protected override void SetValue( Vector3 _value )
        {
            m_tCachedTransform.localScale = _value;
        }
    }
}