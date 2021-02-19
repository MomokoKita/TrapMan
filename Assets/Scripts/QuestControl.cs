using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestControl : MonoBehaviour
{
    //選択音
    [SerializeField] AudioClip[] clips;
    protected AudioSource source;

    // Start is called before the first frame update
    void Start()
    {       
        source = GetComponents<AudioSource>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_Yes()
    {

    }
    public void OnClick_No()
    {

    }
}
