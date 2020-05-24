using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{

    public List<Item> InventoryItemList = new List<Item>();


    public GameObject InventoryGUIContPrefab = null;
    public GameObject InventoryScrollBar = null;

    public GameObject SeLf = null;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInventoryItemGUI()
    {

        int i = 0;

        foreach (Transform n in InventoryScrollBar.transform)
        {
            GameObject.Destroy(n.gameObject);
        }

        foreach (Item ItemList in InventoryItemList)
        {
            //プレハブからボタンを生成
            GameObject listButton = Instantiate(InventoryGUIContPrefab) as GameObject;
            //Vertical Layout Group の子にする
            listButton.transform.SetParent(InventoryScrollBar.transform, false);

            listButton.GetComponentInChildren<Text>().text = ItemList.itemName;

            //今生成したボタンにｱﾄﾞﾘｽﾅｰ←クソイ

            listButton.GetComponent<ItemComponent>().ItemType = ItemList;
            int n = i;
            //引数に何番目のボタンかを渡す
            listButton.GetComponentInChildren<Button>().onClick.AddListener(() => GUIBottonPushed(n));

            Debug.Log(i);

            i++;
        }
    }

    public void GUIBottonPushed(int i)
    {
        Debug.Log("すてたいよな？？？" + i);

        Instantiate(InventoryItemList[i].DispgameObject, SeLf.transform.position, Quaternion.identity);

        InventoryItemList.RemoveAt(i);

        UpdateInventoryItemGUI();


    }
    

}
