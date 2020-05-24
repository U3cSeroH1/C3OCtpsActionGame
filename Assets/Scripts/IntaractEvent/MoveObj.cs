using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    private Vector3 initialPos = new Vector3();
    private Quaternion initialRot = new Quaternion();

    public Vector3 MoveTransformPos = new Vector3();
    public Vector3 MoveTransformRot = new Vector3();

    public bool Moved = false;


    public GameObject doorHinge = null;

    private void Start()
    {
        initialPos = transform.localPosition;

        initialRot = transform.localRotation;
    }

    public void m_MoveObj(GameObject Intaractor)
    {
        //Moved = !Moved;


        if (!Moved)
        {
            transform.localRotation = Quaternion.Euler(MoveTransformRot);
            Moved = true;
        }
        else
        {
            transform.localRotation = initialRot;
            Moved = false;
        }


        Debug.Log("うんち！");
        Debug.Log(Intaractor.name);

        //transform.localPosition = MoveTransformPos;

    }
    
}
