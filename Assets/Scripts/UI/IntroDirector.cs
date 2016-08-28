using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroDirector : MonoBehaviour {
    public Image m_backImg;
    public Text m_text;

    public float m_fFadeTime = 1f;

	// Use this for initialization
	void Start () {
        StartCoroutine(Direct());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Direct()
    {
        float fStartTime = Time.time;
        float fColor = 1f;

        //fade from white to black
        while (Time.time - fStartTime < m_fFadeTime)
        {
            fColor -= Time.deltaTime;
            fColor = Mathf.Clamp(fColor, 0f, 1f);
            m_backImg.color = new Color(fColor, fColor, fColor, 1f);

            yield return null;
        }

        //show myName
        fStartTime = Time.time;
        fColor = 0f;
        while (Time.time - fStartTime < m_fFadeTime)
        {
            fColor += Time.deltaTime;
            fColor = Mathf.Clamp(fColor, 0f, 1f);

            m_text.text = "JungYeol Joo";
            m_text.color = new Color(1f, 1f, 1f, fColor);

            yield return null;
        }

        //hide Myname
        fStartTime = Time.time;
        fColor = 1f;
        while (Time.time - fStartTime < m_fFadeTime)
        {
            fColor -= Time.deltaTime;
            fColor = Mathf.Clamp(fColor, 0f, 1f);

            m_text.color = new Color(1f, 1f, 1f, fColor);

            yield return null;
        }

        JEventSystem.EnqueueEvent(E_UIEvent.SceneChange, (int)E_SceneNumber.Menu);
    }
}
