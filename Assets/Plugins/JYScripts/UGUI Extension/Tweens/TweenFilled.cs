using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

namespace JLib
{
    public class TweenFilled : TweenBase<float>
    {
        [SerializeField]
        UnityEvent m_OnComplete = null;

        Image m_img = null;
        private void Awake()
        {
            m_img = GetComponent<Image>();
        }

        protected override void SetValue( float _value )
        {
            m_img.fillAmount = _value;
        }

        protected override float Lerp( float _from , float _to , float _rate )
        {
            return Mathf.Lerp( _from , _to , _rate );
        }

        protected override void OnTweenComplete()
        {
            m_OnComplete.Invoke();
        }

        public override void AddOnCompleteCallback( UnityAction _callback )
        {
            m_OnComplete.AddListener( _callback );
        }

        public override void RemoveOnCompleteCallback( UnityAction _callback )
        {
            m_OnComplete.RemoveListener( _callback );
        }
    }
}
