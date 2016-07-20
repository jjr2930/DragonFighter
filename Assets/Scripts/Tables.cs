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
    public int[] CCPM; //create count per minuite
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

[Serializable]
class LocalizeData
{
    public string key;
    public string location;
    public string value;
}

class LocalizeDataList
{
    public List<LocalizeData> localize;
}

class LocalizeTables
{
    Dictionary<string,Dictionary<string,string>> 
        m_dicLocalizeStrings;

    string m_strLocation;
    
    public LocalizeTables()
    {
        m_dicLocalizeStrings = new Dictionary<string, Dictionary<string, string>>();
    }

    public void LoadLocalizeTable()
    {
        string strJSON = JResources.LoadStreamingAsset<TextAsset>("localizeTable.txt").text;

        LocalizeDataList table = JsonUtility.FromJson<LocalizeDataList>(strJSON);

        for( int i = 0 ; i < table.localize.Count ; i++ )
        {
            string key = table.localize[ i ].key ;
            string location = table.localize[i].location;
            string value = table.localize[i].value;
            if( !m_dicLocalizeStrings.ContainsKey( key ) )
            {
                m_dicLocalizeStrings.Add(key,new Dictionary<string, string>());
            }

            Dictionary<string, string> dicSelected = m_dicLocalizeStrings[key];
            dicSelected.Add(location,value);
        }
    }

    public void SetLocal(string location )
    {
        m_strLocation = location;
    }

    public string GetString(string key)
    {
        if(m_dicLocalizeStrings.ContainsKey(key))
        {
            if(m_dicLocalizeStrings[key].ContainsKey(m_strLocation))
            {
                return m_dicLocalizeStrings[key][m_strLocation];
            }
            else
            {
                Debug.Log("Does not have location : " + m_strLocation);
            }
        }
        else
        {
            Debug.Log("Does not have Key : " + key);
        }

        return "";
    }
}



