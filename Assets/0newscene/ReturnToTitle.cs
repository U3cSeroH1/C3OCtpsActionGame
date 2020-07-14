using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ★追加
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    // ★追加
    public int timeCount;

    void Start()
    {
        // ★追加
        // 任意に設定した時間の経過後、「GoTitle」メソッドを呼び出す（ポイント）
        Invoke("GoTitle", timeCount);
    }

    // ★追加
    void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}