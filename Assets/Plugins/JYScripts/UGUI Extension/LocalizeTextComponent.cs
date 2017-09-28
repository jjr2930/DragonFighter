using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace JLib
{
    [AddComponentMenu("Custom UGUI/LocalizeLabelComponent")]
    [RequireComponent(typeof(Text))]
    public class LocalizeTextComponent : MonoBehaviour
    {
        [SerializeField]
        Text text = null;

        public LocalizeKey key = LocalizeKey.None;

        private void Awake()
        {
            text = GetComponent<Text>();
            Refresh();
            LocalizeTable.Instance.AddLocalizeTextComponent( this );
        }


        public void Refresh()
        {
            string localizeText = LocalizeTable.Instance.GetLocalize( key.ToString() );
            if ( string.IsNullOrEmpty( localizeText ) )
            {
                Debug.LogError( this.gameObject.name + " LocalizeTextComponent : localizeText is nullorempty" );
                return;
            }
            text.text = localizeText;
        }
    }
}