using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1 : MonoBehaviour
{
    public GameObject Jack; //オリジナルのオブジェクト
    private void OnTriggerEnter(Collider other)
    {
        // もしもぶつかった相手に「Coin」という「Tag」が付いていたならば（条件）
        if (other.CompareTag("miss"))
        {
            Debug.Log(gameObject.name);
            Instantiate(Jack, new Vector3(970, 170, -1010), Quaternion.identity);
        }
    }
}
