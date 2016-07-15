using UnityEngine;
using System.Collections;

public class TestEventMaker : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if( GUILayout.Button( "Run" ) )
        {
            JEventSystem.EnqueueEvent( E_UserAnimEvent.Run );
        }

        if( GUILayout.Button( "Idle" ) )
        {
            JEventSystem.EnqueueEvent( E_UserAnimEvent.Idle );
        }

        if( GUILayout.Button( "Walk" ) )
        {
            JEventSystem.EnqueueEvent( E_UserAnimEvent.Walk );
        }
    }
}
