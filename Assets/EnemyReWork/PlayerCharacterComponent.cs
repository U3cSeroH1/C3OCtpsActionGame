using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterComponent : CharacterComponent
{
    public override void FlipStateComponentsForStaticMotion()//AI用！！！ゆくゆくはオーバーライドで分岐させてけ
    {
        //this.gameObject.GetComponent<Rigidbody>().isKinematic = !this.gameObject.GetComponent<Rigidbody>().isKinematic;
        playerMovement.enabled = !playerMovement.enabled;



        attackComponent.enabled = !attackComponent.enabled;



        //ここに再開後の処理を書く
        TakedDamage = !TakedDamage;


        //animator.PlayInFixedTime("CharaIdle", 0);


        lookAtMovingDirection.enabled = !lookAtMovingDirection.enabled;




        animator.enabled = !animator.enabled;
        //navMesh.enabled = !navMesh.enabled;
        //aIComponent.enabled = !aIComponent.enabled;


    }


}


