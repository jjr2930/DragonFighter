using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocalLabel : MonoBehaviour {
    public string key = "";
    Text text = null;
	// Use this for initialization
	void Awake() {
        text = GetComponent<Text>();
	}


    void OnEnable()
    {
        text.text = JLocalize.Instance.GetString(key);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
