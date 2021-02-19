using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class TextControl : SceneManager
{
    [SerializeField] string Message;
    public void OnUserAction()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = uiText.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = Message;
        Invoke("ResetText", 2);
    }
    public void ResetText()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = uiText.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "";
    }
}
