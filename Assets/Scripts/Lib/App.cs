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
    
    
}
