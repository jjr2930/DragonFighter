
using UnityEngine;
using UnityEngine.UI;
using IngameEventParameters;

public class Notice : JMonoBehaviour
{
    [SerializeField]
    JLib.TweenFilled m_filledTween = null;

    [SerializeField]
    Text m_text = null;


    public void ShowNotice( object param )
    {
        NoticeEventParameter noticeEventParameter = param as NoticeEventParameter;

        //it is error
        if ( null == noticeEventParameter )
        { return; }

        string localString = JLib.LocalizeTable.Instance.GetLocalize( noticeEventParameter.m_eKey.ToString() );

        if ( string.IsNullOrEmpty( localString ) )
        { 
            localString = noticeEventParameter.m_eKey.ToString(); 
        }

        m_text.text = localString;

        m_filledTween.AddOnCompleteCallback( noticeEventParameter.m_callback );

        m_filledTween.gameObject.SetActive( true );
                                           
    }


}
