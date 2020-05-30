using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterComponent : CharacterComponent
{

    public override void FlipStateComponentsForStaticMotion()//AI用！！！ゆくゆくはオーバーライドで分岐させてけ
    {

        this.gameObject.GetComponent<Rigidbody>().isKinematic = !this.gameObject.GetComponent<Rigidbody>().isKinematic;


        attackComponent.enabled = !attackComponent.enabled;

        //if(animator.enabled)    animator.enabled = !animator.enabled;



        TakedDamage = !TakedDamage;

        navMesh.enabled = !navMesh.enabled;
        aIComponent.enabled = !aIComponent.enabled;

    }
}
