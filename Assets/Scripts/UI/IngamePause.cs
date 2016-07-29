using UnityEngine;
using System.Collections;

public class IngamePause : MonoBehaviour
{    
    void Start()
    {
        JEventSystem.AddObserver(E_VirtualKey.Pause_Down, ListenPause);
        JEventSystem.EnqueueEvent(E_VirtualKey.Pause_Down);
    }


	void ListenPause(int num)
    {
        gameObject.SetActive(!gameObject.activeSelf);
        Time.timeScale = (gameObject.activeSelf) ? 0f : 1f;
    }
}
