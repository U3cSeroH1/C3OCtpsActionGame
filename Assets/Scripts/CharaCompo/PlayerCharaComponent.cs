using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCharaComponent : CharacterConponent
{
    // Update is called once per frame
    void Update()
    {

        //共通コンポーネント
        if (HP <= 0)
        {
            Waiter("Death", 0.5f);
        }

        if (takedAttack)
        {
            Waiter("KnockBackTime", 1f);
        }






    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<ItemComponent>() && (other.gameObject.transform.root.gameObject != _player) && !takedAttack)
        {

            if (other.gameObject.GetComponentInParent<ItemComponent>().ItemType.itemtype == Item.ItemType.ToolItem)//攻撃がHITした時
            {






                Debug.Log("playeritai!");

                takedAttack = true;




                HP -= other.gameObject.GetComponentInParent<ItemComponent>().ItemType.attack;


                KnockBackCalc(other.gameObject);




            }


        }
    }
}