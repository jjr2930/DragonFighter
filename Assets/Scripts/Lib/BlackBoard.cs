using UnityEngine;
using System.Collections;

public class BlackBoard : MonoSingle<BlackBoard>{
    [SerializeField]
    int m_iUserScore = 0;





    /// <summary>
    /// 이 클래스의 변수들을 제어하기는 것은 정해진 클래스들만이 제어할 수 있으며
    /// 다른 클래스들은 프로퍼티를 통하여 Get만을 할 수 있다.
    /// 이것을 하는 이유는 데이터의 단순화와 모듈화를 통하여 사이드이펙트를 최소화 하기 위함이다.
    /// </summary>
    #region property
    public int UserScore
    {
        get
        {
            return m_iUserScore;
        }
    }
    


    #endregion
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
