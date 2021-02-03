using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenePanel : MonoBehaviour
{
    float alfa;
    float speed = 0.002f;
    float red, green, blue;

    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    void Update()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += speed;
        if (alfa > 0.99)
        {
            Debug.Log("FadeOut");
            UnityEngine.SceneManagement.SceneManager.LoadScene ("GameScene");
        }

    }
}
