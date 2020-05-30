using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterComponent : CharacterComponent
{
    public override void FlipStateComponentsForStaticMotion()//AI用！！！ゆくゆくはオーバーライドで分岐させてけ
    {

        //this.gameObject.GetComponent<Rigidbody>().isKinematic = !this.gameObject.GetComponent<Rigidbody>().isKinematic;
        playerMovement.enabled = !playerMovement.enabled;

        //if (animator.enabled) animator.enabled = !animator.enabled;

        attackComponent.enabled = !attackComponent.enabled;



        TakedDamage = !TakedDamage;

        lookAtMovingDirection.enabled = !lookAtMovingDirection.enabled;
        

    //navMesh.enabled = !navMesh.enabled;
    //aIComponent.enabled = !aIComponent.enabled;

    }
}
