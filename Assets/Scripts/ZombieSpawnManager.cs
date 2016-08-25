
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class ZombieSpawnManager : 
    MonoSingle<ZombieSpawnManager>
{
    int m_iDiffcultIndex = 0;
    DifficultData m_diffTable = null;
    List<IEnumerator> m_listCoroutines = null;
    void Awake()
    {
       
    }

    void Start()
    {
        PointChecker(0);

        JEventSystem.AddObserver(E_EtcEvent.PointUp, PointChecker);
    }
    

    public void PointChecker(int point)
    {   
        m_diffTable = TableLoader.GetDiff(point);

        StopAllCoroutineAndClearList();

        CoroutineSetting();
    }

    void CoroutineSetting()
    {
        
        for(int i = 0; i<m_diffTable.enemyID.Length; i++)
        {
            m_listCoroutines.Add(
                CreateZombie(m_diffTable.enemyID[i],
                             m_diffTable.enemyHP[i],
                             m_diffTable.enemyDMG[i],
                             m_diffTable.CCPM[i]));
        }
    }

    void StopAllCoroutineAndClearList()
    {
        for(int i = 0; i<m_listCoroutines.Count; i++)
        {
            StopCoroutine(m_listCoroutines[i]);
        }

        m_listCoroutines.Clear();
    }

    IEnumerator CreateZombie(int id, int hp, int dmg, int ccpm)
    {
        float fCreateInterval = 60f/(float)ccpm;
        while(true)
        {
            string strPrefabPath =  (id == 0) ? Configure.Instance.PATH_ZOMBIE_0 :
                                    (id == 1) ? Configure.Instance.PATH_ZOMBIE_1 :
                                    (id == 2) ? Configure.Instance.PATH_ZOMBIE_2 :
                                    Configure.Instance.PATH_ZOMBIE_3;

            GameObject newZombie =  JResources.Load(strPrefabPath) as GameObject;
            ZombieData data = newZombie.GetComponent<ZombieData>();
            data.Type = (E_ZombieType) id;
            data.HP = hp;
            data.DMG = dmg;
            yield return new WaitForSeconds(fCreateInterval);
        }
    }
}

