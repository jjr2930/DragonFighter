using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoSingle<UIManager> {

    public Dictionary<E_SceneNumber, GameObject> m_dicUIs
        = new Dictionary<E_SceneNumber, GameObject>();

    IEnumerator m_jobLoading = null;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        for (int i = (int)E_SceneNumber.None + 1;
            i < (int)E_SceneNumber.MAX; i++)
        {
            string name = ((E_SceneNumber)i).ToString();
            GameObject foundedUi = GameObject.Find(name);

            if (null != foundedUi)
            {
                m_dicUIs.Add((E_SceneNumber)i, foundedUi);
                foundedUi.SetActive(false);
                Debug.LogFormat("UIManager => {0} UI is add dictionary",name);
            }
        }

        //show this scene's ui
        string strUISceneName = Configure.Instance.SCENENAME_UI;
        string strNowSceneName = "";
        int iSceneCnt = SceneManager.sceneCount;
        for (int i = 0; i < iSceneCnt; i++)
        {
            strNowSceneName = SceneManager.GetSceneAt(i).name;
            if (strUISceneName != strNowSceneName)
            {
                Debug.LogFormat("show {0} scene ui", strNowSceneName);
                UIChange(strNowSceneName);
            }
        }
    }

    public void Start()
    {
        JEventSystem.AddObserver(E_UIEvent.SceneChange, ListenSceneChange_UI);
        JEventSystem.AddObserver(E_UIEvent.SceneChange, ListenSceneChange_loading);
    }

    /// <summary>
    /// ui Mode change 
    /// </summary>
    /// <param name="scene"></param>
    public void UIChange(E_SceneNumber scene)
    {
        UIChange(scene.ToString());
    }    

    public void ListenSceneChange_UI(int sceneNumber)
    {
        UIChange(((E_SceneNumber)sceneNumber).ToString());
    }


    //change ui mode and show loading
    public void UIChange(string strSceneName)
    {
        Debug.LogFormat("UI change to {0}", strSceneName);

        foreach (var item in m_dicUIs)
        {
            if (strSceneName == item.Key.ToString())
            {   
                item.Value.SetActive(true);
                Debug.LogFormat("{0} UI is activated", strSceneName);
            }
            else
            {
                item.Value.SetActive(false);
                Debug.LogFormat("{0} UI is deactivated", item.Key.ToString());
            }
        }        
    }

    public void ListenSceneChange_loading(int num)
    {
        if (null != m_jobLoading)
        {
            StopCoroutine(m_jobLoading);
        }
        m_jobLoading = CorLoadingUI();
        StartCoroutine(m_jobLoading);

        Debug.Log("Loading panel called");
    }

    IEnumerator CorLoadingUI()
    {
        Debug.Log("Job Loading");
        AsyncOperation async = App.Instance.Async;      //찝찝한 부분임
        GameObject loadingPanel = m_dicUIs[E_SceneNumber.Loading];
        Image imgLoading = loadingPanel.transform.GetChild(0).GetComponent<Image>();

        loadingPanel.SetActive(true);
        while (!async.isDone)
        {
            imgLoading.fillAmount = async.progress;
            yield return null;
        }

        loadingPanel.SetActive(false);
        yield break;
    }

}
