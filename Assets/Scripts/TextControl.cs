using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class TextControl : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    public void OnUserAction()
    {
        Debug.Log("トイレです");
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "トイレだ。酷いにおいがする";
        Invoke("ResetText", 2);
    }
    public void ResetText()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "";
    }
}
