using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// if Gameobject have this compontent, it will be donDestoryOnload Object
/// </summary>
public class DonDestroyComponent : MonoBehaviour 
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
