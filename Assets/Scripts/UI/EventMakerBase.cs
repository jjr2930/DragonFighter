using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public abstract class EventMakerBase : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Button button = GetComponent<Button>();
        if (null != button)
        {
            button.onClick.AddListener(this.CreateEvent);
            return;
        }

        EventTrigger et = GetComponent<EventTrigger>();
        if (null == et)
        {
            et = this.gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry newMethod = new EventTrigger.Entry();
        newMethod.callback.AddListener(CreateEvent);
        newMethod.eventID = EventTriggerType.Select;

        if (null == et.triggers)
        {
            et.triggers = new System.Collections.Generic.List<EventTrigger.Entry>();
        }

        et.triggers.Add(newMethod);
    }

    abstract public void CreateEvent();
    
    public void CreateEvent(BaseEventData data)
    {
        CreateEvent();
    }
}
