using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class SceneManager : MonoBehaviour
{
    public string TextTag = "Text";
    public string QuestTag = "Quest";

    public GameObject uiText = null; // Textオブジェクト

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("左クリック");
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag(TextTag))
                {
                    hit.collider.gameObject.GetComponent<TextControl>().OnUserAction();
                }
                else
                {
                    // オブジェクトからTextコンポーネントを取得
                    Text score_text = uiText.GetComponent<Text>();
                    // テキストの表示を入れ替える
                    score_text.text = "";
                }
            }
        }
    }

}
