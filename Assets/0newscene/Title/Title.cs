using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ★追加
using UnityEngine.SceneManagement;

public class Title: MonoBehaviour
{
    // ★追加
    // 「public」を必ずつけること（ポイント）
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("ForMrDanScene");
    }
}