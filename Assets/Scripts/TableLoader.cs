using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
class ResourcesPathData
{
    public int id = 0;
    public string name = "";
    public string path = "";
}

[Serializable]
class ResourcesPathTable
{
    public List<ResourcesPathData> table = null;
}

[System.Serializable]
class DifficultData
{
    public int startScore = 0;
    public int[] enemyID = null;
    public int[] enemyHP = null;
    public int[] enemyDMG = null;
    public int[] CCPM = null; //create count per minuite
}

[Serializable]
class DifficultTable
{
    public List<DifficultData> table = null;
}


[System.Serializable]
class TableLoader :
    MonoSingle<TableLoader>
{
    public ResourcesPathTable m_resourcesTable;
    public DifficultTable m_difficultTable;

    //public ResourcesPathTable[] m_listResourcesTable;
    //public DifficultTable[] m_listDifficultTable;

    #region Static function for utilization

    /// <summary>
    /// Get difficult data using score
    /// </summary>
    /// <param name="iScore"> score </param>
    /// <returns>diffcult data</returns>
    static public DifficultData GetDiff(int iScore)
    {
        return Instance.GetDifficult(iScore);
    }

    /// <summary>
    /// get resource path
    /// </summary>
    /// <param name="id">resource id</param>
    /// <returns>path</returns>
    public static string GetResourcePath(int id)
    {
        return Instance.OnGetResourcePath(id);
    }

    /// <summary>
    /// Get Resource Path
    /// </summary>
    /// <param name="name">resource name</param>
    /// <returns>path</returns>
    public static string GetResourcePath(string name)
    {
        return Instance.OnGetResourcePath(name);
    }

    #endregion

    /// <summary>
    /// GetResourcePath(like Player Prefab,zombie prefab, effect prefab)
    /// </summary>
    /// <param name="id">resource id</param>
    /// <returns>path</returns>
    public string OnGetResourcePath(int id)
    {
        for (int i = 0; i < m_resourcesTable.table.Count; i++)
        {
            if(id == m_resourcesTable.table[i].id)
            {
                return m_resourcesTable.table[i].path;
            }
        }

        return "";
    }

    /// <summary>
    /// GetResourcePath(like Player Prefab,zombie prefab, effect prefab)
    /// </summary>
    /// <param name="name">resource name</param>
    /// <returns></returns>
    public string OnGetResourcePath(string name)
    {
        for(int i = 0; i< m_resourcesTable.table.Count; i++)
        {
            if(name == m_resourcesTable.table[i].name)
            {
                return m_resourcesTable.table[i].path;
            }
        }

        return "";
    }

    DifficultData GetDifficult(int iScore)
    {
        for(int i =1; i<m_difficultTable.table.Count; i++)
        {
            if( iScore < m_difficultTable.table[i].startScore)
            {
                return m_difficultTable.table[ i - 1];
            }
        }

        return null;
    }

    /// <summary>
    /// load resource table
    /// load difficult table
    /// </summary>
    void Awake()
    {
        TextAsset rescTA    = JResources.Load(Configure.Instance.PATH_RESC_TABLE) as TextAsset;
        TextAsset diffTA    = JResources.Load(Configure.Instance.PATH_DIFF_TABLE) as TextAsset;

        string rescJson     = rescTA.text;
        string diffJson     = diffTA.text;

        m_difficultTable    = new DifficultTable();
        m_resourcesTable    = new ResourcesPathTable();

        m_difficultTable    = JsonUtility.FromJson<DifficultTable>(diffJson);
        m_resourcesTable    = JsonUtility.FromJson<ResourcesPathTable>(rescJson);
    }
}





