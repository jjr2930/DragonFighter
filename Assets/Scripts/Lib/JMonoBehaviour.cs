using UnityEngine;
using System.Collections;

/// <summary>
/// JResources.cs의 설명 참조
/// </summary>
public class JMonoBehaviour : MonoBehaviour {
    protected virtual void OnDestroy()
    {
        JResources.RemoveObject(GetInstanceID());
    }
}
