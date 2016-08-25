using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


[Serializable]
class LocalizeData
{
    public string key;
    public string location;
    public string value;
}

[Serializable]
class LocalizeTable
{
    public List<LocalizeData> table;
}

class JLocalize : Singletone<JLocalize>
{
    Dictionary<string, Dictionary<string, string>>
        m_dicLocalizeStrings;

    string m_strLocation;

    public JLocalize()
    {
        m_dicLocalizeStrings = new Dictionary<string, Dictionary<string, string>>();
        m_strLocation = Application.systemLanguage.ToString();
        LoadLocalizeTable();
    }

    public void LoadLocalizeTable()
    {
        TextAsset ta = JResources.Load(Configure.Instance.PATH_LOCAL_TABLE) as TextAsset;
        string strJSON = ta.text;

        LocalizeTable table = JsonUtility.FromJson<LocalizeTable>(strJSON);

        for (int i = 0; i < table.table.Count; i++)
        {
            string key = table.table[i].key;
            string location = table.table[i].location;
            string value = table.table[i].value;
            if (!m_dicLocalizeStrings.ContainsKey(key))
            {
                m_dicLocalizeStrings.Add(key, new Dictionary<string, string>());
            }

            Dictionary<string, string> dicSelected = m_dicLocalizeStrings[key];
            dicSelected.Add(location, value);
        }
    }

    public void SetLocal(string location)
    {
        m_strLocation = location;
    }

    public string GetString(string key)
    {
        if (m_dicLocalizeStrings.ContainsKey(key))
        {
            if (m_dicLocalizeStrings[key].ContainsKey(m_strLocation))
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
