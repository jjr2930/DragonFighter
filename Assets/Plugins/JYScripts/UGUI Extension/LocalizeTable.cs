using System.Collections;
using System.Collections.Generic;
using AssetBundles;
using UnityEngine;

namespace JLib
{
    /// <summary>
    /// why this class should be singletone?
    /// because I want to see inspector about this members
    /// and control Initializing timing
    /// </summary>
    public class LocalizeTable : Singleton<LocalizeTable>
    {
        /// <summary>
        /// key : localize Key, value : localizeText
        /// </summary>
        Dictionary<string, string> dicLocalTable = new Dictionary<string, string>();

        List<LocalizeTextComponent> localizeTexts = new List<LocalizeTextComponent>();

        public void ChangeLanguage(SystemLanguage language)
        {
            LoadLocalizeTable( language );
            for (int i = 0; i < localizeTexts.Count; i++)
            {
                localizeTexts[i].Refresh();
            }
        }

        public IEnumerator LoadLocalizeTable(SystemLanguage language)
        {
            AssetBundleLoadAssetOperation operation = AssetBundleManager.LoadAssetAsync( CONST.BUNDLE_NAME_TABLE, CONST.LOCALIZE_TALBE_NAME, typeof( TextAsset ) );
            yield return operation;

            TextAsset txt = operation.GetAsset<TextAsset>();
            if (null == txt)
            {
                Debug.LogError( "Can not find LocalizeTable" );
                yield break;
            }

            //remove trash value
            dicLocalTable.Clear();
            LocalizeList table = JsonUtility.FromJson<LocalizeList>( txt.text );
            for (int i = 0; i < table.list.Count; i++)
            {
                LocalizeData selectedData = table.list[i];
                //create 
                //get localizeValue;
                string localizeText = selectedData.GetLocalizedText( language );
                dicLocalTable[selectedData.key] = localizeText;
            }
        }



        public string GetLocalize(string key)
        {
            if ( 0 == dicLocalTable.Count )
            {
                LoadLocalizeTable( Application.systemLanguage );
            }

            if (dicLocalTable.ContainsKey( key ))
            {
                return dicLocalTable[key];
            }
            Debug.LogError( "LocalizeTable : key is not contained" );
            return "";
        }

        public void AddLocalizeTextComponent(LocalizeTextComponent value)
        {
            if (localizeTexts.Contains( value ))
            {
                Debug.LogError( "LocalizteTable : " + value.name + " is already contained" );
                return;
            }

            localizeTexts.Add( value );
        }
    }
}