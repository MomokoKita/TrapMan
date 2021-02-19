using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestControl : SceneManager
{
    ////選択音
    //[SerializeField] AudioClip[] clips;
    //protected AudioSource source;

    [SerializeField] string Message;

    public void OnUserAction()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = uiText.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = Message;
        Invoke("ResetText", 2);
    }
    public void OnClick_No()
    {
        Debug.Log("No");
    }
}
