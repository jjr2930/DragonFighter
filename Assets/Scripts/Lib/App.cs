using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public class App : MonoSingle<App>
{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        App.Initilize();
        if (Configure.Instance.SCENE_INGAME == SceneManager.GetActiveScene().name)
        {
            IngameManager im = IngameManager.Instance;
        }
    }

    void Start()
    {
        //initialize configure and tables
        Configure.Initilize();
        TableLoader.Initilize();

        JLocalize.Instance.SetLocal(GetSystemLanguage());
        JLocalize.Instance.LoadLocalizeTable();

        JEventSystem.AddObserver(E_UIEvent.SceneChange, ListenChangeScene);
    }

    void ListenChangeScene(int sceneNum)
    {
        E_SceneNumber num = (E_SceneNumber)sceneNum;
        switch (num)
        {
            case E_SceneNumber.Ingame:
                SceneManager.LoadSceneAsync(Configure.Instance.SCENE_INGAME);
                break;

            case E_SceneNumber.Intro:
                SceneManager.LoadSceneAsync(Configure.Instance.SCENE_INTRO);
                break;

            case E_SceneNumber.Menu:
                SceneManager.LoadSceneAsync(Configure.Instance.SCENE_MENU);
                break;

            case E_SceneNumber.Exit:
                Application.Quit();
                break;
        }
    }

    string GetSystemLanguage()
    {
        string language = Application.systemLanguage.ToString();
        return language;
    }
}
