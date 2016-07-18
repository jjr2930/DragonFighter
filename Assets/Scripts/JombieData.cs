using UnityEngine;
using System.Collections;

public class ZombieData : MonoBehaviour {
    int m_iHP;
    int m_iDmg;
    E_ZombieType m_eType;
    public int HP
    {
        get
        {
            return m_iHP;
        }
        set
        {
            m_iHP = value;
            if(m_iHP <= 0)
            {
                int rnd = Random.Range(0,2);

                JEventSystem.EnqueueEvent((rnd == 0) 
                                            ? E_ZombieAnimEvent.DeathBack 
                                            : E_ZombieAnimEvent.DeathForward,
                                            GetInstanceID());
            }
        }
    }

    public int DMG
    {
        get
        {
            return m_iDmg;
        }
        set
        {
            m_iDmg = value;
        }
    }

    public E_ZombieType Type
    {
        get
        {
            return m_eType;
        }
        set
        {
            m_eType = value;
        }
    }



}
