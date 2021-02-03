using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Player : Character
{
    //足音のアニメーション
    [SerializeField] AudioClip[] clips;
    [SerializeField] float pitchRange = 0.1f;
    protected AudioSource source;

    void Start()
    {
        Init();
        // (足音)アタッチしたオーディオソースのうち1番目を使用する
        source = GetComponents<AudioSource>()[0];
    }

    void Update()
    {
        Player_Camera();
        if (Input.GetKey("t"))
        {
            TextRead();
        }
        if (Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("w") || Input.GetKey("s"))
        {           
            animator.SetInteger("StateID",1);
        }        
        else
        {
            animator.SetInteger("StateID", 0);
        }

        Carry();
        Move();       

    }
    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * z + Camera.main.transform.right * x;

        // 移動方向にスピードを掛ける。
        rigd.velocity = moveForward * speed;

    }


    public void PlayFootstepSE()
    {
        source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        source.PlayOneShot(clips[0]);
    }
}
