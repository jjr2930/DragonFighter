using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;



public class App : MonoSingle<App>
{
    AsyncOperation m_async = null;
    Image m_imgLoading = null;
    IEnumerator m_job = null;

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        App.Initilize();
        if (Configure.Instance.SCENENAME_INGAME == SceneManager.GetActiveScene().name)
        {
            IngameManager im = IngameManager.Instance;
        }
    }

    void Start()
    {
        //initialize configure and tables
        Configure.Initilize();
        TableLoader.Initilize();
        JLocalize.Initialize();

        JEventSystem.AddObserver(E_UIEvent.SceneChange, ListenChangeScene);


        ///merge scene
        string strUISceneName = Configure.Instance.SCENENAME_UI;

        SceneManager.LoadScene(strUISceneName, LoadSceneMode.Additive);

        m_job = ShowLoadingUI();
    }

    void ListenChangeScene(int sceneNum)
    {
        if(null == m_imgLoading)
        {
            string      strLoadingImgPath   = TableLoader.GetResourcePath("Loading");
            Object      obj                 = JResources.Load(strLoadingImgPath);
            GameObject  go                  = JResources.Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;

            m_imgLoading = go.GetComponent<Image>();
            DontDestroyOnLoad(m_imgLoading);
        }
        E_SceneNumber num = (E_SceneNumber)sceneNum;
        switch (num)
        {
            case E_SceneNumber.Ingame:
                m_async = SceneManager.LoadSceneAsync(Configure.Instance.SCENENAME_INGAME);
                StartCoroutine(m_job);
                break;

            case E_SceneNumber.Intro:
                m_async = SceneManager.LoadSceneAsync(Configure.Instance.SCENENAME_INTRO);
                StartCoroutine(m_job);
                break;

            case E_SceneNumber.Menu:
                m_async = SceneManager.LoadSceneAsync(Configure.Instance.SCENENAME_MENU);
                StartCoroutine(m_job);
                break;

            case E_SceneNumber.Exit:
                Debug.Log("Exit");
                Application.Quit();
                break;
        }
    }
    
    IEnumerator ShowLoadingUI()
    {
        m_imgLoading.gameObject.SetActive(true);
        while (!m_async.isDone)
        {
            m_imgLoading.fillAmount = m_async.progress;
            yield return null;
        }

        m_imgLoading.gameObject.SetActive(false);
        yield break;
    }
}
