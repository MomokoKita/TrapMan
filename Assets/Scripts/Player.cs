using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //プレイヤーの移動処理
    public float speed = 3.0f;
    private Vector3 Player_pos; //プレイヤーのポジション
    private float x; //x方向のImputの値
    private float z; //z方向のInputの値
    private Rigidbody rigd;

    //プレイヤーのアニメーション処理
    private Animator animator = null;
    private bool Carry_Flag = false;


    void Start()
    {
        Player_pos = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
        rigd = GetComponent<Rigidbody>(); //プレイヤーのRigidbodyを取得
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey("right") || Input.GetKey("left") || Input.GetKey("up") || Input.GetKey("down"))
        {
            animator.SetInteger("StateID",1);
        }        
        else
        {
            animator.SetInteger("StateID", 0);
        }

        //モノを持つ判定
        if(Input.GetKeyDown("space") && Carry_Flag == false)
        {
            Debug.Log("持った");
            Carry_Flag = true;
            animator.SetInteger("StateID", 10);
        }

        else if (Input.GetKeyDown("space") && Carry_Flag == true)
        {
            Debug.Log("下した");
            animator.SetInteger("StateID", 11);
            Carry_Flag = false;
        }


        x = Input.GetAxis("Horizontal"); //x方向のInputの値を取得
        z = Input.GetAxis("Vertical"); //z方向のInputの値を取得

            //プレイヤーのRigidbodyに対してInputにspeedを掛けた値で更新し移動
            rigd.velocity = new Vector3(x * speed, 0, z * speed);

            //プレイヤーがどの方向に進んでいるかがわかるように、初期位置と現在地の座標差分を取得
            Vector3 diff = transform.position - Player_pos;

            //ベクトルの長さが0.01fより大きい場合にプレイヤーの向きを変える処理を入れる(0では入れないので）
            if (diff.magnitude > 0.01f)
            {
                //ベクトルの情報をQuaternion.LookRotationに引き渡し回転量を取得しプレイヤーを回転させる
                transform.rotation = Quaternion.LookRotation(diff);
            }
            Player_pos = transform.position; //プレイヤーの位置を更新

    }
    //void Carry()
    //{
    //    animator.SetInteger("StateID", 10);
    //}
}
