using UnityEngine;
using System.Collections;

public class TestEventCreator : MonoBehaviour
{
    public GameObject dstObj = null;
    private void OnGUI()
    {
        if ( GUILayout.Button( "Create Event" ) )
        {
            JLib.GlobalEventQueue.SendEvent(dstObj.GetInstanceID(), IngameEventName.TriggerEnter, null);
        }
    }
}
