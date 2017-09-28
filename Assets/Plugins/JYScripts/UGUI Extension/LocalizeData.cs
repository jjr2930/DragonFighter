using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace JLib
{
    [System.Serializable]
    public class LocalizeList
    {
        public List<LocalizeData> list;
    }

    [System.Serializable]
    public class LocalizeData
    {
		public string key;
        /// <summary>
        /// To do:
        /// find more good parsing
        /// </summary>
        public string Korean;
        public string English;

        public string GetLocalizedText(SystemLanguage language)
        {
            switch (language)
            {
                case SystemLanguage.Korean:
                    return Korean;

                case SystemLanguage.English:
                    return English;

                default:
                    Debug.LogError( language + "is not supported yet" );
                    return null;
            }
        }
    }
}