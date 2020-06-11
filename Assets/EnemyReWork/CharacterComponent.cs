using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CharacterComponent : MonoBehaviour
{

    public GameObject fuckthis = null;

    public GameObject CharaDirectionRef = null;


    public Character character = null;

    public float HP = 0;

    public float ST = 0;

    public float MP = 0;

    public bool TakedDamage;


    public Animator animator = null;
    public AttackComponent attackComponent = null;



    /*        Playerのとき          */
    public LookAtMovingDirection lookAtMovingDirection = null;
    public PlayerMovement playerMovement = null;



    /*        AIのとき          */
    public NavMeshAgent navMesh = null;
    public AIComponent aIComponent = null;


    public bool fuckinstate = false;


    public Slider HPbar = null;
    public Slider STbar = null;


    private void Start()
    {
        HP = character.HP;
        ST = character.ST;
    }


    private void FixedUpdate()
    {

        if (TakedDamage)
        {

            Waiter("FlipStateComponentsForStaticMotion", 1f);

        }

        if (HP<=0)
        {

            Waiter("Death", 0.5f);

        }

        HPCalc();
        STCalc();
    }


    public virtual void HPCalc()
    {
        if (HP >= character.HP)
        {

        }


    }

    public virtual void STCalc()
    {



    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponentInParent<ItemComponent>() && (other.gameObject.transform.root.gameObject != this.gameObject) && !TakedDamage)//ぶつかったやつがちゃんとItemで自打球じゃなくてノックバックしてない時
        {

            if (other.gameObject.GetComponentInParent<ItemComponent>().ItemType.itemtype == Item.ItemType.ToolItem)
            {
                Debug.Log(other.gameObject.transform.parent.parent.parent.gameObject.name);


                //相手と自分の相対の向き
                float angle = Mathf.Abs(other.gameObject.transform.parent.parent.parent.gameObject.transform.rotation.eulerAngles.y - (CharaDirectionRef.transform.rotation.eulerAngles.y  ));
                Debug.Log(Mathf.Abs(other.gameObject.transform.parent.parent.parent.gameObject.transform.rotation.eulerAngles.y - CharaDirectionRef.transform.rotation.eulerAngles.y));


                if (attackComponent.isBlocking && ((angle>=90) && (angle <= 270)))
                {
                    Debug.Log("うんち！ｗ");

                    other.gameObject.transform.root.GetComponent<Animator>().SetTrigger("TakeDamage");

                    ST -= other.gameObject.GetComponentInParent<ItemComponent>().ItemType.attack * 3f;

                    other.gameObject.transform.root.GetComponent<CharacterComponent>().FlipStateComponentsForStaticMotion();
                    
                    other.gameObject.transform.root.GetComponent<CharacterComponent>().KnockBackCalc(other.gameObject);

                }

                else
                {
                    animator.SetTrigger("TakeDamage");

                    HP -= other.gameObject.GetComponentInParent<ItemComponent>().ItemType.attack;

                    FlipStateComponentsForStaticMotion();

                    KnockBackCalc(other.gameObject);
                }


            }
                        
        }
    }



    private float count;

    public bool Waiter(string function, float time)//ノックバックとか攻撃時とかにこれ使って何もできない時間作れ
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



    public virtual void FlipStateComponentsForStaticMotion()
    {

        

    }//AI用！！！ゆくゆくはオーバーライドで分岐させてけ



    public void KnockBackCalc(GameObject other)
    {
        //吹き飛ばす方向を求める(プレイヤーから触れたものの方向)
        Vector3 toVec = GetAngleVec(fuckthis, other);

        //Debug.Log(toVec);

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
