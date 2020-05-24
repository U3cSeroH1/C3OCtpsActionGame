using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public Rigidbody rb = null;

    public GameObject camera4Direction = null;

    public Vector3 MoveDirection;

    public float moveForceMultiplier = 1f;

    public float MovementSpeed = 10f;

    private void FixedUpdate()
    {
        CaluculateMovement();
    }


    public void CaluculateMovement()
    {
        Vector3 cameraForward = Vector3.Scale(camera4Direction.transform.forward, new Vector3(1, 0, 1)).normalized;


        //MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f , Input.GetAxis("Vertical")) * 10;

        MoveDirection = cameraForward * Input.GetAxis("Vertical") + camera4Direction.transform.right * Input.GetAxis("Horizontal");



        rb.AddForce(moveForceMultiplier * (MoveDirection * MovementSpeed - rb.velocity));


        //// カメラの方向から、X-Z平面の単位ベクトルを取得
        //

        //// 方向キーの入力値とカメラの向きから、移動方向を決定
        //Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

    }
}
