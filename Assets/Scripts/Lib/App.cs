using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;



public class App : MonoSingle<App>
{
    
    Image m_imgLoading = null;
    IEnumerator m_job = null;

    public AsyncOperation Async { get; set; }

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        App.Initilize();
    }

    void Awake()
    {
        StartCoroutine(LoadAllManagers());
    }

    void Start()
    {
    
        
        //JEventSystem.EnqueueEvent(E_UIEvent.SceneChange, (int) E_SceneNumber.Intro);
    }

    void ListenChangeScene(int sceneNum)
    {
        E_SceneNumber num = (E_SceneNumber)sceneNum;
        switch (num)
        {
            case E_SceneNumber.Ingame:
                Async = SceneManager.LoadSceneAsync(Configure.Instance.SCENENAME_INGAME);
                //StartCoroutine(m_job);
                break;

            case E_SceneNumber.Intro:
                Async = SceneManager.LoadSceneAsync(Configure.Instance.SCENENAME_INTRO);
                //StartCoroutine(m_job);
                break;

            case E_SceneNumber.Menu:
                Async = SceneManager.LoadSceneAsync(Configure.Instance.SCENENAME_MENU);
                //StartCoroutine(m_job);
                break;

            case E_SceneNumber.Exit:
                Debug.Log("Exit");
                Application.Quit();
                break;
        }
    }
    
    IEnumerator LoadAllManagers()
    {
        Configure.Initilize();
        yield return null;

        JEventSystem.Initilize();
        yield return null;

        TableLoader.Initilize();
        yield return null;

        JLocalize.Initialize();
        yield return null;

        JEventSystem.AddObserver(E_UIEvent.SceneChange, ListenChangeScene);


        ///merge scene
        string strUISceneName = Configure.Instance.SCENENAME_UI;

        SceneManager.LoadScene(strUISceneName, LoadSceneMode.Additive);
    }
}
