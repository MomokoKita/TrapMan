using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    //選択音
    [SerializeField] AudioClip[] clips;
    protected AudioSource source;

    void Start()
    {
        source = GetComponents<AudioSource>()[0];
    }

    void Quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
              UnityEngine.Application.Quit();
        #endif
    }
    // ボタンが押された場合、今回呼び出される関数
    public void OnClick_Start()
    {
        source.PlayOneShot(clips[0]);
        Debug.Log("START!");  // ログを出力

        Invoke("FadeOut", 1);

    }
    public void OnClick_End()
    {
        Debug.Log("End!");  // ログを出力
        Quit();
    }

    private void FadeOut()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FadeOut");
    }

    //private void StartGame()
    //{
    //    UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    //}
}
