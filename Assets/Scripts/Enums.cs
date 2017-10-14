using UnityEngine;
using System.Collections;

public enum IngameEventName
{
    None,

    /// <summary>
    /// Trigger Enter, parameter is Gameobject which is create this event
    /// </summary>
    TriggerEnter,
    /// <summary>
    /// if Enter cinema is completed, this event will be created
    /// </summary>
    Enter_EnterCinema,

    /// <summary>
    /// if Some hp is changed, this event weill be created
    /// parameter class name
    /// ChangeHPParamter
    /// </summary>
    HPChange,

}