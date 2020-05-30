using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackComponent : MonoBehaviour
{
    public PlayerMovement playerMovement = null;
    public LookAtMovingDirection lookAtMovingDirection = null;

    public Animator animator = null;

    public float CoolTime = 0.5f;

    public float lastMovingTime = 0;

    public GameObject RightHandToolSlot = null;

    public GameObject LeftHandToolSlot = null;


    public bool isBlocking = false;


    public bool isAI = false;
    public NavMeshAgent navMeshAgent = null;

    public bool AIFire1 = false;
    public bool AIFire2 = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {


        isAttacked();




    }


    public void isAttacked()
    {

        if (isAI)
        {



            if (Time.realtimeSinceStartup - lastMovingTime > CoolTime)
            {



                //lookAtMovingDirection.LookAtSpeed = 10f;

                if (AIFire1)
                {

                    ///playerMovement.
                    ///
                    
                    lastMovingTime = Time.realtimeSinceStartup;

                    navMeshAgent.enabled = false;


                    animator.enabled = true;

                    animator.SetBool("TakeDamage", false);

                    animator.SetTrigger("LightAction");



                    RightHandToolSlot.GetComponentInChildren<Collider>().enabled = true;

                    Debug.Log("攻撃AIl");


                    playerMovement.MovementSpeed = 0f;
                    //lookAtMovingDirection.LookAtSpeed = 0;

                    AIFire1 = false;

                }

                else if (AIFire2)
                {

                    ///playerMovement.
                    ///

                    isBlocking = !isBlocking;

                    animator.SetTrigger("RightAction");
                    lastMovingTime = Time.realtimeSinceStartup;

                    animator.enabled = true;
                    LeftHandToolSlot.GetComponentInChildren<Collider>().enabled = true;

                    playerMovement.MovementSpeed = 0f;
                    //lookAtMovingDirection.LookAtSpeed = 0;
                }



            }

            else
            {
                //navMeshAgent.enabled = true;

            }
        }

        else 
        {
            if (Time.realtimeSinceStartup - lastMovingTime > CoolTime)
            {



                lookAtMovingDirection.LookAtSpeed = 10f;

                if (Input.GetButtonDown("Fire1"))
                {

                    ///playerMovement.
                    ///
             
                    lastMovingTime = Time.realtimeSinceStartup;

                    Debug.Log("攻撃PLy");

                    animator.enabled = true;

                    animator.SetBool("TakeDamage", false);

                    animator.SetTrigger("LightAction");

                    RightHandToolSlot.GetComponentInChildren<Collider>().enabled = true;


                    //playerMovement.MovementSpeed = 0f;
                    lookAtMovingDirection.LookAtSpeed = 0;

                }
            }

            if (Input.GetAxis("Fire2") == 1)
            {
                isBlocking = true;
                ///playerMovement.
                ///
                animator.SetBool("RightAction", true);
                lastMovingTime = Time.realtimeSinceStartup;

                animator.enabled = true;
                LeftHandToolSlot.GetComponentInChildren<Collider>().enabled = true;

                //playerMovement.MovementSpeed = 0f;
                lookAtMovingDirection.LookAtSpeed = 0;
            }
            else
            {
                animator.SetBool("RightAction", false);
                isBlocking = false;
            }

        }

        //animator.enabled = false;
    }


    public void animaterDisabled()
    {
        animator.enabled = !animator.enabled;

        AttackingCollision();

        if (isAI)
        {
            navMeshAgent.enabled = true;
        }



    }


    public void AttackingCollision()
    {
        RightHandToolSlot.GetComponentInChildren<Collider>().enabled = !RightHandToolSlot.GetComponentInChildren<Collider>().enabled;
        


    }





}
