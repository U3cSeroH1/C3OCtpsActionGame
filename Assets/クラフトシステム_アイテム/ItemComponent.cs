using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemComponent : MonoBehaviour
{

    [Serializable]
    public class m_MyEvent : UnityEvent<GameObject> { }


    public m_MyEvent m_ReceveFireIvent;

    public Item ItemType;



    public void ItemEventListener(GameObject Intaractor)
    {
        Debug.Log("ぴん！");
        m_ReceveFireIvent.Invoke(Intaractor);

    }



}
