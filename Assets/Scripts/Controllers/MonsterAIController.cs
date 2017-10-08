using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAIController : MonoBehaviour {
	[SerializeField]
	IntUnityEvent OnHPChanged = null;
    
    [SerializeField]
	int m_iHP;

	[SerializeField]
	int m_iMaxHP;

	public int HP
	{
		get { return m_iHP; }
		set
		{
			m_iHP = Mathf.Clamp(value, 0, m_iMaxHP);
			OnHPChanged.Invoke(m_iHP);
		}
	}

	public int MaxHP
	{
		get { return m_iMaxHP; }
		set { m_iMaxHP = value; }
	}
}
