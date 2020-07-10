using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleFloor : MonoBehaviour
{
    private MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // （ポイント）
            // この１行のコードで「Mesh Renderer」にチェックが入った状態になります。
            // ゲームを再生して、触れた瞬間にチェックが入ることを確認しましょう。
            mesh.enabled = true;
        }
    }
}















































C#