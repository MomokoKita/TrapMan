using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    private bool light_Flag = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z") && light_Flag)
        {
            // GameObject型の配列Lightに、"Light"タグのついたオブジェクトをすべて格納
            GameObject[] Light = GameObject.FindGameObjectsWithTag("Light");

            // GameObject型の変数lightに、Lightの中身を順番に取り出す。
            // foreachは配列の要素の数だけループします。
            foreach (GameObject light in Light)
            {
                // 非表示にする
                var lightComponent = light.GetComponent<UnityEngine.Light>();
                if(lightComponent != null)
                {
                    lightComponent.enabled = false;
                }
            }
            light_Flag = false;
        }
        else if (Input.GetKeyDown("z") && !(light_Flag))
        {
            // GameObject型の配列Lightに、"Light"タグのついたオブジェクトをすべて格納
            GameObject[] Light = GameObject.FindGameObjectsWithTag("Light");

            // GameObject型の変数lightに、Lightの中身を順番に取り出す。
            // foreachは配列の要素の数だけループします。
            foreach (GameObject light in Light)
            {
                // 表示する
                var lightComponent = light.GetComponent<UnityEngine.Light>();
                if (lightComponent != null)
                {
                    lightComponent.enabled = true;
                }
            }
            light_Flag = true;
        }
    }
}
