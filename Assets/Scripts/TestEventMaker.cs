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
            JEventSystem.EnqueueEvent( E_AnimEvent.Run , null );
        }

        if( GUILayout.Button( "Idle" ) )
        {
            JEventSystem.EnqueueEvent( E_AnimEvent.Idle , null );
        }

        if( GUILayout.Button( "Walk" ) )
        {
            JEventSystem.EnqueueEvent( E_AnimEvent.Walk , null );
        }
    }
}
