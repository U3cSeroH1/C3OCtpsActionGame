using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public PlayerMovement playerMovement = null;
    public LookAtMovingDirection lookAtMovingDirection = null;

    public Animator animator = null;

    public float CoolTime = 0.5f;

    public float lastMovingTime = 0;

    public GameObject RightHandToolSlot = null;

    public GameObject LeftHandToolSlot = null;

    public bool isAI = false;


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



                lookAtMovingDirection.LookAtSpeed = 10f;

                if (AIFire1)
                {

                    ///playerMovement.
                    ///
                    animator.SetTrigger("LightAction");
                    lastMovingTime = Time.realtimeSinceStartup;

                    animator.enabled = true;
                    RightHandToolSlot.GetComponentInChildren<Collider>().enabled = true;

                    


                    playerMovement.MovementSpeed = 0f;
                    lookAtMovingDirection.LookAtSpeed = 0;

                    AIFire1 = false;

                }

                else if (AIFire2)
                {

                    ///playerMovement.
                    ///
                    animator.SetTrigger("RightAction");
                    lastMovingTime = Time.realtimeSinceStartup;

                    animator.enabled = true;
                    LeftHandToolSlot.GetComponentInChildren<Collider>().enabled = true;

                    playerMovement.MovementSpeed = 0f;
                    lookAtMovingDirection.LookAtSpeed = 0;
                }



            }

            else
            {


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
                    animator.SetTrigger("LightAction");
                    lastMovingTime = Time.realtimeSinceStartup;

                    animator.enabled = true;
                    RightHandToolSlot.GetComponentInChildren<Collider>().enabled = true;


                    //playerMovement.MovementSpeed = 0f;
                    lookAtMovingDirection.LookAtSpeed = 0;

                }

                else if (Input.GetButtonDown("Fire2"))
                {

                    ///playerMovement.
                    ///
                    animator.SetTrigger("RightAction");
                    lastMovingTime = Time.realtimeSinceStartup;

                    animator.enabled = true;
                    LeftHandToolSlot.GetComponentInChildren<Collider>().enabled = true;

                    //playerMovement.MovementSpeed = 0f;
                    lookAtMovingDirection.LookAtSpeed = 0;
                }



            }

            else
            {


            }
        }

        //animator.enabled = false;
    }


    public void animaterDisabled()
    {
        animator.enabled = !animator.enabled;

        AttackingCollision();
    }


    public void AttackingCollision()
    {
        RightHandToolSlot.GetComponentInChildren<Collider>().enabled = !RightHandToolSlot.GetComponentInChildren<Collider>().enabled;
        


    }





}
