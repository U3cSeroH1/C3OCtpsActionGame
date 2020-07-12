using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissEnemySpawn : MonoBehaviour
{

    public Transform spawnpoint = null;

    public GameObject SpawnObject = null;


    public float cooltime = 100f;
    public float deltatime = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (deltatime <= cooltime)
        {
            deltatime += Time.deltaTime;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("はずれ！スポーン");
        //other.transform.root.gameObject.transform.position = spawnpoint.position;

        if (cooltime <= deltatime)
        {
            Instantiate(SpawnObject, spawnpoint.position, Quaternion.identity);
            deltatime = 0;
        }


    }

}
