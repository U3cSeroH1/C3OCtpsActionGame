using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    private enum MenuState
    {

    } 

    public GameObject PlayerInfo = null;

    public GameObject MenuPanel = null;

    public bool IsMenuShow = false;


    public InventorySystem inventorySystem = null;


    // 警告：インベントリへのアイテム追加だけ別のやつにつくってる　うんこうんこ



    private void Start()
    {

        // カーソルロックを解除
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {

            if (!IsMenuShow)
            {



                IsMenuShow = true;

                // カーソルロックを解除
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = IsMenuShow;

                

                MenuPanel.SetActive(IsMenuShow);


                inventorySystem.UpdateInventoryItemGUI();

            }
            else
            {
                IsMenuShow = false;


                // カーソルロックを解除
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = IsMenuShow;

                MenuPanel.SetActive(IsMenuShow);
            }
   
        }

    }





    //public void 

}
