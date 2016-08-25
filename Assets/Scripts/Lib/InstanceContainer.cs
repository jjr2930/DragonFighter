using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InstanceContainer : Singletone<InstanceContainer> {
    Dictionary<int, Object> m_instancies = null;

    public InstanceContainer()
    {
        m_instancies = new Dictionary<int , Object>();
    }

    public void AddObject( Object obj )
    {
        m_instancies.Add( obj.GetInstanceID() , obj );
    }

    public void DeleteObject( Object obj )
    {
        m_instancies.Remove(obj.GetInstanceID());
    }
    
    public Object GetObject(int id)
    {
        if(m_instancies.ContainsKey(id))
        {
            return m_instancies[id];
        }
        else
        {
            Debug.LogErrorFormat("Cannot found Object id : %d", id);
            return null;
        }
    }
}
