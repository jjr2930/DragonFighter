using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace JLib
{
    [System.Serializable]
    public class JPoolObject : MonoBehaviour
    {
        /// <summary>
        /// OnIntoPool에서사용할 함수들을 등록한다.
        /// 권장사항 : 자기자신 GameObject가 가진 함수만 등록하자
        /// </summary>
        [SerializeField]
        UnityEvent onIntoPool = null;
        /// <summary>
        /// 풀에 들어갈 때 할일을 정의한다.
        /// </summary>
        public virtual void OnIntoPool()
        {
            onIntoPool.Invoke();
        }
    }
}
