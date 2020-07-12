using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanban : MonoBehaviour
{
    private GameObject player;
    public GameObject text;
    [TextArea(1, 6)]
    public string message;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, this.transform.position) <= 10){
            text.GetComponent<TextMesh>().text = message;
        }
        else
        {
            text.GetComponent<TextMesh>().text = "";
        }
    }
}
