using UnityEngine;
using System.Collections;

namespace JLib
{
    public class JObjectPoolDefault : JPoolObject
    {
        [SerializeField]
        JPoolKey m_eKey = JPoolKey.None;

        [SerializeField]
        float m_fDespawnTime = 2f;

        IEnumerator m_despawnCoroutine = null;

        private void OnEnable()
        {
            m_despawnCoroutine = DelayDespawn();
            StartCoroutine( m_despawnCoroutine );
        }

        public override void OnIntoPool()
        {
            this.gameObject.SetActive( false );
        }

        IEnumerator DelayDespawn()
        {
            yield return new WaitForSeconds( m_fDespawnTime );
            JObjectPool.Instance.ReturnToPool( m_eKey , this );
        }
    }
}