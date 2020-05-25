using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCharacterComponent : MonoBehaviour
{



    public Character character = null;

    public float HP = 0;

    private void Start()
    {
         HP = character.HP;
    }



    private void OnCollisionEnter(Collision collision)
    {
        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<ItemComponent>().ItemType.itemtype == Item.ItemType.ToolItem)
        {
            HP -= other.gameObject.GetComponentInParent<ItemComponent>().ItemType.attack;
        }

    }


}
