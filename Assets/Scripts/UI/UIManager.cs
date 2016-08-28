using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoSingle<UIManager> {

    public Dictionary<E_SceneNumber, GameObject> m_dicUIs
        = new Dictionary<E_SceneNumber, GameObject>();


    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        for (int i = (int)E_SceneNumber.None + 1; 
            i < (int)E_SceneNumber.MAX; i++)
        {
            string name = ((E_SceneNumber)i).ToString();
            GameObject foundedUi = GameObject.Find(name);
            m_dicUIs.Add((E_SceneNumber)i, foundedUi);
        }

        int sceneCnt = SceneManager.sceneCount;
        for(int i = 0;i<sceneCnt; i++)
        {
            string strUIName = Configure.Instance.SCENENAME_UI;
            if(strUIName != SceneManager.GetSceneAt(i).name)
            {
                UIChange(SceneManager.GetSceneAt(i).name);
            }
        }


    }

    public void Start()
    {
        JEventSystem.AddObserver(E_UIEvent.SceneChange, UIChange);
    }

    /// <summary>
    /// ui Mode change 
    /// </summary>
    /// <param name="scene"></param>
    public void UIChange(E_SceneNumber scene)
    {
        foreach (var item in m_dicUIs)
        {
            if( scene == item.Key )
            {
                item.Value.SetActive(true);
            }
            else
            {
                item.Value.SetActive(false);
            }
        }
    }

    public void UIChange(string strSceneName)
    {
        foreach (var item in m_dicUIs)
        {
            if(strSceneName == item.Key.ToString())
            {
                item.Value.SetActive(true);
            }
            else
            {
                item.Value.SetActive(false);
            }
        }
    }

    public void UIChange(int sceneNumber)
    {
        UIChange((E_SceneNumber)sceneNumber);
    }


}
