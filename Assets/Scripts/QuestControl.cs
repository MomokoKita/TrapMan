using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestControl : SceneManager
{
    //選択音
    [SerializeField] AudioClip[] clips;
    protected AudioSource source;

    void Start()
    {
        source = GetComponents<AudioSource>()[0];
    }

    public void OnUserAction()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = uiText.GetComponent<Text>();
        // テキストの表示を入れ替える
        Invoke("ResetText", 2);
    }

    public void GameClear()
    {
        source.PlayOneShot(clips[0]);
        Invoke("GameClearChange", 6);
    }
    public void GameOver()
    {
        source.PlayOneShot(clips[0]);
        Invoke("GameOverChange", 6);
    }

    public void GameClearChange()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameClear");
    }

    public void GameOverChange()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
