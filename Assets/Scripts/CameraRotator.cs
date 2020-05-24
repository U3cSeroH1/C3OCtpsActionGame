using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{

    public GameObject mainCamera;              //メインカメラ格納用

    public GameObject Character;

    public float rotateSpeed = 2.0f;            //回転の速さ


    public MenuScript menuScript = null;


    //呼び出し時に実行される関数
    void Start()
    {

    }


    //単位時間ごとに実行される関数
    void Update()
    {
        //rotateCameraの呼び出し

        if (!menuScript.IsMenuShow)
        {
            rotateCamera();
        }


    }

    //”じぶんを”回転させる関数
    private void rotateCamera()
    {
        //Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        //transform.RotateAround()をしようしてメインカメラを回転させる

        transform.Rotate(angle, Space.World);

        //mainCamera.transform.Rotate(angle, Space.World);


        Character.transform.Rotate(-angle, Space.World);
    }
}