using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class ResourcesPathTable
{
    public int id;
    public string name;
    public string path;
}

[System.Serializable]
class DifficultTable
{
    public int startScore;
    public int[] enemyID;
    public int[] enemyHP;
    public int[] enemyDMG;
    public int[] enemyAMR;
    public int[] CCPM; //create count per munite
}

class TableLoader :
    MonoSingle<TableLoader>
{
    List<ResourcesPathTable> m_listResourcesTable;
    List<DifficultTable> m_listDifficultTable;

    #region Static function for utilization

    static public DifficultTable GetDiff(int iScore)
    {
        return Instance.GetDifficult(iScore);
    }

    #endregion

    DifficultTable GetDifficult(int iScore)
    {
        for(int i =1; i<m_listDifficultTable.Count; i++)
        {
            if( iScore < m_listDifficultTable[i].startScore)
            {
                return m_listDifficultTable[ i - 1];
            }
        }

        return null;
    }

    void Awake()
    {
        //load all tables
    }

    



}

