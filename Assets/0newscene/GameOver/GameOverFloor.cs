using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ★追加
using UnityEngine.SceneManagement;

public class GameOverFloor : MonoBehaviour
{
    // ★追加
    private void OnCollisionEnter(Collision collision)
    {
        // 「Player」と「GameOver」の大文字・小文字に注意。
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}