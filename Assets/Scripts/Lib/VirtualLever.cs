using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualLever : MonoBehaviour
{
    [SerializeField]
    bool m_bIsDragStarted = false;

    [SerializeField]
    Image m_imgBg = null;

    [SerializeField]
    Image m_imgThumb = null;

    void Awake()
    {
        m_imgBg = this.GetComponent<Image>();
        m_imgThumb = this.transform.FindChild("Thumb").GetComponent<Image>();
    }

    void Update()
    {
        //if drag is not started, do not update
        if (!m_bIsDragStarted) { return; }



        Vector3 vDir = m_imgThumb.transform.position - m_imgBg.transform.position;
        Vector3 vStandard = Vector3.right;

        float fAngle = Vector3.Angle(vStandard, vDir);
        float fSqrDistance = Vector3.SqrMagnitude(vDir);
        float fSleep = Configure.Instance.LEVER_SLEEP * Configure.Instance.LEVER_SLEEP;
        int iSection = (int)(fAngle / 30f);

        //if distance is smaller than sleep amount, do not Make Event
        if (fSqrDistance <= fSleep) { return; }


        //divide every 30 degree
        switch (iSection)
        {
            case 0://0~30
                JEventSystem.EnqueueEvent(E_VirtualKey.Right_Down);
                break;

            case 1://30~60
                JEventSystem.EnqueueEvent(E_VirtualKey.Right_Down);
                JEventSystem.EnqueueEvent(E_VirtualKey.Forward_Down);
                break;

            case 2:  //60~90
                JEventSystem.EnqueueEvent(E_VirtualKey.Forward_Down);
                break;

            case 3://90~120
                JEventSystem.EnqueueEvent(E_VirtualKey.Forward);
                break;

            case 4://120~ 150
                JEventSystem.EnqueueEvent(E_VirtualKey.Forward);
                JEventSystem.EnqueueEvent(E_VirtualKey.Left);
                break;

            case 5://150 ~ 180
                JEventSystem.EnqueueEvent(E_VirtualKey.Left);
                break;

            case 6://180 ~ 210
                JEventSystem.EnqueueEvent(E_VirtualKey.Left);
                break;

            case 7://210 ~ 240
                JEventSystem.EnqueueEvent(E_VirtualKey.Back);
                JEventSystem.EnqueueEvent(E_VirtualKey.Left);
                break;

            case 8://240 ~ 270
                JEventSystem.EnqueueEvent(E_VirtualKey.Back);
                break;

            case 9://270 ~ 300
                JEventSystem.EnqueueEvent(E_VirtualKey.Back);
                break;

            case 10://300 ~ 330
                JEventSystem.EnqueueEvent(E_VirtualKey.Back);
                JEventSystem.EnqueueEvent(E_VirtualKey.Right);
                break;

            case 11: //330 ~ 360
                JEventSystem.EnqueueEvent(E_VirtualKey.Right);
                break;

        }
    }

    public void DragStart()
    {
        m_bIsDragStarted = true;
    }

    public void DragEnd()
    {
        m_bIsDragStarted = false;

        //locate thumb to center of background
        Vector2 vCenter = m_imgBg.rectTransform.position;

        m_imgThumb.rectTransform.position = vCenter;

    }

    public void Drag()
    {
        if (!m_bIsDragStarted)
        {
            return;
        }

        Debug.Log("Drag");

#if UNITY_EDITOR
        Vector2 pos = Input.mousePosition;

        float width = m_imgBg.rectTransform.rect.width/2;
        float height = m_imgBg.rectTransform.rect.height/2;

        if (pos.x <= Screen.width / 2f)
        {
            pos.x = Mathf.Clamp(pos.x, 
                                m_imgBg.transform.position.x - width,
                                m_imgBg.transform.position.x + width);

            pos.y = Mathf.Clamp(pos.y,
                                m_imgBg.transform.position.y - height,
                                m_imgBg.transform.position.y + height
                                );
            m_imgThumb.transform.position = pos;
        }
#endif

#if !UNITY_EDITOR
        for (int i = 0; i < Input.touches.Length; i++)
        {
            Vector2 pos = Input.touches[i].position;
            if (pos.x <= Screen.width / 2f)
            {
                pos.x = Mathf.Clamp(pos.x, 
                                m_imgBg.transform.position.x - width,
                                m_imgBg.transform.position.x + width);

                pos.y = Mathf.Clamp(pos.y,
                                m_imgBg.transform.position.y - height,
                                m_imgBg.transform.position.y + height
                                );
                m_imgThumb.transform.position = pos;
            }
        }        
#endif




    }
}