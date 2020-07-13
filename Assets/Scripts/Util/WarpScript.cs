using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpScript : MonoBehaviour
{

    public Transform to = null;
    public GameObject TelepObj = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ワープ");

        if (TelepObj && other.tag == "Player")
        {
            //TelepObj.transform.position = to.position;
            TelepObj.GetComponent<Rigidbody>().isKinematic = false;
            TelepObj.GetComponent<Rigidbody>().useGravity = false;
            TelepObj.GetComponent<Rigidbody>().AddForce(0, 5f, 0, ForceMode.Impulse);
            TelepObj.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 10f, 0);
        }
        if(!TelepObj)
        other.transform.root.gameObject.transform.position = to.position;

    }


}
