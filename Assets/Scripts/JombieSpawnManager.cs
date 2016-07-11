
using UnityEngine;
using System;
using System.Collections.Generic;

class JombieSpawnManager : 
    MonoSingle<JombieSpawnManager>
{
    int m_iDiffIndex = 0;
    DifficultTable m_diffTable = null;

    Dictionary<int, float> m_dicLastMakedTime = null;
    void Awake()
    {
        if( null == m_dicLastMakedTime)
        {
            m_dicLastMakedTime = new Dictionary<int, float>();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        for(int i =0; i<m_diffTable.enemyID.Length; i++)
        {
            
        }
    }

    public void DifficultUp(GameObject go)
    {
       
        BlackBoard bb = go.GetComponent<BlackBoard>();

        m_diffTable = TableLoader.GetDiff(bb.UserScore);

        m_dicLastMakedTime.Clear();

        for(int i =0; i<m_diffTable.enemyID.Length; i++)
        {

        }
    }
}

