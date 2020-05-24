using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObj : MonoBehaviour
{




    public void m_DestoryObj(GameObject Intaractor)
    {
        transform.position = new Vector3(0,0,0);

        Debug.Log(Intaractor.name);

        Intaractor.GetComponent<InventorySystem>().InventoryItemList.Add(gameObject.GetComponent<ItemComponent>().ItemType);

        //WaitForSeconds;

        DestroyImmediate(gameObject);
    }

}
