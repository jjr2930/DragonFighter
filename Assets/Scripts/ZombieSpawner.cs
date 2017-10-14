using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using AssetBundles;

public class ZombieSpawner : MonoBehaviour {
    [SerializeField]
    static bool m_bIsCanSpawn = false;

    public static bool IsCanSpawn
    {
        get { return m_bIsCanSpawn; }
        set { m_bIsCanSpawn = value; }
    }

    float m_fSpawnTime = 0f;

    IEnumerator m_zombieSpawnOperation = null;
    GameObject m_goZombie = null;
    private void Awake()
    {
        float minTime = INGAMECONST.ZombieConst.ZOMBIE_SPAWN_MIN_TIME;
        float maxTime = INGAMECONST.ZombieConst.ZOMBIE_SPAWN_MAX_TIME;
        m_fSpawnTime = Random.Range( minTime, maxTime );


        //start spawn operation
        if(null != m_zombieSpawnOperation)
        {
            StopCoroutine( m_zombieSpawnOperation );
        }
        m_zombieSpawnOperation = SpawnZombieOperation();
        StartCoroutine( m_zombieSpawnOperation );
    }

    IEnumerator SpawnZombieOperation()
    {
        Debug.Log("HI");
        while (true)
        {
            yield return new WaitForSeconds( m_fSpawnTime );
            if (!m_bIsCanSpawn)
            { continue; }
            if (null != m_goZombie)
            { continue; }

            AssetBundleLoadAssetOperation assetLoadOperation 
                =  AssetBundleManager.LoadAssetAsync(INGAMECONST.BundleName.BUNDLE_NAME_ZOMBIE, 
                                                    INGAMECONST.AssetName.GetRandomZombieName(),
                                                    typeof(GameObject));

            while(!assetLoadOperation.IsDone())
            {
                yield return null;
            }

            GameObject goLoadedZombie = assetLoadOperation.GetAsset<GameObject>();
            m_goZombie = Instantiate(goLoadedZombie);
            m_goZombie.transform.position = this.transform.position;

            //onoff agent it is initialize about agent
            NavMeshAgent agent = m_goZombie.GetComponent<NavMeshAgent>();
            agent.enabled = false;
            agent.enabled = true;
        }
    }
}
