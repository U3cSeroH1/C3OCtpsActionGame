using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class CharacterConponent : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject _player;

    public Character characterSO = null;

    public Rigidbody rb = null;

    public LookAtMovingDirection movingDirection = null;

    public Animator animator = null;

    public AttackComponent attackComponent = null;

    //これらはAIの判断材料にする

    public float HP = 0;

    public bool isAttacking = false;

    public bool isBlocking = false;

    public bool takedAttack = false;

    //カス
    public bool isAI = false;


    public void Start()
    {
        HP = characterSO.HP;


        if (GetComponent<NavMeshAgent>())
        {
            isAI = true;
            attackComponent.isAI = true;
        }
    }

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
        if (other.gameObject.GetComponentInParent<ItemComponent>() && (other.gameObject.transform.root.gameObject != _player) && !takedAttack )
        {

            if (other.gameObject.GetComponentInParent<ItemComponent>().ItemType.itemtype == Item.ItemType.ToolItem )//攻撃がHITした時
            {



                Debug.Log("itai!");

                takedAttack = true;




                HP -= other.gameObject.GetComponentInParent<ItemComponent>().ItemType.attack;


                KnockBackCalc(other.gameObject);




            }


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

    public void KnockBackTime()
    {
        takedAttack = false;
    }


    public void KnockBackCalc(GameObject other)
    {
        //吹き飛ばす方向を求める(プレイヤーから触れたものの方向)
        Vector3 toVec = GetAngleVec(_player, other);

        //Y方向を足す
        toVec = toVec + new Vector3(0, -0.5f, 0);

        //ふきとべええ
        rb.AddForce(-toVec * 5, ForceMode.Impulse);
    }


    Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //高さの概念を入れないベクトルを作る
        Vector3 fromVec = new Vector3(_from.transform.position.x, 0, _from.transform.position.z);
        Vector3 toVec = new Vector3(_to.transform.position.x, 0, _to.transform.position.z);

        return Vector3.Normalize(toVec - fromVec);
    }

}
