using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// concept is memory pool
/// </summary>
public class ParticleManager 
    : MonoSingle<ParticleManager>
{
    [SerializeField]
    Vector3 m_vInitPos = new Vector3(0,-30000,0);
    //Create 3 all particle
    /// <summary>
    /// key : name, value : path
    /// </summary>
    Dictionary<string, string> m_dicParticlePathList 
        = new Dictionary<string, string>();

    Dictionary<string, List<ParticleNode>> m_dicParticles 
        = new Dictionary<string, List<ParticleNode>>(); 

    void Start()
    {
        ReadParticleList();
        InstantiateParticles();
    }

    public void ReadParticleList()
    {
        //read list;

        foreach( var item in m_dicParticlePathList )
        {
            m_dicParticles.Add(item.Key,new List<ParticleNode>());
        }
    }

    void InstantiateParticles()
    {
        foreach(var element in m_dicParticlePathList)
        {
            Object obj = JResources.Load(element.Value);
            for( int i = 0 ; i < 3 ; i++ )
            {
                ParticleNode node = CreateNewParticle( obj );
                m_dicParticles[ element.Key ].Add( node );
            }

        }
    }

    /// <summary>
    /// create New Particle
    /// </summary>
    /// <param name="obj">loaded obj</param>
    /// <returns>instantiated object</returns>
    private ParticleNode CreateNewParticle( Object obj )
    {
        GameObject go = JResources.Instantiate(obj,m_vInitPos,Quaternion.identity) as GameObject;
        ParticleNode node = go.GetComponent<ParticleNode>();
        if( null == node )
        {
            node = go.AddComponent<ParticleNode>();
        }

        return node;
    }

    /// <summary>
    /// Get particle from pool
    /// </summary>
    /// <param name="particleName">name of particle which is you want</param>
    /// <param name="position">appear position </param>
    /// <param name="rotation">appear rotation</param>
    /// <returns>founded particle</returns>
    public ParticleNode GetParticle(string particleName, Vector3 position, Quaternion rotation)
    {
        List<ParticleNode> list = null;
        ParticleNode result = null;
        if( m_dicParticles.TryGetValue( particleName , out list ) )
        {
            for( int i = 0 ; i < list.Count ; i++ )
            {
                if( !list[ i ].IsOutOfPool )
                {
                    result = list[ i ];
                }
            }
        }
        else
        {
            Debug.LogFormat( "not founded Particle {0}, so create new particle" , particleName );

            string path = m_dicParticlePathList[particleName];
            Object obj = JResources.Load(path);
            result = CreateNewParticle(obj);
        }
        
        result.transform.position = position;
        result.transform.rotation = rotation;
        result.enabled = true;
        result.IsOutOfPool = true;

        //add to dictionary
        m_dicParticles[particleName].Add(result);
        return result;
    }

   
}
