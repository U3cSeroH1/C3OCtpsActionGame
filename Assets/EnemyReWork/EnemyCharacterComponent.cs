using CleverCrow.Fluid.BTs.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyCharacterComponent : CharacterComponent
{

    private bool bufflag = false;

    public override void FlipStateComponentsForStaticMotion()//AI用！！！ゆくゆくはオーバーライドで分岐させてけ
    {

        //ここに処理を書く
        this.gameObject.GetComponent<Rigidbody>().isKinematic = !this.gameObject.GetComponent<Rigidbody>().isKinematic;


        attackComponent.enabled = !attackComponent.enabled;




        TakedDamage = !TakedDamage;


        //animator.PlayInFixedTime("CharaIdle", 0);

        //ここに再開後の処理を書く


        animator.enabled = !animator.enabled;




        navMesh.enabled = !navMesh.enabled;





        aIComponent.enabled = !aIComponent.enabled;



    }



}
