﻿using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;

public class CharacterComponent : MonoBehaviour
{

    public GameObject fuckthis = null;

    public Character character = null;

    public float HP = 0;

    public float ST = 0;

    public float MP = 0;

    public bool TakedDamage;




    public Animator animator = null;

    /*        AIのとき          */
    public NavMeshAgent navMesh = null;
    public AIComponent aIComponent = null;


    private void Start()
    {
        HP = character.HP;
    }


    private void FixedUpdate()
    {

        if (TakedDamage)
        {

            Waiter("FlipStateComponentsForStaticMotion", 1f);

        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<ItemComponent>().ItemType.itemtype == Item.ItemType.ToolItem)
        {

            HP -= other.gameObject.GetComponentInParent<ItemComponent>().ItemType.attack;

            FlipStateComponentsForStaticMotion();

            KnockBackCalc(other.gameObject);


        }

    }



    private float count;

    public bool Waiter(string function, float time)
    {
        count += Time.deltaTime;

        if (count >= time)
        {
            count = 0.0f;

            Invoke(function, 0);

            return true;
        }
        return false;
    }


    public void Death()
    {

        DestroyImmediate(gameObject);

    }



    public void FlipStateComponentsForStaticMotion()
    {

        this.gameObject.GetComponent<Rigidbody>().isKinematic = !this.gameObject.GetComponent<Rigidbody>().isKinematic;

        animator.enabled = !animator.enabled;

        TakedDamage = !TakedDamage;

        navMesh.enabled = !navMesh.enabled;
        aIComponent.enabled = !aIComponent.enabled;
        
    }


    public void KnockBackCalc(GameObject other)
    {
        //吹き飛ばす方向を求める(プレイヤーから触れたものの方向)
        Vector3 toVec = GetAngleVec(fuckthis, other);

        //Y方向を足す
        toVec = toVec + new Vector3(0, -0.5f, 0);

        //ふきとべええ
        fuckthis.GetComponent<Rigidbody>().AddForce(-toVec * 5, ForceMode.Impulse);
    }


    Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //高さの概念を入れないベクトルを作る
        Vector3 fromVec = new Vector3(_from.transform.position.x, 0, _from.transform.position.z);
        Vector3 toVec = new Vector3(_to.transform.position.x, 0, _to.transform.position.z);

        return Vector3.Normalize(toVec - fromVec);
    }



}
