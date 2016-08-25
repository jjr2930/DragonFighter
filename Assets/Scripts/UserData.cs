using UnityEngine;
using System.Collections;

[SerializeField]
public class UserData : Singletone<UserData>
{
    [SerializeField]
    int m_iBaseDmg = 0;

    [SerializeField]
    int m_iTotalDmg = 0;


    public int BaseDmg {
        get
        {
            return m_iBaseDmg;
        }            
    }

    public int TotalDmg
    {
        get
        {
            return m_iTotalDmg;
        }

    }
    
    public UserData()
    {

    }
}
