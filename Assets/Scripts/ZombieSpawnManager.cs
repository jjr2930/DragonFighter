
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class ZombieSpawnManager : 
    MonoSingle<ZombieSpawnManager>
{
    [SerializeField]
    List<Transform> m_listSpawnPosition = null;

    int m_iDiffcultIndex = 0;
    DifficultData m_diffTable = null;
    List<IEnumerator> m_listCoroutines = null;
    
    void Start()
    {
        m_listCoroutines = new List<IEnumerator>();

        CheckPointAndSpawnZombie(0);

        JEventSystem.AddObserver(E_EtcEvent.PointUp, CheckPointAndSpawnZombie);
    }
    

    public void CheckPointAndSpawnZombie(int point)
    {
        DifficultData tempTable = TableLoader.GetDiff(point);

        if (tempTable != m_diffTable)
        {
            m_diffTable = tempTable;

            StopAllCoroutineAndClearList();

            CoroutineSetting();

            StartZombieSpawnRoutine();
        }
    }
    void StartZombieSpawnRoutine()
    {
        for(int i = 0; i < m_listCoroutines.Count; i++)
        {
            StartCoroutine(m_listCoroutines[i]);
        }
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
        if (null == m_listCoroutines)
            return;

        if (0 == m_listCoroutines.Count)
            return;

        for(int i = 0; i<m_listCoroutines.Count; i++)
        {
            StopCoroutine(m_listCoroutines[i]);
        }

        m_listCoroutines.Clear();
    }

    IEnumerator CreateZombie(int id, int hp, int dmg, int ccpm)
    {
        float fCreateInterval = 60f/ ccpm;
        while(true)
        {
            string strPrefabPath =  (id == 0) ? TableLoader.GetResourcePath(id) :
                                    (id == 1) ? TableLoader.GetResourcePath(id) :
                                    (id == 2) ? TableLoader.GetResourcePath(id) :
                                    "";

            GameObject newZombie = JResources.Instantiate(JResources.Load(strPrefabPath), Vector3.zero, Quaternion.identity) as GameObject;

            int randomIndex = Random.Range(0, m_listSpawnPosition.Count);
            newZombie.transform.position = m_listSpawnPosition[randomIndex].position;
            ZombieData data = newZombie.GetComponent<ZombieData>();
            if(null == data)
            {
                data = newZombie.AddComponent<ZombieData>();
            }

            data.Type = (E_ZombieType) id;
            data.HP = hp;
            data.DMG = dmg;
            yield return new WaitForSeconds(fCreateInterval);
        }
    }
}

