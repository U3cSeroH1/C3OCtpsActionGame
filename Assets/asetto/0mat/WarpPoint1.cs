using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // （考え方）触れた瞬間にボールに新しい位置情報をセットする。
        // 「0.5f」のように「小数」を使用する場合には必ず「f」を書くこと（ポイント）
        // 「f」は「float（浮動小数点）」の略
        other.gameObject.transform.position = new Vector3(540, 215, -1010);
    }
}