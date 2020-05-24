using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerIntaractor : MonoBehaviour
{

    [Serializable]
    public class m_MyEvent : UnityEvent<GameObject> { }


    public m_MyEvent _MyEvent;


    public GameObject SeLf;


    public List<GameObject> IntaractableItemList = new List<GameObject>();


    public MenuScript menuScript = null;

    void Start()
    {

    }

    private void Update()
    {



        if (Input.GetButtonUp("Intaract") && !menuScript.IsMenuShow)
        {
            Debug.Log("Fをおしたな？");


            _MyEvent.Invoke(SeLf);




            if (IntaractableItemList[0] == null)
            {
                IntaractableItemList.RemoveAt(0);
                _MyEvent.AddListener(IntaractableItemList[0].GetComponent<ItemComponent>().ItemEventListener);
            }
            else
            {
                
            }
            

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("アイテム検知");

        if (other.GetComponentInParent<ItemComponent>())
        {
            IntaractableItemList.Add(other.gameObject.transform.parent.gameObject);

            _MyEvent.AddListener(IntaractableItemList[0].GetComponent<ItemComponent>().ItemEventListener);

        }

        //
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<ItemComponent>())
        {
            IntaractableItemList.Remove(other.gameObject.transform.parent.gameObject);
            _MyEvent.RemoveAllListeners();
        }



    }
}
