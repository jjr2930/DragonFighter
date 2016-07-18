using UnityEngine;
using System.Collections;

public class BlackBoard : MonoSingle<BlackBoard>{
    [SerializeField]
    int m_iUserScore = 0;
    
    #region property
    public int UserScore
    {
        get
        {
            return m_iUserScore;
        }

        set
        {
            m_iUserScore = value;
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
