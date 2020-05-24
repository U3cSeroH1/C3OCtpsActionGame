using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMovingDirection : MonoBehaviour
{
    //public Rigidbody rigidbody = null;

    private Vector3 DeltaPos;

    public GameObject RotatedModel = null;

    public float LookAtSpeed = 1f;

    public float LeanAngle = 1f;

    public GameObject MainCamera = null;


    // Update is called once per frame
    void FixedUpdate()
    {

        calculateMovingDirection();

    }


    public void calculateMovingDirection()
    {
        Vector3 diff = (transform.position - DeltaPos).normalized;



        //Debug.Log(diff * 100);

        if (diff != Vector3.zero)
        {
            if (Mathf.Abs(diff.x) <= 0.25f && Mathf.Abs(diff.z) <= 0.25f)
            {

            }
            else
            {
                diff = new Vector3(diff.x, Mathf.Clamp(diff.y, -LeanAngle, LeanAngle), diff.z);
                Quaternion targetRotation = Quaternion.LookRotation(diff);
                RotatedModel.transform.rotation = Quaternion.Slerp(RotatedModel.transform.rotation, targetRotation, Time.deltaTime * LookAtSpeed);

                //MainCamera.transform.Rotate(-targetRotation.eulerAngles);

            }

        }
        else
        {
            RotatedModel.transform.rotation = Quaternion.Slerp(RotatedModel.transform.rotation, new Quaternion(0, RotatedModel.transform.rotation.y, 0, RotatedModel.transform.rotation.w), Time.deltaTime * LookAtSpeed);
        }

        DeltaPos = transform.position;
    }

}
