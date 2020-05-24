using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;
using System.Collections.Generic;
using UnityEngine.AI;

public class AIComponent : MonoBehaviour
{
    [SerializeField]
    private BehaviorTree _tree;

    public Collider DetectionCone = null;
    public List<GameObject> DetectionObjList = new List<GameObject>();
    public bool DetectPlayer = false;
    public bool CautionPlayer = false;

    public CharacterConponent characterComponent = null;
    public AttackComponent attackComponent = null;


    public Transform[] points;
    private int destPoint = 0;

    public NavMeshAgent agent;

    public string PathState = null;


    Coroutine coroutine;


    private void Awake()
    {
        _tree = new BehaviorTreeBuilder(gameObject)//根の部分


            .Selector()//以下の★の部分から成功が返ってきたところを実行（上から順番に検証）

                    .Sequence("Nested Sequence")

                        .Condition("もしデテクションコーンにプレイヤーがひっかかってたら", () =>//分岐に使うやつ？？？？
                        DetectPlayer)

                        .Selector()

                            .Sequence("Nested Sequence")
                                .Condition("Custom Condition", () =>
                                {
                                    if(Vector3.Distance(this.gameObject.transform.position, DetectionObjList[0].transform.position) >= 5)
                                    {
                                        return true;
                                    }

                                    return false;
                                })
                                .Do("遠いから近づけ―", () =>
                                {

                                    Debug.Log("敵を見つけた！");
                                    agent.speed = 3;

                                    agent.SetDestination(DetectionObjList[0].gameObject.transform.position);//NavMeshをつかってプレイヤーの位置に行く


                                    return TaskStatus.Success;
                                })

                            .End()

                            .Sequence("Nested Sequence")
                                .Condition("Custom Condition", () =>
                                {
                                    if (Vector3.Distance(this.gameObject.transform.position, DetectionObjList[0].transform.position) < 5)
                                    {
                                        return true;
                                    }

                                    return false;
                                })
                                .Do("ちけえからとまれ～＝", () =>
                                {

                                    Debug.Log("開けろ！デトロイト市警だ！！");
                                    agent.speed = 0;

                                    agent.SetDestination(DetectionObjList[0].gameObject.transform.position);//NavMeshをつかってプレイヤーの位置に行く


                                    return TaskStatus.Success;
                                })

                            .End()


                        .End()



                .End()//Sequenceここまで



                //.Condition("ある程度近づいたら止まる", () =>//分岐に使うやつ？？？？
                //{

                //    if (Vector3.Distance(this.gameObject.transform.position, DetectionObjList[0].transform.position) <=5)//もしデテクションコーンにプレイヤーがひっかかってたら
                //    {
                //        Debug.Log("近づいたぞ！");

                //        agent.speed = 0;

                //        transform.LookAt(DetectionObjList[0].transform);

                //        //attackComponent.AIFire1 = !attackComponent.AIFire1;


                //        return true;//成功を返す

                //    }

                //    return false;//失敗を返す

                //})







                .Sequence()//★　以下を順番に実行　実行失敗が返ってきたらこれも実行失敗になる


                     .Do("スピードリセット", () =>
                     {


                         agent.speed = 2;


                         return TaskStatus.Success;
                     })

                    .Condition("探索完了した？", () =>//分岐に使うやつ？？？？？
                    {


                        if (!agent.pathPending)
                        {
                            if (agent.remainingDistance <= agent.stoppingDistance)
                            {
                                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)//ここまでチェックポイントに到着したかの判断
                                {

                                    return true;
                                }
                            }
                        }
                        return false;

                    })

                    .Do("次の場所に移動しろ", () =>
                    {

                        // Done
                        Debug.Log("次の場所に行こう");

                        GotoNextPoint();//パトロールのチェックポイントを次の場所に変える
                        agent.SetDestination(points[destPoint].position);//NavMeshをつかって次のチェックポイントの位置に行く


                        agent.speed = 2;

                        Debug.Log("うろうろしてる");//基本的にチェックポイントに到達するまで走る


                        return TaskStatus.Success;
                    })
                .End()



                

            .End()
            .Build();
    }


    private void Update()
    {
        // Update our tree every frame
        _tree.Tick();

    }


    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log(other.gameObject);
        if (other.gameObject.tag == "Player")
        {
            DetectionObjList.Add(other.gameObject);

            DetectPlayer = true;
        }

        


    }
 

    private void OnTriggerExit(Collider other)
    {

        

        if (other.gameObject.tag == "Player")
        {
            DetectionObjList.Remove(other.gameObject);

            DetectPlayer = false;
            CautionPlayer = true;
        }

    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    


}