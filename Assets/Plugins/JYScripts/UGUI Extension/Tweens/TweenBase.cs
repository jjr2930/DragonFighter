using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace JLib
{
    public abstract class TweenBase<T> : MonoBehaviour
    {
        [SerializeField]
        protected T m_from;

        [SerializeField]
        protected T m_to;

        [SerializeField]
        protected bool m_bUseTimescale = false;

        [SerializeField]
        protected float m_fDuration;

        [SerializeField]
        protected float m_fDelayTime;

        [SerializeField]
        AnimationCurve m_curve = null;

        IEnumerator m_coroutineTweenUpdate = null;
        T m_current;

        float m_fDuringTime = 0f;
        float m_fDestinationTime = 0f;

        IEnumerator UpdateTween( T _from , T _to , float _delayTime )
        {

            m_fDuringTime = 0f;

            m_current = m_from;

            SetValue( m_current );


            if ( m_bUseTimescale )
            { yield return new WaitForSecondsRealtime( _delayTime ); }

            else
            { yield return new WaitForSeconds( _delayTime ); }

            m_fDestinationTime = ( m_bUseTimescale ) ? ( Time.time + m_fDuration ) : ( Time.realtimeSinceStartup + m_fDuration );

            float currentTime = ( m_bUseTimescale ) ? ( Time.time ) : ( Time.realtimeSinceStartup );

            while ( currentTime < m_fDestinationTime )
            {
                float curveRate = m_fDuringTime / m_fDuration;

                float curveValue = m_curve.Evaluate( curveRate );

                m_current = Lerp( m_from , m_to , curveValue );

                SetValue( m_current );

                m_fDuringTime += ( m_bUseTimescale ) ? ( Time.deltaTime ) : ( Time.unscaledDeltaTime );

                currentTime = ( m_bUseTimescale ) ? ( Time.time ) : ( Time.realtimeSinceStartup );

                yield return null;
            }

            OnTweenComplete();
        }



        private void OnEnable()
        {
            if ( null != m_coroutineTweenUpdate )
            {
                StopCoroutine( m_coroutineTweenUpdate );
            }
            m_coroutineTweenUpdate = UpdateTween( m_from , m_to , m_fDelayTime );
            StartCoroutine( m_coroutineTweenUpdate );
        }

        private void OnDisable()
        {
            if ( null != m_coroutineTweenUpdate )
            {
                StopCoroutine( m_coroutineTweenUpdate );
            }
        }

        public void Play()
        {
            enabled = false;
            enabled = true;
        }

        protected abstract T Lerp( T _from , T _to , float _rate );
        protected abstract void SetValue( T _value );
        protected abstract void OnTweenComplete();
        public abstract void AddOnCompleteCallback( UnityAction _callback );
        public abstract void RemoveOnCompleteCallback( UnityAction _callback );
    }
}