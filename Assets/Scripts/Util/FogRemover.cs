using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogRemover : MonoBehaviour
{
    public float TargetFogDenc = 0.0003f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            RenderSettings.fogDensity = Mathf.MoveTowards(RenderSettings.fogDensity, TargetFogDenc, Time.deltaTime * 0.005f);
        }

        // （考え方）触れた瞬間にボールに新しい位置情報をセットする。
        // 「0.5f」のように「小数」を使用する場合には必ず「f」を書くこと（ポイント）
        // 「f」は「float（浮動小数点）」の略
        //other.gameObject.transform.position = new Vector3(1220, 175, -1004);

        //RenderSettings.fogDensity = 0.0003f;

    }
}
